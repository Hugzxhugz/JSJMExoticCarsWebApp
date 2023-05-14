using JSJMClientApplication.Interface;

namespace JSJMClientApplication.Commands.ApiCommands;

public class QuitApplicationCommand : ICommand
{
    public void Execute()
    {
        Console.WriteLine("Closing the Client Application...");
        Environment.Exit(0);
    }
}