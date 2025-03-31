namespace To_Do_List_Program;

public static class TasksDao
{
    private const string FilePath = @"C:\Users\Erdin Zeller\RiderProjects\cstest\To_Do_List_Program\AllTasks.txt";
    
    public static List<TaskItem> ReturnLinesFromFile()
    {
        var taskCollection = new List<TaskItem>();
        
        var lines = File.ReadAllLines(FilePath)
            .Where(x => !string.IsNullOrWhiteSpace(x));
        
        foreach (var line in lines)
        {
            var parts = line.Split(": ");
            
            var fileTitle = parts[0];
            var fileIsCompleted = bool.Parse(parts[1]);
            taskCollection.Add(new TaskItem(fileTitle, fileIsCompleted));
        }

        return taskCollection;
    }
    public static void OverwriteAllText(List<TaskItem> tasks)
    {
        File.WriteAllText(FilePath, "");
        for (int i = 0; i < tasks.Count; i++)
        {
            File.AppendAllText(FilePath,
                $"{tasks[i].Title}: {tasks[i].IsCompleted}" +
                (i < tasks.Count - 1 ? Environment.NewLine : ""));
        }
    }

    public static void AppendTaskToFile(TaskItem newTask)
    {
        if (new FileInfo(FilePath).Length == 0)
        {
            File.AppendAllText(FilePath, TasksLogic.ReturnTextToString
                (TasksLogic.ReturnCapitalizedName(newTask.Title), false));
        }
        else
        {
            File.AppendAllText(FilePath, Environment.NewLine
                                         + TasksLogic.ReturnTextToString
                                             (TasksLogic.ReturnCapitalizedName(newTask.Title), false));
        }
    }
}