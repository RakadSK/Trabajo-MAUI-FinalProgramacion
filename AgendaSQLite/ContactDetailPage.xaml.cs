namespace AgendaSQLite;

public partial class ContactDetailPage : ContentPage
{
    public ContactDetailPage(ContactsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
