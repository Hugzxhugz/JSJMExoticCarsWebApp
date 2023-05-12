using JSJMExoticCarsWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace JSJMExoticCarsWebApp.Pages
{
    public class LogInModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        private readonly CarDbContext _context;

        public LogInModel(CarDbContext carDbContext)
        {
            _context = carDbContext;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            var user = _context.Users.FirstOrDefault(u => u.Name == Username && u.Password == Password);
            if (user == null)
            {
                ErrorMessage = "Invalid username or password";
                return Page();
            }

            var userSession = new UserSession()
            {
                Id = user.Id,
                Name = user.Name,
                Funds = user.Funds,
                Cars = user.Cars
            };

            HttpContext.Session.Set("UserSession", UserSession.ConvertUserSessionToBytes(userSession));

            return RedirectToPage("/Index");
        }
    }
}
