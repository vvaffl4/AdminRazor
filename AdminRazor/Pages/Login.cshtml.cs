using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorAdmin.Data;
using System.ComponentModel.DataAnnotations;


namespace RazorAdmin.Pages
{
	public class LoginModel : PageModel
	{
		private User defaultUser = new User { UserName = "Admin", Password = "ThisIsAnAdmin1!" };

		[BindProperty]
		public Login login { get; set; } = new Login { UserName = "", Password = "" };

		public void OnGet()
		{}

		public IActionResult OnPost()
		{
			// Checks if data annotations on models are valid.
			// Can be used to prevent SQL injection
			// ModelState.Values.SelectMany(v => v.Errors)
			if (ModelState.IsValid)
			{
				// Check if username and password is valid
				// Normally you'd use Identity to identify your user, but we haven't had the lesson for that
				if(defaultUser.UserName == login.UserName && defaultUser.Password == login.Password)
				{
					// Redirect to the Razor Page: Accounts
					return RedirectToPage("Accounts");
				}
			}

			// Redirect to the Razor Page: Error
			return RedirectToPage("Error");
		}

		public class Login : User {}
	}

}
