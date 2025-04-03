using To_Do_List_Program.Logic;

namespace To_Do_List_Program.DataHandling;

public static class TasksDao
{
    private const string FilePath = "../../../Resources/AllTasks.txt";
    
    public static void CreateTextFile()
    {
        if (!File.Exists(FilePath))
        {
            File.Create(FilePath).Close();
        }
    }
    public static List<TaskItem> ReturnLinesFromFile()
    {
        var taskCollection = new List<TaskItem>();
        
        var lines = File.ReadAllLines(FilePath)
            .Where(x => !string.IsNullOrWhiteSpace(x));
        
        foreach (var line in lines)
        {
            bool isCompleted;
            
            var parts = line.Split(": ");
            
            var fileTitle = parts[0];
            
            var fileIsCompleted = parts[1];
            if (fileIsCompleted == "Completed")
            {
                isCompleted = true;
            }
            else
            {
                isCompleted = false;
            }
            
            var filePriority= parts[2];
            taskCollection.Add(new TaskItem(fileTitle, isCompleted, filePriority));
        }

        return taskCollection;
    }
    public static void OverwriteAllText(List<TaskItem> tasks)
    {
        File.WriteAllText(FilePath, "");
        for (var i = 0; i < tasks.Count; i++)
        {
            File.AppendAllText(FilePath,
                $"{tasks[i].Title}: {TasksLogic.ReturnIsCompletedValueInString(tasks[i].IsCompleted)}: {tasks[i].Priority}" +
                (i < tasks.Count - 1 ? Environment.NewLine : ""));
        }
    }

    public static void AppendTaskToFile(TaskItem newTask)
    {
        if (new FileInfo(FilePath).Length == 0)
        {
            File.AppendAllText(FilePath, TasksLogic.ReturnTaskToString
                (newTask.Title, newTask.Priority));
        }
        else
        {
            File.AppendAllText(FilePath, Environment.NewLine
                                         + TasksLogic.ReturnTaskToString
                                             (newTask.Title, newTask.Priority));
        }
    }
}