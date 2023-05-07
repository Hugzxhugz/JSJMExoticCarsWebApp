using Azure;
using JSJMExoticCarsWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System;

namespace JSJMExoticCarsWebApp.Pages;

public class EditCarDetailsModel : PageModel
{
    private CarDbContext dbc;

    public EditCarDetailsModel(CarDbContext dbc)
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

    public IActionResult OnPost(int? id, string submitAction)
    {
        if (submitAction == "delete")
        {

            if (id == null)
            {
                return NotFound();
            }

            var carToDelete = dbc.Cars.Find(id);

            if (carToDelete == null)
            {
                return NotFound();
            }

            // Set the Id property explicitly
            carToDelete.Id = id.Value;

            dbc.Cars.Remove(carToDelete);
            dbc.SaveChanges();

            TempData["Message"] = "Car deleted successfully.";

            return RedirectToPage("/Market");
        }

        if (submitAction == "update")
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var carToUpdate = dbc.Cars.Find(id);

            if (carToUpdate == null)
            {
                return NotFound();
            }

            carToUpdate.CarModel = car.CarModel;
            carToUpdate.CarBrand = car.CarBrand;
            carToUpdate.YearModel = car.YearModel;
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