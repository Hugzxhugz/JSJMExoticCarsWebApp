using JSJMClientApplication.Interface;
using JSJMClientApplication.MenuState;

namespace JSJMClientApplication.Commands;

public class MoveToUpdateCarMenuCommand : ICommand
{
    private readonly CarBuilder _carBuilder;
    private readonly CarApiClientOperations _carApiClient;

    public MoveToUpdateCarMenuCommand()
    {
        _carBuilder = new CarBuilder();
        _carApiClient = new CarApiClientOperations();
    }
    public void Execute()
    {
        IMenuState updateCarMenu = new UpdateCarMenuState();
        updateCarMenu.DisplayMenu();
    }
}