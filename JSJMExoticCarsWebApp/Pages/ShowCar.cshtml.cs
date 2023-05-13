using JSJMExoticCarsWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace JSJMExoticCarsWebApp.Pages
{
    public class ShowCarModel : PageModel
    {
        CarDbContext dbc;

        public ShowCarModel(CarDbContext dbc)
        {
            this.dbc = dbc;
        }

        public Car Car { get; set; }

        public ActionResult OnGet(int? id)
        {
            if (id == null) return NotFound();

            Car = dbc.Cars.FirstOrDefault(m => m.Id == id);

            if (Car == null) return NotFound();
            
            return Page();
        }
    }
}
