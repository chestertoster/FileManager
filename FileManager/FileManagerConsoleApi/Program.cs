using FileManagerCommands;

class Program
{
    static void Main()
    {
        Manager manager = new Manager();

        while(true)
        {
            Console.Write(manager.RelativePath + " > ");
            string command = Console.ReadLine();
            if(!ConsoleCommandExecute(command))
                Console.WriteLine(manager.ExecuteCommand(command));
        }
    }

    //Определяет какую комманду нужно вызвать
    static bool ConsoleCommandExecute(string commandName)
    {
        switch (commandName)
        {
            case "exit":
                Environment.Exit(0);
                return true;
            case "clear":
                Console.Clear();
                return true;
            default:
                return false;
        }        
    }
}