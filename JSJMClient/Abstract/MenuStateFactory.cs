using JSJMClientApplication.Interface;

namespace JSJMClientApplication.Abstract;

public class MenuStateFactory : IMenuState
{
    protected string _currentMenu;
    protected Dictionary<string, ICommand> _commands;
    protected string _quitCommand = "quit";
    protected List<string> _optionsLists;
    
    public void DisplayMenu()
    {
    }
    
    public void ExecuteCommandIfExists()
    {
        string userInput = Console.ReadLine();
        if (_commands.ContainsKey(userInput))
        {
            ICommand command = _commands[userInput];
            command.Execute();
        }
        else
        {
            Console.WriteLine("Invalid option. Please choose according to the list.");
        }
        Console.WriteLine();
    }
    
    public void PrintOptions()
    {
        foreach (string option in _optionsLists)
        {
            Console.WriteLine(option);
        }
    }

}