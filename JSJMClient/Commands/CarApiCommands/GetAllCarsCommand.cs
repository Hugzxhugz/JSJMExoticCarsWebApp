using JSJMClientApplication.Interface;

namespace JSJMClientApplication.Commands.ApiCommands;

public class GetAllCarsCommand : ICommand
{
    private readonly CarApiClientOperations _carApiClient;

    public GetAllCarsCommand()
    {
        _carApiClient = new CarApiClientOperations();
    }
    public void Execute()
    {
        Console.WriteLine($"\nData entries:");
        _carApiClient.GetCars().GetAwaiter().GetResult();
    }
}