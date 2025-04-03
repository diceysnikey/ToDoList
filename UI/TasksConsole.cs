using To_Do_List_Program.Logic;

namespace To_Do_List_Program.UI;

public static class TasksConsole
{
    public static void ShowAllCommands()
    {
        Console.Write("1. Show Tasks\n" +
                      "2. Add Task\n" +
                      "3. Complete Task\n" +
                      "4. Delete Task\n");
    }

    public static string ReadCommandFromUser()
    {
        var userCommand = Console.ReadLine();
        TasksLogic.CheckIfQuitIsPressed(userCommand);
        while (userCommand != "1" && userCommand != "2" && userCommand != "3" && userCommand != "4" 
               && string.IsNullOrEmpty(userCommand))
        {
            Console.WriteLine("Invalid Command! Enter a number from 1 to 4");
            userCommand = Console.ReadLine();
            TasksLogic.CheckIfQuitIsPressed(userCommand);
        }
        return userCommand;
    }
    public static void PrintRepeatToConsole()
    {
        Console.WriteLine($"\nRepeating... (Press 'Q' to quit)");
    }

    public static string AddTaskNameFromUser()
    {
        Console.WriteLine("What is your new task called?");
        var newTaskName = Console.ReadLine();
        TasksLogic.CheckIfQuitIsPressed(newTaskName);
        return CheckNullOrEmptyInput(newTaskName);
    }

    public static string AddTaskPriorityFromUser()
    {
        Console.WriteLine("What priority has it?");
        var newTaskPriority = CheckNullOrEmptyInput(Console.ReadLine()).ToUpper();
        TasksLogic.CheckIfQuitIsPressed(newTaskPriority);
        while (newTaskPriority != "HIGH" && newTaskPriority != "MEDIUM" && newTaskPriority != "LOW")
        {
            Console.WriteLine("You need to enter a valid priority name! (High, Medium, Low)");
            newTaskPriority = CheckNullOrEmptyInput(Console.ReadLine()).ToUpper();
            TasksLogic.CheckIfQuitIsPressed(newTaskPriority);
        }
        return newTaskPriority;
    }
    
    public static string CompleteTaskNameFromUser()
    {
        Console.WriteLine("What task did you complete?");
        var completedTaskName = Console.ReadLine();
        TasksLogic.CheckIfQuitIsPressed(completedTaskName);
        while (string.IsNullOrEmpty(completedTaskName))
        {
            Console.WriteLine("Enter the name of the task you completed!");
            completedTaskName = Console.ReadLine();
            TasksLogic.CheckIfQuitIsPressed(completedTaskName);
        }
        return completedTaskName;
    }

    public static string DeleteTaskNameFromUser()
    {
        Console.WriteLine("What task do you want to delete?");
        var deleteTaskName = Console.ReadLine();
        TasksLogic.CheckIfQuitIsPressed(deleteTaskName);
        while (string.IsNullOrEmpty(deleteTaskName))
        {
            Console.WriteLine("Enter the name of the task you want to delete!");
            deleteTaskName = Console.ReadLine();
            TasksLogic.CheckIfQuitIsPressed(deleteTaskName);
        }
        return deleteTaskName;
    }
    
    private static string CheckNullOrEmptyInput(string? userInput)
    {
        while (string.IsNullOrEmpty(userInput))
        {
            Console.WriteLine("Input is empty! Enter a valid input.");
            userInput = Console.ReadLine();
            TasksLogic.CheckIfQuitIsPressed(userInput);
        }
        return userInput;
    }

    public static void ShowWelcomeMessage()
    {
        Console.WriteLine("Welcome! Enter 'Q' at any time to exit. Exiting while performing an operation may cause the changes to not be saved.");
    }
}