namespace To_Do_List_Program;

public static class TasksLogic
{
    public static void ShowTasks()
    {
        List<TaskItem> taskCollection = TasksDao.ReturnLinesFromFile();
        foreach (var task in taskCollection)
        {
            Console.WriteLine($"{task.Title}: {task.IsCompleted}");
        }
    }
    public static void AddTask(string newTaskName)
    {
        var newTask = new TaskItem(newTaskName, false);
        TasksDao.AppendTaskToFile(newTask);
    }
    public static void CompleteTask(string completedTaskName)
    {
        completedTaskName = TasksLogic.ReturnCapitalizedName(completedTaskName);
        List<TaskItem> taskCollection = TasksDao.ReturnLinesFromFile();
        
        TaskItem? foundTask = taskCollection.FirstOrDefault(t => t.Title == completedTaskName);
        if (foundTask != null)
        {
            foundTask.IsCompleted = true;
            TasksDao.OverwriteAllText(taskCollection);
        }
        else
        {
            Console.WriteLine("Task could not be found!");
        }
    }

    public static void DeleteTask(string deleteTaskName)
    {
        deleteTaskName = TasksLogic.ReturnCapitalizedName(deleteTaskName);
        List<TaskItem> taskCollection = TasksDao.ReturnLinesFromFile();
        
        TaskItem? foundTask = taskCollection.FirstOrDefault(t => t.Title == deleteTaskName);
        if (foundTask != null)
        {
            taskCollection.Remove(foundTask);
            TasksDao.OverwriteAllText(taskCollection);
        }
        else
        {
            Console.WriteLine("Task could not be found!");
        }
        
    }
    
    public static string ReturnTextToString(string name, bool isCompleted)
    {
        return $"{name}: {isCompleted}";
    }
    public static string ReturnCapitalizedName(string name)
    {
        name = char.ToUpper(name[0]) + name.Substring(1);
        return name;
    }
}