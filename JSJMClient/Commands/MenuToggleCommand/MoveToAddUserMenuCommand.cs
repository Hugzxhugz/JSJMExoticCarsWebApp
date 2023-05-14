using JSJMClientApplication.Interface;
using JSJMClientApplication.MenuState;

namespace JSJMClientApplication.Commands;

public class MoveToAddUserMenuCommand : ICommand
{
    private readonly UserBuilder _userBuilder;
    private readonly UserApiClientOperations _userApiClient;

    public MoveToAddUserMenuCommand()
    {
        _userBuilder = new UserBuilder();
        _userApiClient = new UserApiClientOperations();
    }
    public void Execute()
    {
        IMenuState addUserMenu = new AddNewUserMenuState();
        addUserMenu.DisplayMenu();
    }
}