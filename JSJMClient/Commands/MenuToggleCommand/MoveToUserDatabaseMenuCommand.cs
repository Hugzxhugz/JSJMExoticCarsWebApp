using JSJMClientApplication.Interface;
using JSJMClientApplication.MenuState;

namespace JSJMClientApplication.Commands.MenuToggleCommand;

public class MoveToUserDatabaseMenuCommand: ICommand
{
    public void Execute()
    {
        IMenuState userDatabaseMenu = new UserDatabaseMenuState();
        userDatabaseMenu.DisplayMenu();
    }
}