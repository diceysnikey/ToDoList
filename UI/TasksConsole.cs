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
        while (userCommand != "1" && userCommand != "2" && userCommand != "3" && userCommand != "4" 
               && string.IsNullOrEmpty(userCommand))
        {
            Console.WriteLine("Invalid Command! Enter a number from 1 to 4");
            userCommand = Console.ReadLine();
        }
        return userCommand;
    }
    public static string ReadRepeatFromUser()
    {
        Console.WriteLine("Do you want to repeat the program? (Y/N): ");
        var userInput = Console.ReadLine();
        userInput = CheckNullInput(userInput).ToUpper();
        
        return userInput;
    }

    public static string AddTaskNameFromUser()
    {
        Console.WriteLine("What is your new task called?");
        var newTaskName = Console.ReadLine();
        while (string.IsNullOrEmpty(newTaskName))
        {
            Console.WriteLine("Enter the name of the task you want to add!");
            newTaskName = Console.ReadLine();
        }
        return newTaskName;
    }

    public static string CompleteTaskNameFromUser()
    {
        Console.WriteLine("What task did you complete?");
        var completedTaskName = Console.ReadLine();
        while (string.IsNullOrEmpty(completedTaskName))
        {
            Console.WriteLine("Enter the name of the task you completed!");
            completedTaskName = Console.ReadLine();
        }
        return completedTaskName;
    }

    public static string DeleteTaskNameFromUser()
    {
        Console.WriteLine("What task do you want to delete?");
        var deleteTaskName = Console.ReadLine();
        while (string.IsNullOrEmpty(deleteTaskName))
        {
            Console.WriteLine("Enter the name of the task you want to delete!");
            deleteTaskName = Console.ReadLine();
        }
        return deleteTaskName;
    }
    
    private static string CheckNullInput(string? userInput)
    {
        while (string.IsNullOrEmpty(userInput))
        {
            Console.WriteLine("Input is empty! Enter a valid input.");
            userInput = Console.ReadLine();
        }
        return userInput;
    }
    
}