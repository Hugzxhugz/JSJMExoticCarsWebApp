using System;
using JSJMClientApplication.Interface;

namespace JSJMClientApplication.MenuState
{
    public class UpdateCarMenuState : IMenuState
    {
        private readonly CarApiClientOperations _carApiClient;
        private readonly UpdateCarBuilder _updateCarBuilder;

        public UpdateCarMenuState()
        {
            _carApiClient = new CarApiClientOperations();
            _updateCarBuilder = new UpdateCarBuilder();
        }

        public void DisplayMenu()
        {
            _carApiClient.UpdateCar().GetAwaiter().GetResult();
        }
    }
}