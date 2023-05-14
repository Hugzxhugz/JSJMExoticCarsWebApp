using JSJMClientApplication.Abstract;
using JSJMClientApplication.Commands.ApiCommands;
using JSJMClientApplication.Commands.MenuToggleCommand;
using JSJMClientApplication.Interface;

namespace JSJMClientApplication.MenuState;

public class MainMenuState : MenuStateFactory, IMenuState
{
    public MainMenuState()
    {
        _currentMenu = "Main Menu";
        _commands = new Dictionary<string, ICommand>();
        _optionsLists = new List<string>();
        
        _optionsLists.Add("1 - Car Database Management");
        _optionsLists.Add("2 - User Database Management");
        _optionsLists.Add("3 - Quit the Client Application.");
        
        _commands.Add("1", new MoveToCarDatabaseMenuCommand());
        _commands.Add("2", new MoveToUserDatabaseMenuCommand());
        _commands.Add("3", new QuitApplicationCommand());
    }
    
    public void DisplayMenu()
    {
        string userInput = "";
        while (!userInput.Equals(_quitCommand))
        {
            Console.WriteLine($"{_currentMenu}:");
            Console.WriteLine("Please select an option:");
            PrintOptions();
            ExecuteCommandIfExists();
        }
    }
}