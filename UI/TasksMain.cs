using To_Do_List_Program.DataHandling;
using To_Do_List_Program.Logic;

namespace To_Do_List_Program.UI;

public static class TasksMain
{
    private static void Main()
    {
        TasksConsole.ShowWelcomeMessage();
        Thread.Sleep(750);
        while (true)
        {
            Initialization();
            Thread.Sleep(1500);
            TasksConsole.PrintRepeatToConsole();
        }
    }
    private static void Initialization()
    {
        TasksDao.CreateTextFile();
        TasksConsole.ShowAllCommands();
        string userCommand = TasksConsole.ReadCommandFromUser();

        switch (userCommand)
        {
            case "1":
                TasksLogic.ShowTasks();
                break;
            case "2":
                TasksLogic.AddTask(TasksConsole.AddTaskNameFromUser(), TasksConsole.AddTaskPriorityFromUser());
                break;
            case "3":
                TasksLogic.CompleteTask(TasksConsole.CompleteTaskNameFromUser());
                break;
            case "4":
                TasksLogic.DeleteTask(TasksConsole.DeleteTaskNameFromUser());
                break;
        }
    }
}