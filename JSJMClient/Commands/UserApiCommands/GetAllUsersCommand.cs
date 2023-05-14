using JSJMClientApplication.Interface;

namespace JSJMClientApplication.Commands.ApiCommands;

public class GetAllUsersCommand : ICommand
{
    private readonly UserApiClientOperations _userApiClient;

    public GetAllUsersCommand()
    {
        _userApiClient = new UserApiClientOperations();
    }
    public void Execute()
    {
        Console.WriteLine($"\nData entries:");
        _userApiClient.GetUsers().GetAwaiter().GetResult();
    }
}