using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ClimaApp;

/// <summary>
/// Modelo de datos del clima que implementa INotifyPropertyChanged
/// para soportar Data Binding y actualización automática de la UI.
/// </summary>
public class WeatherData : INotifyPropertyChanged
{
    private double temperature;
    private int humidity;
    private string condition;

    // Propiedad Temperatura con notificación de cambio
    public double Temperature
    {
        get => temperature;
        set
        {
            temperature = value;
            OnPropertyChanged();
        }
    }

    // Propiedad Humedad con notificación de cambio
    public int Humidity
    {
        get => humidity;
        set
        {
            humidity = value;
            OnPropertyChanged();
        }
    }

    // Propiedad Condición climática con notificación de cambio
    public string Condition
    {
        get => condition;
        set
        {
            condition = value;
            OnPropertyChanged();
        }
    }

    // Evento requerido por INotifyPropertyChanged
    public event PropertyChangedEventHandler PropertyChanged;

    // Método helper para disparar el evento con el nombre de la propiedad
    protected void OnPropertyChanged([CallerMemberName] string name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
