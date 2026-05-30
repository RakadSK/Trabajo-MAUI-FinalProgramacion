using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace AgendaSQLite;

/// <summary>
/// ViewModel para la pantalla de contactos.
/// Implementa operaciones CRUD completas conectadas a DatabaseService.
/// </summary>
public partial class ContactsViewModel : ObservableObject
{
    private readonly DatabaseService _database;

    // Lista observable de contactos mostrados en pantalla
    [ObservableProperty]
    private ObservableCollection<Contact> contacts;

    // Contacto actualmente en edición
    [ObservableProperty]
    private Contact currentContact;

    // Texto de búsqueda
    [ObservableProperty]
    private string searchText;

    public ContactsViewModel(DatabaseService database)
    {
        _database = database;
        LoadContacts();
    }

    /// <summary>Carga todos los contactos desde la base de datos.</summary>
    [RelayCommand]
    private async Task LoadContacts()
    {
        var contactList = await _database.GetContactsAsync();
        Contacts = new ObservableCollection<Contact>(contactList);
    }

    /// <summary>Prepara un nuevo contacto vacío para ser rellenado.</summary>
    [RelayCommand]
    private async Task NewContact()
    {
        CurrentContact = new Contact();
        await Shell.Current.GoToAsync("ContactDetailPage");
    }

    /// <summary>Navega a la pantalla de edición del contacto seleccionado.</summary>
    [RelayCommand]
    private async Task EditContact(Contact contact)
    {
        if (contact == null) return;
        CurrentContact = contact;
        await Shell.Current.GoToAsync("ContactDetailPage");
    }

    /// <summary>Guarda el contacto actual (insert o update según su Id).</summary>
    [RelayCommand]
    private async Task SaveContact()
    {
        if (CurrentContact == null) return;

        // Validación básica
        if (string.IsNullOrWhiteSpace(CurrentContact.Name))
        {
            await Shell.Current.DisplayAlert("Error", "El nombre es obligatorio", "OK");
            return;
        }

        await _database.SaveContactAsync(CurrentContact);
        await LoadContacts();
        await Shell.Current.GoToAsync("..");
    }

    /// <summary>Elimina un contacto con confirmación del usuario.</summary>
    [RelayCommand]
    private async Task DeleteContact(Contact contact)
    {
        bool confirm = await Shell.Current.DisplayAlert(
            "Confirmar eliminación",
            $"¿Deseas eliminar a {contact.Name}?",
            "Sí", "No");

        if (confirm)
        {
            await _database.DeleteContactAsync(contact);
            await LoadContacts();
        }
    }

    /// <summary>Busca contactos por nombre o teléfono.</summary>
    [RelayCommand]
    private async Task Search()
    {
        if (string.IsNullOrWhiteSpace(SearchText))
            await LoadContacts();
        else
        {
            var results = await _database.SearchContactsAsync(SearchText);
            Contacts = new ObservableCollection<Contact>(results);
        }
    }
}
