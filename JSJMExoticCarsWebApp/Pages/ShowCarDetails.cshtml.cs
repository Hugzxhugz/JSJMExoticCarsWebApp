using JSJMExoticCarsWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace JSJMExoticCarsWebApp.Pages
{
    public class ShowCarDetailsModel : PageModel
    {
        DatabaseContext dbc;

        public ShowCarDetailsModel(DatabaseContext dbc)
        {
            this.dbc = dbc;
        }
        
        public Car Car { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Car = await dbc.Cars.FirstOrDefaultAsync(m => m.Id == id);

            if (Car == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
