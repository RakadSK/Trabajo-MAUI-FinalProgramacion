namespace ListaTareas;

/// <summary>
/// Modelo que representa una tarea en la lista To-Do.
/// </summary>
public class TaskItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime CreatedAt { get; set; }
}
