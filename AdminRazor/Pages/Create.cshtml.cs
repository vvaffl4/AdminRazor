using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorAdmin.Data;
using System.Linq;

namespace RazorAdmin.Pages
{
	public class CreateModel : PageModel
	{
		[ViewData]
		public string ErrorMessages { get; set; }

		[BindProperty]
		public User User { get; set; }

		public void OnGet()
		{}

		public IActionResult OnPost()
		{
			// Checks if data annotations on models are valid.
			// Can be used to prevent SQL injection
			if (ModelState.IsValid)
			{
				// Redirect to Razor Page "Accounts" with the Handler "Create", and parameters "username" and "password"
				return RedirectToPage("Accounts", "Create", new { username = User.UserName, password = User.Password });
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
	}
}
