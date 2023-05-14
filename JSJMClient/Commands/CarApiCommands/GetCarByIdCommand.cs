using JSJMClientApplication.Interface;

namespace JSJMClientApplication.Commands.ApiCommands;

public class GetCarByIdCommand : ICommand
{
    private readonly CarApiClientOperations _carApiClient;

    public GetCarByIdCommand()
    {
        _carApiClient = new CarApiClientOperations();
    }
    public void Execute()
    {
        _carApiClient.GetCar().GetAwaiter().GetResult();
    }
}