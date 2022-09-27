using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorAdmin.Data;
using System.Linq;

namespace RazorAdmin.Pages
{
	public class ViewModel : PageModel
	{
		[BindProperty]
		public User User { get; set; }

		public IActionResult OnGet(string username)
		{
			// Get user of with username and set to show on the Razor Page
			User = Example.Users.FirstOrDefault(user => user.UserName == username);

			if (User == null)
			{
				// Could also redirect back to the Accounts Razor Page
				return RedirectToPage("Error");
			}

			return Page();
		}
	}
}
