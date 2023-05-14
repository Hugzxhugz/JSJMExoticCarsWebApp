using JSJMClientApplication.Interface;
using JSJMClientApplication.MenuState;

namespace JSJMClientApplication.Commands;

public class MoveToAddCarMenuCommand : ICommand
{
    private readonly CarBuilder _carBuilder;
    private readonly CarApiClientOperations _carApiClient;

    public MoveToAddCarMenuCommand()
    {
        _carBuilder = new CarBuilder();
        _carApiClient = new CarApiClientOperations();
    }
    public void Execute()
    {
        IMenuState addCarMenu = new AddNewCarMenuState();
        addCarMenu.DisplayMenu();
    }
}