using JSJMClientApplication.Interface;

namespace JSJMClientApplication.Commands.ApiCommands;

public class UpdateCarCommand : ICommand
{
    private readonly CarApiClientOperations _carApiClient;
    private readonly int _id;
    private readonly Car _updatedCar;

    

    public void Execute()
    {
        _carApiClient.UpdateCar().GetAwaiter().GetResult();
    }
}