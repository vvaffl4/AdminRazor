using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorAdmin.Data;

namespace RazorAdmin.Pages
{
	public class AccountsModel : PageModel
	{
		[BindProperty]
		public IEnumerable<User> Users { get; set; }

		public AccountsModel()
		{
			Users = Array.Empty<User>();
		}

		[BindProperty]
		public string? Message { get; set; }

		public void OnGet(string message)
		{
			Users = Example.Users;
			Message = message;
		}

		public void OnGetDelete(string username)
		{
			Users = Example.Users.Where(user => user.UserName != username);
			Message = $"{username} is deleted!";
		}
	}
}
