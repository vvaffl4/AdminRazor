using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorAdmin.Data;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;

namespace RazorAdmin.Pages
{
	public class LoginModel : PageModel
	{
		private readonly User defaultUser = new() { UserName = "Admin", Password = "ThisIsAnAdmin1!" };

		[ViewData]
		public string Title { get; set; } = "Login admin";

		[ViewData]
		public string ErrorMessages { get; set; }

		[BindProperty]
		public Login login { get; set; }

		public void OnGet()
		{
			ErrorMessages = "";
			login = new Login { UserName = "", Password = "" };
		}

		public IActionResult OnPost()
		{
			// Checks if data annotations on models are valid.
			// Can be used to prevent SQL injection
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

			// Set ViewData "ErrorMessages" to all errors encountered in the ModelState (aka data notations)
			ErrorMessages = string.Join(
				" \n ",
				ModelState.Values
					.SelectMany(v => v.Errors)
					.Select(error => error.ErrorMessage));

			// Return to same page with ErrorMessages
			return Page();
		}

		public class Login : User {}
	}

}
