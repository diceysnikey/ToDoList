namespace To_Do_List_Program;
public class TaskItem
{
    public string Title { get; }
    public bool IsCompleted { get; set; }
    public TaskItem (string title, bool isCompleted)
    {
        Title = title;
        IsCompleted = isCompleted;
    }
}


