using SQLite;

namespace AgendaSQLite;

/// <summary>
/// Servicio de acceso a datos para la base de datos SQLite local.
/// Expone operaciones CRUD asíncronas para el modelo Contact.
/// </summary>
public class DatabaseService
{
    private readonly SQLiteAsyncConnection _database;

    public DatabaseService(string dbPath)
    {
        _database = new SQLiteAsyncConnection(dbPath);
        // Crear la tabla si no existe (sincrónico en constructor)
        _database.CreateTableAsync<Contact>().Wait();
    }

    /// <summary>Obtiene todos los contactos ordenados por nombre.</summary>
    public Task<List<Contact>> GetContactsAsync()
    {
        return _database.Table<Contact>()
                        .OrderBy(c => c.Name)
                        .ToListAsync();
    }

    /// <summary>Guarda un contacto: inserta si Id == 0, actualiza si Id > 0.</summary>
    public Task<int> SaveContactAsync(Contact contact)
    {
        if (contact.Id != 0)
            return _database.UpdateAsync(contact);
        else
        {
            contact.CreatedAt = DateTime.Now;
            return _database.InsertAsync(contact);
        }
    }

    /// <summary>Elimina un contacto de la base de datos.</summary>
    public Task<int> DeleteContactAsync(Contact contact)
    {
        return _database.DeleteAsync(contact);
    }

    /// <summary>Busca contactos por nombre o teléfono.</summary>
    public Task<List<Contact>> SearchContactsAsync(string query)
    {
        return _database.Table<Contact>()
                        .Where(c => c.Name.Contains(query) || c.Phone.Contains(query))
                        .ToListAsync();
    }
}
