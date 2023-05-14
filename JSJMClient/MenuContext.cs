using JSJMClientApplication.Interface;

namespace JSJMClientApplication;

public class MenuContext
{
    private IMenuState _menuState;
    public static MenuContext instance;

    public MenuContext()
    {
        
    }

    public void setState(IMenuState state) {
        this._menuState = state;
    }
    public static MenuContext GetInstance()
    {
        if (instance == null)
        {
            instance = new MenuContext();
        }
        return instance;
    }
    
    public void DisplayMenu() {
        // display the current state's menu
        _menuState.DisplayMenu();
    }
}