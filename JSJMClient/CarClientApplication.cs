using JSJMClientApplication.MenuState;

namespace JSJMClientApplication;

public class CarClientApplication
{
    public CarClientApplication()
    {
        
    }

    public void Run()
    {
        MenuContext menuContext = new MenuContext();
        menuContext.setState(new MainMenuState());
        Console.WriteLine("Welcome to JSJM Exotic Cars Client Application");
        menuContext.DisplayMenu();
       
    }
}