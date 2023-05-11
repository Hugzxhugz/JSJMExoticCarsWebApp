using JSJMExoticCarsWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JSJMExoticCarsWebApp.Pages
{
    public class CreateAccountModel : PageModel
    {
        private CarDbContext _context;

        [BindProperty]
        public User user { get; set; }

        public CreateAccountModel(CarDbContext carDbContext)
        {
            _context = carDbContext;
        }
        public void OnGet()
        {

        }

        public void OnPost()
        {
            if(ModelState.IsValid)
            {

            }
        }
    }
}
