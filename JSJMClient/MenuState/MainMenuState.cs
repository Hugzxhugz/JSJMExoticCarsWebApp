using JSJMClientApplication.Abstract;
using JSJMClientApplication.Commands;
using JSJMClientApplication.Commands.ApiCommands;
using JSJMClientApplication.Interface;

namespace JSJMClientApplication.MenuState;

public class MainMenuState : MenuStateFactory, IMenuState
{
   
    public MainMenuState()
    {
        _currentMenu = "Main Menu";
        _commands = new Dictionary<string, ICommand>();
        _optionsLists = new List<string>();
        
        _optionsLists.Add("1 - Get all Cars in the database.");
        _optionsLists.Add("2 - Get Car by ID.");
        _optionsLists.Add("3 - Update a Car in the database.");
        _optionsLists.Add("4 - Add a Car into the database.");
        _optionsLists.Add("5 - Delete a Car from the database.");
        _optionsLists.Add("6 - Quit the Client Application.");
        
        _commands.Add("1", new GetAllCarsCommand());
        _commands.Add("2", new GetCarByIdCommand());
        _commands.Add("3", new MoveToUpdateCarMenuCommand());
        _commands.Add("4", new MoveToAddCarMenuCommand());
        _commands.Add("5", new DeleteCarCommand());
        _commands.Add("6", new QuitApplicationCommand());
    }

    public void DisplayMenu()
    {
        string userInput = "";
        while (!userInput.Equals(_quitCommand))
        {
            Console.WriteLine($"{_currentMenu}:");
            Console.WriteLine("Please select an option");
            PrintOptions();
            ExecuteCommandIfExists();
           
            
        }
    }


}