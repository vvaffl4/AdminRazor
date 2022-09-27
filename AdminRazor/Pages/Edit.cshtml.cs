using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorAdmin.Data;

namespace RazorAdmin.Pages
{
	public class EditModel : PageModel
	{
		[BindProperty]
		public User User { get; set; }

		public IActionResult OnGet(string username)
		{
			User = Example.Users.FirstOrDefault(user => user.UserName == username);

			return Page();
		}

		public IActionResult OnPost()
		{
			return RedirectToPage("Accounts", new { Message = $"User {User.UserName} was edited succesfully" });
		}
	}
}
