namespace JSJMClientApplication;

public class UpdateCarBuilder
{
    private GetInputClass _getInputClass = new GetInputClass();
        
    public void UpdateCarModel(Car car)
    {
        string carModel = _getInputClass.GetString("Please enter the updated car model:");
        car.Model = carModel;
    }
        
    public void UpdateCarBrand(Car car)
    {
        string carBrand = _getInputClass.GetString("Please enter the updated car brand:");
        car.Brand = carBrand;
    }
        
    public void UpdateCarYearModel(Car car)
    {
        int yearModel = _getInputClass.GetInt("Please enter the updated year model:");
        car.ModelYear = yearModel;
    }
        
    public void UpdateCarMileage(Car car)
    {
        int mileage = _getInputClass.GetInt("Please enter the updated mileage:");
        car.Mileage = mileage;
    }
    public void UpdateCarDescription(Car car)
    {
        string description = _getInputClass.GetString("Please enter the updated car description:");
        car.Description = description;
    }
        
    public void UpdateCarTransmissionType(Car car)
    {
        int transmissionInput = _getInputClass.GetInt("Please enter the updated transmission type (0 for manual, 1 for automatic):");

        while (transmissionInput < 0 || transmissionInput > 1)
        {
            Console.WriteLine("Invalid input. Please enter a value between 0 and 1.");
            transmissionInput = _getInputClass.GetInt("Please enter the updated transmission type (0 for manual, 1 for automatic):");
        }

        car.Transmission = (TransmissionType)transmissionInput;
    }
        
    public void UpdateCarFuelType(Car car)
    {
        int fuelInput = _getInputClass.GetInt("Please enter the updated fuel type (0 for Gas, 1 for Diesel, 2 for Hybrid, 3 for Electric):");

        while (fuelInput < 0 || fuelInput > 3)
        {
            Console.WriteLine("Invalid input. Please enter a value between 0 and 3.");
            fuelInput = _getInputClass.GetInt("Please enter the updated fuel type (0 for Gas, 1 for Diesel, 2 for Hybrid, 3 for Electric):");
        }

        car.Fuel = (FuelType)fuelInput;
    }
        
    public void UpdateCarPrice(Car car)
    {
        int price = _getInputClass.GetInt("Please enter the updated car price:");
        car.Price = price;
    }
    
    public void UpdateCar(Car car)
    {
        Console.WriteLine("Select the field you want to update:");
        Console.WriteLine("1. Car Model");
        Console.WriteLine("2. Car Brand");
        Console.WriteLine("3. Year Model");
        Console.WriteLine("4. Mileage");
        Console.WriteLine("5. Description");
        Console.WriteLine("6. Transmission Type");
        Console.WriteLine("7. Fuel Type");
        Console.WriteLine("8. Price");
        int choice = _getInputClass.GetInt("Enter your choice:");

        switch (choice)
        {
            case 1:
                UpdateCarModel(car);
                break;
            case 2:
                UpdateCarBrand(car);
                break;
            case 3:
                UpdateCarYearModel(car);
                break;
            case 4:
                UpdateCarMileage(car);
                break;
            case 5:
                UpdateCarDescription(car);
                break;
            case 6:
                UpdateCarTransmissionType(car);
                break;
            case 7:
                UpdateCarFuelType(car);
                break;
            case 8:
                UpdateCarPrice(car);
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }
}
