using SQLite;

namespace AgendaSQLite;

/// <summary>
/// Modelo de Contacto mapeado a la tabla "Contacts" en SQLite.
/// Los atributos de SQLite-NET controlan la estructura de la base de datos.
/// </summary>
[Table("Contacts")]
public class Contact
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [NotNull]
    public string Name { get; set; }

    public string Phone { get; set; }
    public string Email { get; set; }
    public DateTime CreatedAt { get; set; }
}
