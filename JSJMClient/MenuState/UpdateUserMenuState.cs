using System;
using JSJMClientApplication.Interface;

namespace JSJMClientApplication.MenuState
{
    public class UpdateUserMenuState : IMenuState
    {
        private readonly UserApiClientOperations _userApiClient;
        private readonly UpdateUserBuilder _updateUserBuilder;

        public UpdateUserMenuState()
        {
            _userApiClient = new UserApiClientOperations();
            _updateUserBuilder = new UpdateUserBuilder();
        }

        public void DisplayMenu()
        {
            _userApiClient.UpdateUser().GetAwaiter().GetResult();
        }
    }
}