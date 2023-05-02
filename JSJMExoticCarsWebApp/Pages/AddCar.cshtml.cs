using System.Text.Json;
using JSJMExoticCarsWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;



namespace JSJMExoticCarsWebApp.Pages;

public class addCar : PageModel
{
    
    private const string JsonFileName = "cars.json";
    
    [BindProperty]
    public Car Car { get; set; }
    
    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (ModelState.IsValid)
        {
            // Read the existing JSON file
            var cars = new List<Car>();
            if (System.IO.File.Exists(JsonFileName))
            {
                var json = System.IO.File.ReadAllText(JsonFileName);
                cars = JsonSerializer.Deserialize<List<Car>>(json);
            }

            // Add the new car to the list
            cars.Add(Car);

            // Write the updated JSON file
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            var jsonString = JsonSerializer.Serialize(cars, options);
            System.IO.File.WriteAllText(JsonFileName, jsonString);

            // Redirect to the index page
            return RedirectToPage("/Index");
        }
        return Page();
    }
}

