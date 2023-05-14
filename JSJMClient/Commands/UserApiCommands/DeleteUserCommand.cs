using JSJMClientApplication.Interface;

namespace JSJMClientApplication.Commands.ApiCommands;

public class DeleteUserCommand : ICommand
{
    private readonly UserApiClientOperations _userApiClient;

    public DeleteUserCommand()
    {
        _userApiClient = new UserApiClientOperations();
    }

    public void Execute()
    {
        _userApiClient.DeleteUser().GetAwaiter().GetResult();
    }
}