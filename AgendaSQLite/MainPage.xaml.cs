namespace AgendaSQLite;

public partial class MainPage : ContentPage
{
    public MainPage(ContactsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
