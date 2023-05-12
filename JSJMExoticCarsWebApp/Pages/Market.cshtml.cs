using JSJMExoticCarsWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JSJMExoticCarsWebApp.Pages
{
    public class MarketModel : PageModel
    {
        public string ErrorMessage { get; set; }
        CarDbContext CarDbContext { get; set; }
        public MarketModel(CarDbContext cardb)
        {
            CarDbContext= cardb;
            Cars = CarDbContext.Cars.ToList();
        }

        public List<Car> Cars { get; set; }



        public void OnGet()
        {
            
        }

        public ActionResult OnPostAddCarPage()
        {
            if(HttpContext.Session.Get("UserSession") == null)
            {
                ErrorMessage = "You can't add a car if you are not signed in";
                return Page();
            }

            return RedirectToPage("/AddCar");
        }
    }
}