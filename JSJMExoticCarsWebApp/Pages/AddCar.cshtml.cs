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
    public ActionResult OnGet()
    {
		byte[] userSessionBytes = HttpContext.Session.Get("UserSession");
		if (userSessionBytes == null) return RedirectToPage("/SignIn");
		return Page();
	}

    public ActionResult OnPost()
    {
        if (!ModelState.IsValid) return Page();

		Car.Listed = true;

        UserSession session = UserSession.ConvertBytesToUserSession(HttpContext.Session.Get("UserSession"));

        if (session == null) return RedirectToPage("/SignIn");

        session.Cars.Add(Car);

        UserSession.UpdateUser(session, carDbContext);

        HttpContext.Session.Set("UserSession", UserSession.ConvertUserSessionToBytes(session));

		
        return RedirectToPage("/Market");
    }
}

