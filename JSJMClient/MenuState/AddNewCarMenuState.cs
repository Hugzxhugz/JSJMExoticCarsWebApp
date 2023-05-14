using JSJMClientApplication.Abstract;
using JSJMClientApplication.Interface;

namespace JSJMClientApplication.MenuState
{
    public class AddNewCarMenuState : MenuStateFactory, IMenuState
    {
        private readonly CarBuilder _carBuilder;
        private readonly CarApiClientOperations _carApiClient;

        public AddNewCarMenuState()
        {
            _currentMenu = "Add New Car Menu";
            _carBuilder = new CarBuilder();
            _carApiClient = new CarApiClientOperations();
        }

        public void DisplayMenu()
        {
            Car newCar = _carBuilder.CreateCar();

            _carApiClient.AddCar(newCar).GetAwaiter().GetResult();
            Console.WriteLine("Successfully added car.");
        }
    }
}