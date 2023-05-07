using JSJMExoticCarsWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JSJMExoticCarsWebApp.Pages
{
    public class MarketModel : PageModel
    {

        CarDbContext CarDbContext { get; set; }
        public MarketModel(CarDbContext cardb)
        {
            CarDbContext= cardb;
        }

        public List<Car> Cars { get; set; }

        public void OnGet()
        {
            Cars = CarDbContext.Cars.ToList();
        }
    }
}