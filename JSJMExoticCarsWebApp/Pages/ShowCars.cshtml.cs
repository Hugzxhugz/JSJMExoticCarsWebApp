using JSJMExoticCarsWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JSJMExoticCarsWebApp.Pages
{
    public class ShowCarsModel : PageModel
    {
        [BindProperty]
        public Car Car { get; set; }

        public void OnGet()
        {
        }
        
        public void OnPost()
        {
        }
    }
}
