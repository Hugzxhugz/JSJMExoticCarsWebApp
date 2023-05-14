using JSJMClientApplication.Abstract;
using JSJMClientApplication.Commands;
using JSJMClientApplication.Commands.ApiCommands;
using JSJMClientApplication.Commands.MenuToggleCommand;
using JSJMClientApplication.Interface;

namespace JSJMClientApplication.MenuState;

public class UserDatabaseMenuState : MenuStateFactory, IMenuState
{
   
    public UserDatabaseMenuState()
    {
        _currentMenu = "User Database Management Menu";
        _commands = new Dictionary<string, ICommand>();
        _optionsLists = new List<string>();
        
        _optionsLists.Add("1 - Get all Users in the database.");
        _optionsLists.Add("2 - Get User by ID.");
        _optionsLists.Add("3 - Update a User in the database.");
        _optionsLists.Add("4 - Add a User into the database.");
        _optionsLists.Add("5 - Delete a User from the database.");
        _optionsLists.Add("6 - Return to the Main menu.");
        _optionsLists.Add("7 - Quit the Client Application.");
        
        _commands.Add("1", new GetAllUsersCommand());
        _commands.Add("2", new GetUserByIdCommand());
        _commands.Add("3", new MoveToUpdateUserCommand());
        _commands.Add("4", new MoveToAddUserMenuCommand());
        _commands.Add("5", new DeleteUserCommand());
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