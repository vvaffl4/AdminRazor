using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorAdmin.Data;
using System.Linq;

namespace RazorAdmin.Pages
{
	public class CreateModel : PageModel
	{
		[BindProperty]
		public User User { get; set; }

		public void OnGet()
		{}

		public IActionResult OnPost()
		{
			// Redirect to Razor Page "Accounts" with the Handler "Create", and parameters "username" and "password"
			return RedirectToPage("Accounts", "Create", new { username = User.UserName, password = User.Password });
		}
	}
}
