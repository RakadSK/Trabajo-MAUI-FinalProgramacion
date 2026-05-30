using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace ListaTareas;

/// <summary>
/// ViewModel principal usando CommunityToolkit.Mvvm.
/// Los atributos [ObservableProperty] y [RelayCommand] generan código automáticamente.
/// </summary>
public partial class MainViewModel : ObservableObject
{
    // Lista observable de tareas (notifica cambios a la UI)
    [ObservableProperty]
    private ObservableCollection<TaskItem> tasks;

    // Texto para nueva tarea
    [ObservableProperty]
    private string newTaskName;

    public MainViewModel()
    {
        Tasks = new ObservableCollection<TaskItem>();
        CargarTareasEjemplo();
    }

    // Comando para agregar una nueva tarea
    [RelayCommand]
    private void AddTask()
    {
        if (!string.IsNullOrWhiteSpace(NewTaskName))
        {
            Tasks.Add(new TaskItem
            {
                Id = Tasks.Count + 1,
                Name = NewTaskName,
                IsCompleted = false,
                CreatedAt = DateTime.Now
            });

            // Limpiar el campo de entrada
            NewTaskName = string.Empty;

            // Guardar cambios en almacenamiento local
            GuardarTareas();
        }
    }

    // Comando para eliminar una tarea específica
    [RelayCommand]
    private void DeleteTask(TaskItem task)
    {
        if (task != null)
        {
            Tasks.Remove(task);
            GuardarTareas();
        }
    }

    // Cargar tareas de ejemplo al iniciar
    private void CargarTareasEjemplo()
    {
        // Intentar cargar desde almacenamiento local primero
        var json = Preferences.Get("tasks_json", string.Empty);
        if (!string.IsNullOrEmpty(json))
        {
            try
            {
                var saved = JsonSerializer.Deserialize<List<TaskItem>>(json);
                if (saved != null)
                {
                    foreach (var t in saved)
                        Tasks.Add(t);
                    return;
                }
            }
            catch { /* Si falla, cargar ejemplos */ }
        }

        // Tareas de ejemplo iniciales
        Tasks.Add(new TaskItem { Id = 1, Name = "Hacer mercado en el D1 de Belmonte", IsCompleted = false, CreatedAt = DateTime.Now });
        Tasks.Add(new TaskItem { Id = 2, Name = "Estudiar MAUI para RaulSaurio", IsCompleted = true, CreatedAt = DateTime.Now });
    }

    // Persistencia: guardar lista de tareas como JSON en Preferences
    private void GuardarTareas()
    {
        var json = JsonSerializer.Serialize(Tasks.ToList());
        Preferences.Set("tasks_json", json);
    }
}
