namespace MiPrimeraApp;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    // Evento del botón Saludar
    private void OnSaludarClicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(nombreEntry.Text))
        {
            // Mostrar saludo personalizado
            mensajeLabel.Text = $"¡Hola, {nombreEntry.Text}!";
            mensajeLabel.TextColor = Colors.DarkGreen;
        }
        else
        {
            // Mensaje de error si el campo está vacío
            mensajeLabel.Text = "Por favor ingresa tu nombre";
            mensajeLabel.TextColor = Colors.Red;
        }
    }
}
