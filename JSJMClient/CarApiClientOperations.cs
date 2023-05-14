using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace JSJMClientApplication;

public class CarApiClientOperations
{
    private readonly HttpClient _httpClient;

    public CarApiClientOperations()
    {
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7133/api/")
        };
    }

    public async Task GetCars()
    {
        var response = await _httpClient.GetAsync("car/get");
        if (response.IsSuccessStatusCode)
        {
            var cars = await response.Content.ReadAsAsync<List<Car>>();
            foreach (var car in cars)
            { 
                Console.WriteLine($"ID: {car.Id}");
                Console.WriteLine($"Car Model: {car.Model}");
                Console.WriteLine($"Car Brand: {car.Brand}");
                Console.WriteLine($"Year Model: {car.ModelYear}");
                Console.WriteLine($"Mileage: {car.Mileage}");
                Console.WriteLine($"Description: {car.Description}");
                Console.WriteLine($"Transmission Type: {car.Transmission}");
                Console.WriteLine($"Fuel Type: {car.Fuel}");
                Console.WriteLine($"Listed: {car.Listed}");
                Console.WriteLine($"Price: {car.Price}");
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine($"Failed to retrieve cars. Error: {response.ReasonPhrase}");
        }
    }

    public async Task GetCar()
    {
        Console.WriteLine("Enter the ID of the car to retrieve:");
        string userInput = Console.ReadLine();

        if (int.TryParse(userInput, out int id))
        {
            var response = await _httpClient.GetAsync($"car/get/{id}");
            if (response.IsSuccessStatusCode)
            {
                var car = await response.Content.ReadAsAsync<Car>();
                Console.WriteLine($"ID: {car.Id}");
                Console.WriteLine($"Car Brand: {car.Brand}");
                Console.WriteLine($"Car Model: {car.Model}");
                Console.WriteLine($"Year Model: {car.ModelYear}");
                Console.WriteLine($"Mileage: {car.Mileage}");
                Console.WriteLine($"Description: {car.Description}");
                Console.WriteLine($"Transmission Type: {car.Transmission}");
                Console.WriteLine($"Fuel Type: {car.Fuel}");
                Console.WriteLine($"Listed: {car.Listed}");
                Console.WriteLine($"Price: {car.Price}");
                Console.WriteLine();
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                Console.WriteLine($"Car with ID {id} not found.");
            }
            else
            {
                Console.WriteLine($"Failed to retrieve the car. Error: {response.ReasonPhrase}");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID. Please enter a valid integer ID.");
        }
    }
    
    public async Task AddCar(Car car)
    {
        var response = await _httpClient.PostAsJsonAsync("car/post", car);
        if (response.IsSuccessStatusCode)
        {
            var createdCar = await response.Content.ReadAsAsync<Car>();
            Console.WriteLine($"Car with ID {createdCar.Id} has been created.");
        }
        else
        {
            Console.WriteLine($"Failed to add the car. Error: {response.ReasonPhrase}");
        }
    }

    public async Task DeleteCar()
    {
        Console.WriteLine("Enter the ID of the car to delete:");
        string userInput = Console.ReadLine();

        if (int.TryParse(userInput, out int id))
        {
            var response = await _httpClient.DeleteAsync($"car/delete/{id}");
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Car with ID {id} has been deleted.");
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                Console.WriteLine($"Car with ID {id} not found.");
            }
            else
            {
                Console.WriteLine($"Failed to delete the car. Error: {response.ReasonPhrase}");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID. Please enter a valid integer ID.");
        }
    }

    
    public async Task UpdateCar()
    {
        Console.WriteLine("Enter the ID of the car to update:");
        string userInput = Console.ReadLine();

        if (int.TryParse(userInput, out int id))
        {
            var existingCarResponse = await _httpClient.GetAsync($"car/get/{id}");
            if (existingCarResponse.IsSuccessStatusCode)
            {
                var existingCar = await existingCarResponse.Content.ReadAsAsync<Car>();
                var updateCarBuilder = new UpdateCarBuilder();
                updateCarBuilder.UpdateCar(existingCar);

                var jsonContent = new StringContent(JsonConvert.SerializeObject(existingCar), Encoding.UTF8, "application/json");
                var updateCarResponse = await _httpClient.PutAsync($"car/put/{id}", jsonContent);

                if (updateCarResponse.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Car with ID {id} has been updated.");
                }
                else if (updateCarResponse.StatusCode == HttpStatusCode.NotFound)
                {
                    Console.WriteLine($"Car with ID {id} not found.");
                }
                else
                {
                    Console.WriteLine($"Failed to update the car. Error: {updateCarResponse.ReasonPhrase}");
                }
            }
            else if (existingCarResponse.StatusCode == HttpStatusCode.NotFound)
            {
                Console.WriteLine($"Car with ID {id} not found.");
            }
            else
            {
                Console.WriteLine($"Failed to retrieve the car. Error: {existingCarResponse.ReasonPhrase}");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID. Please enter a valid integer ID.");
        }
    }

}
