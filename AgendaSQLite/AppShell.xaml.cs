namespace AgendaSQLite;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // Registrar ruta para navegación a pantalla de detalle
        Routing.RegisterRoute("ContactDetailPage", typeof(ContactDetailPage));
    }
}
