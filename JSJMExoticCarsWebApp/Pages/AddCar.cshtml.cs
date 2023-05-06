using System.Text.Json;
using JSJMExoticCarsWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;



namespace JSJMExoticCarsWebApp.Pages;

public class addCarModel : PageModel
{
    DatabaseContext dbc;

    public addCarModel(DatabaseContext dbc)
    {
        this.dbc = dbc;
    }
    [BindProperty]
    public Car car { get; set; }
    public void OnGet()
    {
    }

    public void OnPost()
    {
        if(ModelState.IsValid)
        {
            dbc.Cars.Add(car);
            dbc.SaveChanges();
        }
    }
}

