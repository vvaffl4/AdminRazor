using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorAdmin.Data;

namespace RazorAdmin.Pages
{
	public class ViewModel : PageModel
	{
		[BindProperty]
		public User User { get; set; }

		public IActionResult OnGet(string username)
		{
			User = Example.Users.FirstOrDefault(user => user.UserName == username);

			if (User == null)
			{
				return RedirectToPage("Error");
			}

			return Page();
		}
	}
}
