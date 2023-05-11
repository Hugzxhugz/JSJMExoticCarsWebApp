using JSJMExoticCarsWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace JSJMExoticCarsWebApp.Pages
{
    public class EditCarModel : PageModel
    {
        private CarDbContext dbc;

        public EditCarModel(CarDbContext dbc)
        {
            this.dbc = dbc;
        }

        [BindProperty]
        public Car car { get; set; }

        public ActionResult OnGet(int? id)
        {
            if (id == null) return NotFound();
        
            car = dbc.Cars.FirstOrDefault(m => m.Id == id);

            if (car == null) return NotFound();

            return Page();
        }

        public ActionResult OnPost(int? id, string submitAction)
        {
            if (submitAction == "delete")
            {
                if (id == null) return NotFound();

                var carToDelete = dbc.Cars.Find(id);

                if (carToDelete == null) return NotFound();

                // Set the Id property explicitly
                carToDelete.Id = id.Value;

                dbc.Cars.Remove(carToDelete);
                dbc.SaveChanges();

                TempData["Message"] = "Car deleted successfully.";

                return RedirectToPage("/Market");
            }

            if (submitAction == "update")
            {
                if (!ModelState.IsValid) return Page();

                var carToUpdate = dbc.Cars.Find(id);

                if (carToUpdate == null) return NotFound();

                carToUpdate.Model = car.Model;
                carToUpdate.Brand = car.Brand;
                carToUpdate.ModelYear = car.ModelYear;
                carToUpdate.Description = car.Description;
                carToUpdate.Mileage = car.Mileage;
                carToUpdate.Transmission = car.Transmission;
                carToUpdate.Fuel = car.Fuel;
                carToUpdate.Price = car.Price;

                dbc.Cars.Update(carToUpdate);
                dbc.SaveChanges();

                TempData["Message"] = "Car details updated successfully!";

                return RedirectToPage("/Market");
            }

            return Page();
        }
    }
}
