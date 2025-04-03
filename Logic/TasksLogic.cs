using To_Do_List_Program.DataHandling;

namespace To_Do_List_Program.Logic;

public static class TasksLogic
{
    public static void ShowTasks()
    {
        List<TaskItem> taskCollection = TasksDao.ReturnLinesFromFile();
        foreach (var task in taskCollection)
        {
            Console.WriteLine($"{task.Title}: {ReturnIsCompletedValueInString(task.IsCompleted)}: {task.Priority}");
        }
    }
    public static void AddTask(string newTaskName, string newTaskPriority)
    {
        newTaskName = ReturnCapitalizedName(newTaskName);
        newTaskPriority = ReturnCapitalizedPriorityName(newTaskPriority);
        
        var newTask = new TaskItem(newTaskName, false, newTaskPriority);
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

    
    public static string ReturnTaskToString(string name, string priority)
    {
        return $"{name}: Not Completed: {priority}";
    }
    private static string ReturnCapitalizedName(string name)
    {
        name = char.ToUpper(name[0]) + name.Substring(1);
        return name;
    }
    private static string ReturnCapitalizedPriorityName(string priorityName)
    {
        priorityName = priorityName.ToLower();
        priorityName = char.ToUpper(priorityName[0]) + priorityName.Substring(1);
        return priorityName;
    }

    public static string ReturnIsCompletedValueInString(bool isCompleted)
    {
        if (isCompleted)
        {
            return "Completed";
        }
        else
        {
            return "Not Completed";
        }
    }
}