using System.Net.NetworkInformation;
using System.Text.Json;
using JSJMExoticCarsWebApp.Models;
using JSJMExoticCarsWebApp.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;




namespace JSJMExoticCarsWebApp.Pages;

public class addCarModel : PageModel
{
    CarDbContext dbc;
    
    [BindProperty]
    public Car car { get; set; }

    public addCarModel(CarDbContext dbc)
    {
        this.dbc = dbc;
    }

    

    public void OnGet()
    {
        car = new Car();
    }

    public IActionResult OnPost()
    {
        if (ModelState.IsValid)
        {
            dbc.Cars.Add(car);
            int result = dbc.SaveChanges();

            if (result > 0)
            {
                TempData["Message"] = "Car added successfully!";
                return RedirectToPage("/Market");
            }
            else
            {
                TempData["Message"] = "Error adding car.";
            }
        }

        return Page();
    }

}

