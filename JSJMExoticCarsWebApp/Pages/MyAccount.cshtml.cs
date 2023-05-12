using JSJMExoticCarsWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JSJMExoticCarsWebApp.Pages
{
    public class MyAccountModel : PageModel
    {
        [BindProperty]
        public UserSession Session { get; set; }

        public void OnGet()
        {
            byte[] userSessionBytes = HttpContext.Session.Get("UserSession");

            Session = UserSession.ConvertBytesToUserSession(userSessionBytes);

        }
    }
}
