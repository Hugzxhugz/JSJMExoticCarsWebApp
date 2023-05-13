using JSJMExoticCarsWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JSJMExoticCarsWebApp.Pages
{
    public class AddFundsModel : PageModel
    {
		CarDbContext _context;

        [BindProperty]
        public int CurrentFunds { get; set; }

		[BindProperty]
		public int NewFunds { get; set; }

        public AddFundsModel(CarDbContext cardb)
        {
			_context = cardb;
        }
        public ActionResult OnGet()
        {
			byte[] userSessionBytes = HttpContext.Session.Get("UserSession");
			if (userSessionBytes == null) return RedirectToPage("/SignIn");
			return Page();
			
		}

		public ActionResult OnPost()
		{
			if (!ModelState.IsValid) return Page();

			byte[] userSessionBytes = HttpContext.Session.Get("UserSession");

			UserSession session = UserSession.ConvertBytesToUserSession(userSessionBytes);

			session.Funds += NewFunds;

			UserSession.UpdateUser(session, _context);


			HttpContext.Session.Set("UserSession", UserSession.ConvertUserSessionToBytes(session));

			return RedirectToPage("/MyAccount");
		}
    }
}
