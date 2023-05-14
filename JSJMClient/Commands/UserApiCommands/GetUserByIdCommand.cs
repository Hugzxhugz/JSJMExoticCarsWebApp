using JSJMClientApplication.Interface;

namespace JSJMClientApplication.Commands.ApiCommands;

public class GetUserByIdCommand : ICommand
{
    private readonly UserApiClientOperations _userApiClient;

    public GetUserByIdCommand()
    {
        _userApiClient = new UserApiClientOperations();
    }
    public void Execute()
    {
        _userApiClient.GetUser().GetAwaiter().GetResult();
    }
}