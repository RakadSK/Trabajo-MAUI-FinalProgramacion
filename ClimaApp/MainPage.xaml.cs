namespace ClimaApp;

public partial class MainPage : ContentPage
{
    // Instancia del modelo de datos del clima
    private WeatherData weatherData;

    public MainPage()
    {
        InitializeComponent();

        // Crear datos de ejemplo iniciales
        weatherData = new WeatherData
        {
            Temperature = 24.5,
            Humidity = 65,
            Condition = "Parcialmente nublado"
        };

        // Asignar BindingContext para que el XAML pueda hacer Data Binding
        // Esto elimina la necesidad de actualizar cada Label manualmente
        this.BindingContext = weatherData;
    }

    // Simula la actualización del clima con datos aleatorios
    private void OnActualizarClicked(object sender, EventArgs e)
    {
        var random = new Random();

        // Actualizar propiedades del modelo (la UI se actualiza automáticamente)
        weatherData.Temperature = random.Next(15, 35) + random.NextDouble();
        weatherData.Humidity = random.Next(40, 90);

        // Condiciones climáticas posibles
        string[] conditions = { "Soleado", "Parcialmente nublado", "Nublado", "Lluvioso" };
        weatherData.Condition = conditions[random.Next(conditions.Length)];
    }
}
