using JSJMExoticCarsWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JSJMExoticCarsWebApp.Pages
{
    public class MyAccountModel : PageModel
    {
        [BindProperty]
        public UserSession Session { get; set; }

        public ActionResult OnGet()
        {
            byte[] userSessionBytes = HttpContext.Session.Get("UserSession");
            if(userSessionBytes == null) 
            {
                Session = new UserSession();
                
                return RedirectToPage("/SignIn"); ;
            }
            Session = UserSession.ConvertBytesToUserSession(userSessionBytes);
            return Page();
        }
    }
}
