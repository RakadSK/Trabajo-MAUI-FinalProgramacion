namespace MiniCalculadora;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    // Evento del botón Calcular
    private void OnCalcularClicked(object sender, EventArgs e)
    {
        try
        {
            // Validar que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(numero1Entry.Text) ||
                string.IsNullOrWhiteSpace(numero2Entry.Text))
            {
                resultadoLabel.Text = "Ingrese ambos números";
                resultadoLabel.TextColor = Colors.Orange;
                return;
            }

            // Validar que se haya seleccionado una operación
            if (operacionPicker.SelectedIndex == -1)
            {
                resultadoLabel.Text = "Seleccione una operación";
                resultadoLabel.TextColor = Colors.Orange;
                return;
            }

            double num1 = double.Parse(numero1Entry.Text);
            double num2 = double.Parse(numero2Entry.Text);
            double resultado = 0;

            // Ejecutar la operación seleccionada
            switch (operacionPicker.SelectedIndex)
            {
                case 0: // Sumar
                    resultado = num1 + num2;
                    break;
                case 1: // Restar
                    resultado = num1 - num2;
                    break;
                case 2: // Multiplicar
                    resultado = num1 * num2;
                    break;
                case 3: // Dividir
                    if (num2 == 0)
                    {
                        resultadoLabel.Text = "Error: División entre cero";
                        resultadoLabel.TextColor = Colors.Red;
                        return;
                    }
                    resultado = num1 / num2;
                    break;
            }

            // Mostrar resultado con 2 decimales
            resultadoLabel.Text = $"= {resultado:F2}";
            resultadoLabel.TextColor = Colors.Green;
        }
        catch (Exception ex)
        {
            // Manejo de errores generales (ej: formato numérico inválido)
            resultadoLabel.Text = $"Error: {ex.Message}";
            resultadoLabel.TextColor = Colors.Red;
        }
    }
}
