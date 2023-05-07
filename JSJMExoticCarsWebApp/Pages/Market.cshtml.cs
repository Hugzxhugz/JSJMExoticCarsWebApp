using JSJMExoticCarsWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JSJMExoticCarsWebApp.Pages
{
    public class MarketModel : PageModel
    {
        CarDbContext dbc;

        public MarketModel(CarDbContext dbc)
        {
            this.dbc = dbc;
        }
        public List<Car> cars { get; set; }
        public void OnGet()
        {
            cars = dbc.Cars.ToList();
        }
    }
}