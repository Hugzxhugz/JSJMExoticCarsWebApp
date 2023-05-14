using JSJMClientApplication.Abstract;
using JSJMClientApplication.Interface;

namespace JSJMClientApplication.MenuState
{
    public class AddNewUserMenuState : MenuStateFactory, IMenuState
    {
        private readonly UserBuilder _userBuilder;
        private readonly UserApiClientOperations _userApiClient;

        public AddNewUserMenuState()
        {
            _currentMenu = "Add New User Menu";
            _userBuilder = new UserBuilder();
            _userApiClient = new UserApiClientOperations();
        }

        public void DisplayMenu()
        {
            User newUser = _userBuilder.CreateUser();

            _userApiClient.AddUser(newUser).GetAwaiter().GetResult();
            Console.WriteLine("Successfully added user.");
        }
    }
}