using System.Text.Json;
using JSJMExoticCarsWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;



namespace JSJMExoticCarsWebApp.Pages;

public class addCar : PageModel
{
    CarDbContext carDbContext;

    [BindProperty]
    public Car Car { get; set; }

    public addCar(CarDbContext carDbContext)
    {
        this.carDbContext = carDbContext;
    }
    public void OnGet()
    {
        
    }

    public ActionResult OnPost()
    {
        if (ModelState.IsValid)
        {
            Car.Listed = true;
            carDbContext.Cars.Add(Car);
            carDbContext.SaveChanges();
            return RedirectToPage("/Market");
        }
        return Page();
    }
}

