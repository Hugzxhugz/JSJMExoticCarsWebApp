using JSJMExoticCarsWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace JSJMExoticCarsWebApp.Pages
{
    public class BuyCarModel : PageModel
    {
        CarDbContext context;

        public BuyCarModel(CarDbContext cardb)
        {
            context = cardb;
        }

        public Car Car { get; set; }

        public void OnGet(int? id)
        {
            if (id == null) InvalidId();

            Car = context.Cars.FirstOrDefault(m => m.Id == id);

            if (Car == null) InvalidId();
        }

        public ActionResult InvalidId()
        {
            return NotFound();
        }

        public ActionResult OnPost(int? id)
        {
            int carid = 0;
            if(id != null)
            {
                carid = (int)id;
            }
            else return Page();

            int buyerid = UserSession.ConvertBytesToUserSession(HttpContext.Session.Get("UserSession")).Id;

            bool purchase = BuyCar(carid, buyerid, context);

            if (purchase)
            {
                UserSession session = UserSession.UpdateUserSession(UserSession.ConvertBytesToUserSession(HttpContext.Session.Get("UserSession")), context);
                HttpContext.Session.Set("UserSession", UserSession.ConvertUserSessionToBytes(session));

                return RedirectToPage("/MyAccount");
            }
               

            return RedirectToPage("/BuyCar", new { id = carid });
        }

        public static bool BuyCar(int carId, int buyerId, CarDbContext carDbContext)
        {
            var car = carDbContext.Cars.FirstOrDefault(c => c.Id == carId);
            if (car == null) return false;

            var buyer = carDbContext.Users.Include(u => u.Cars).FirstOrDefault(u => u.Id == buyerId);
            if (buyer == null) return false;

            var owner = carDbContext.Users.Include(u => u.Cars).FirstOrDefault(u => u.Cars.Any(c => c.Id == carId));
            if (owner == null) return false;

            if(buyer.Cars.Contains(car)) return false;

            if (buyer.Funds < car.Price) return false;

            buyer.Funds -= car.Price;
            owner.Funds += car.Price;
            car.Listed = false;

            buyer.Cars.Add(car);
            owner.Cars.Remove(car);

            carDbContext.SaveChanges();

            return true;
        }
    }
}
