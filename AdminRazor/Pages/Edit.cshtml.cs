using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorAdmin.Data;
using System.Linq;

namespace RazorAdmin.Pages
{
	public class EditModel : PageModel
	{
		[BindProperty]
		public User User { get; set; }

		public IActionResult OnGet(string username)
		{
			// Get user of with username and set to show on the Razor Page
			User = Example.Users.FirstOrDefault(user => user.UserName == username);

			return Page();
		}

		public IActionResult OnPost()
		{
			// Redirect to the Accounts Razor page with the following Message
			return RedirectToPage("Accounts", new { Message = $"User {User.UserName} was edited succesfully" });
		}
	}
}
