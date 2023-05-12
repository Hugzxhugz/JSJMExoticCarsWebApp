using System.Text.Json;
using JSJMExoticCarsWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;



namespace JSJMExoticCarsWebApp.Pages;

public class AddCar : PageModel
{
    CarDbContext carDbContext;

    [BindProperty]
    public Car Car { get; set; }

    public AddCar(CarDbContext carDbContext)
    {
        this.carDbContext = carDbContext;
    }
    public void OnGet()
    {
        
    }

    public ActionResult OnPost()
    {
        if (HttpContext.Session.Get("UserSession") == null) return RedirectToPage("/MyAccount");

        if (ModelState.IsValid) return Page();

        Car.Listed = true;
        carDbContext.Cars.Add(Car);
        carDbContext.SaveChanges();
        return RedirectToPage("/Market");
        
        
    }
}

