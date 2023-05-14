using JSJMClientApplication.Interface;

namespace JSJMClientApplication.Commands.ApiCommands;

public class DeleteCarCommand : ICommand
{
    private readonly CarApiClientOperations _carApiClient;

    public DeleteCarCommand()
    {
        _carApiClient = new CarApiClientOperations();
    }

    public void Execute()
    {
        _carApiClient.DeleteCar().GetAwaiter().GetResult();
    }
}