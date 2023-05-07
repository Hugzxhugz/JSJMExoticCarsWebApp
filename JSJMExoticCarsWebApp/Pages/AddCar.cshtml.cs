using System.Text.Json;
using JSJMExoticCarsWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;



namespace JSJMExoticCarsWebApp.Pages;

public class addCarModel : PageModel
{
    CarDbContext dbc;

    public addCarModel(CarDbContext dbc)
    {
        this.dbc = dbc;
    }

    [BindProperty]
    public Car car { get; set; }

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (ModelState.IsValid)
        {
            dbc.Cars.Add(car);
            dbc.SaveChanges();

            return RedirectToPage("/Market");
        }
        
        return Page();
    }
}

