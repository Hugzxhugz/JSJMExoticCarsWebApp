using JSJMClientApplication.Interface;
using JSJMClientApplication.MenuState;

namespace JSJMClientApplication.Commands.MenuToggleCommand;

public class MoveToCarDatabaseMenuCommand: ICommand
{
    public void Execute()
    {
        IMenuState carDatabaseMenu = new CarDatabaseMenuState();
        carDatabaseMenu.DisplayMenu();
    }
}