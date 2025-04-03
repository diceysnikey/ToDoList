namespace To_Do_List_Program.DataHandling;
public class TaskItem
{
    public string Title { get; }
    public bool IsCompleted { get; set; }
    public string Priority { get; set; }
    public TaskItem (string title, bool isCompleted, string priority)
    {
        Title = title;
        IsCompleted = isCompleted;
        Priority = priority;
    }
}


