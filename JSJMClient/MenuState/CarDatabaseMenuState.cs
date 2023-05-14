using JSJMClientApplication.Abstract;
using JSJMClientApplication.Commands;
using JSJMClientApplication.Commands.ApiCommands;
using JSJMClientApplication.Commands.MenuToggleCommand;
using JSJMClientApplication.Interface;

namespace JSJMClientApplication.MenuState;

public class CarDatabaseMenuState : MenuStateFactory, IMenuState
{
   
    public CarDatabaseMenuState()
    {
        _currentMenu = "Car Database Management Menu";
        _commands = new Dictionary<string, ICommand>();
        _optionsLists = new List<string>();
        
        _optionsLists.Add("1 - Get all Cars in the database.");
        _optionsLists.Add("2 - Get Car by ID.");
        _optionsLists.Add("3 - Update a Car in the database.");
        _optionsLists.Add("4 - Add a Car into the database.");
        _optionsLists.Add("5 - Delete a Car from the database.");
        _optionsLists.Add("6 - Return to the Main menu.");
        _optionsLists.Add("7 - Quit the Client Application.");
        
        _commands.Add("1", new GetAllCarsCommand());
        _commands.Add("2", new GetCarByIdCommand());
        _commands.Add("3", new MoveToUpdateCarMenuCommand());
        _commands.Add("4", new MoveToAddCarMenuCommand());
        _commands.Add("5", new DeleteCarCommand());
        _commands.Add("6", new MoveToMainMenuCommand());
        _commands.Add("7", new QuitApplicationCommand());
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