namespace ListaTareas;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        // Asignar el ViewModel como BindingContext
        BindingContext = new MainViewModel();
    }
}
