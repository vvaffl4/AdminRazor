using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorAdmin.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RazorAdmin.Pages
{
	public class AccountsModel : PageModel
	{
		[BindProperty]
		public IEnumerable<User> Users { get; set; }

		// One Thing to notice on the Accounts Razor Page, it has a CSS file which only affects this page.
		public AccountsModel()
		{
			Users = Array.Empty<User>();
		}

		[BindProperty]
		public string Message { get; set; }

		public void OnGet(string message)
		{
			// On default Get, set Users to example users
			Users = Example.Users;

			// Set Message to optional message (can be empty)
			Message = message;
		}

		public void OnGetDelete(string username)
		{
			// Exclude deleted user from Users
			Users = Example.Users.Where(user => user.UserName != username);

			// Set message that this user is deleted
			Message = $"{username} is deleted!";
		}

		public void OnGetCreate(string username, string password)
		{
			// Add created user to Users
			Users = Example.Users.Append(new User { UserName = username, Password = password });

			// Set message that this user is created
			Message = $"{username} is created!";
		}
	}
}
