using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace JSJMClientApplication;

public class UserApiClientOperations
{
    private readonly HttpClient _httpClient;

    public UserApiClientOperations()
    {
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7133/api/")
        };
    }
    
    public async Task GetUsers()
    {
        var response = await _httpClient.GetAsync("user/get");
        if (response.IsSuccessStatusCode)
        {
            var users = await response.Content.ReadAsAsync<List<User>>();
            foreach (var user in users)
            { 
                Console.WriteLine($"ID: {user.Id}");
                Console.WriteLine($"Name: {user.Name}");
                Console.WriteLine($"Password: {user.Password}");
                Console.WriteLine($"Funds: {user.Funds}");
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine($"Failed to retrieve users. Error: {response.ReasonPhrase}");
        }
    }
    
    public async Task GetUser()
    {
        Console.WriteLine("Enter the ID of the user to retrieve:");
        string userInput = Console.ReadLine();

        if (int.TryParse(userInput, out int id))
        {
            var response = await _httpClient.GetAsync($"user/get/{id}");
            if (response.IsSuccessStatusCode)
            {
                var user = await response.Content.ReadAsAsync<User>();
                Console.WriteLine($"ID: {user.Id}");
                Console.WriteLine($"Name: {user.Name}");
                Console.WriteLine($"Password: {user.Password}");
                Console.WriteLine($"Funds: {user.Funds}");
                Console.WriteLine();
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                Console.WriteLine($"User with ID {id} not found.");
            }
            else
            {
                Console.WriteLine($"Failed to retrieve the user. Error: {response.ReasonPhrase}");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID. Please enter a valid integer ID.");
        }
    }
    
    public async Task AddUser(User user)
    {
        var response = await _httpClient.PostAsJsonAsync("user/post", user);
        if (response.IsSuccessStatusCode)
        {
            var createdUser = await response.Content.ReadAsAsync<User>();
            Console.WriteLine($"User with ID {createdUser.Id} has been created.");
        }
        else
        {
            Console.WriteLine($"Failed to add the user. Error: {response.ReasonPhrase}");
        }
    }
    
    public async Task DeleteUser()
    {
        Console.WriteLine("Enter the ID of the user to delete:");
        string userInput = Console.ReadLine();

        if (int.TryParse(userInput, out int id))
        {
            var response = await _httpClient.DeleteAsync($"user/delete/{id}");
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine($"User with ID {id} has been deleted.");
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                Console.WriteLine($"User with ID {id} not found.");
            }
            else
            {
                Console.WriteLine($"Failed to delete the user. Error: {response.ReasonPhrase}");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID. Please enter a valid integer ID.");
        }
    }
    
    public async Task UpdateUser()
    {
        Console.WriteLine("Enter the ID of the user to update:");
        string userInput = Console.ReadLine();

        if (int.TryParse(userInput, out int id))
        {
            var existingUserResponse = await _httpClient.GetAsync($"user/get/{id}");
            if (existingUserResponse.IsSuccessStatusCode)
            {
                var existingUser = await existingUserResponse.Content.ReadAsAsync<User>();
                var updateUserBuilder = new UpdateUserBuilder();
                updateUserBuilder.UpdateUser(existingUser);

                var jsonContent = new StringContent(JsonConvert.SerializeObject(existingUser), Encoding.UTF8, "application/json");
                var updateUserResponse = await _httpClient.PutAsync($"user/put/{id}", jsonContent);

                if (updateUserResponse.IsSuccessStatusCode)
                {
                    Console.WriteLine($"User with ID {id} has been updated.");
                }
                else if (updateUserResponse.StatusCode == HttpStatusCode.NotFound)
                {
                    Console.WriteLine($"User with ID {id} not found.");
                }
                else
                {
                    Console.WriteLine($"Failed to update the user. Error: {updateUserResponse.ReasonPhrase}");
                }
            }
            else if (existingUserResponse.StatusCode == HttpStatusCode.NotFound)
            {
                Console.WriteLine($"User with ID {id} not found.");
            }
            else
            {
                Console.WriteLine($"Failed to retrieve the user. Error: {existingUserResponse.ReasonPhrase}");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID. Please enter a valid integer ID.");
        }
    }
    
}