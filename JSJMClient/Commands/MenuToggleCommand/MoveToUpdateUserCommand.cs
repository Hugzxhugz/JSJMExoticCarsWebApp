using JSJMClientApplication.Interface;
using JSJMClientApplication.MenuState;

namespace JSJMClientApplication.Commands;

public class MoveToUpdateUserCommand : ICommand
{
    private readonly UserBuilder _userBuilder;
    private readonly UserApiClientOperations _userApiClient;

    public MoveToUpdateUserCommand()
    {
        _userBuilder = new UserBuilder();
        _userApiClient = new UserApiClientOperations();
    }
    public void Execute()
    {
        IMenuState updateUserMenu = new UpdateUserMenuState();
        updateUserMenu.DisplayMenu();
    }
}