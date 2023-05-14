using JSJMExoticCarsWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JSJMExoticCarsWebApp.Pages
{
    public class CreateAccountModel : PageModel
    {
        CarDbContext _context;

        [BindProperty]
        public User User { get; set; }

        public CreateAccountModel(CarDbContext carDbContext)
        {
            _context = carDbContext;
        }
        public void OnGet()
        {

        }

        public ActionResult OnPost()
        {
            if(ModelState.IsValid)
            {
                User.Funds = 0;
                _context.Users.Add(User);
                _context.SaveChanges();
                return RedirectToPage("/Market");
            }
            return Page();
        }
    }
}
