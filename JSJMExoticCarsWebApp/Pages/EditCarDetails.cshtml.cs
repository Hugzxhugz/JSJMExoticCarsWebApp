using JSJMExoticCarsWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace JSJMExoticCarsWebApp.Pages;

public class EditCarDetailsModel : PageModel
{
    private DatabaseContext dbc;

    public EditCarDetailsModel(DatabaseContext dbc)
    {
        this.dbc = dbc;
    }
    
    [BindProperty]
    public Car car { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        car = await dbc.Cars.FirstOrDefaultAsync(m => m.Id == id);

        if (car == null)
        {
            return NotFound();
        }

        return Page();
    }
    
    public IActionResult OnPost(string submitAction)
    {
        if (submitAction == "update")
        {
            if (ModelState.IsValid)
            {
                dbc.Cars.Update(car);
                dbc.SaveChanges();

                TempData["Message"] = "Car details updated successfully!";
                return RedirectToPage("/Market");
            }
        }
        
        if (submitAction == "delete")
        {
            dbc.Cars.Remove(car);
            dbc.SaveChanges();
            TempData["Message"] = "Car deleted successfully.";
            return RedirectToPage("/Market");
        }

        return Page();
    }

}