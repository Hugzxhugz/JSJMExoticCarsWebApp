using JSJMClientApplication.Interface;
using JSJMClientApplication.MenuState;

namespace JSJMClientApplication.Commands.MenuToggleCommand;

public class MoveToMainMenuCommand: ICommand
{
    public void Execute()
    {
        IMenuState mainMenu = new MainMenuState();
        mainMenu.DisplayMenu();
    }
}