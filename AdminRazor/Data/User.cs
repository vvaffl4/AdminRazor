﻿using RazorAdmin.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RazorAdmin.Data
{
	public class User
	{
		[Required(ErrorMessage = "A username is required")]
		[RegularExpression("^[a-zA-Z0-9_]*$", ErrorMessage = "Usernames can only contain letters, numbers and _")]
		public string UserName { get; set; }
		[Required(ErrorMessage = "A password is required")]
		[MinLength(12, ErrorMessage = "Your password must be longer than 11 characters.")]
		[MaxLength(128, ErrorMessage = "Your password can't be longer than 128 characters.")]
		public string Password { get; set; }
	}

	public static class Example
	{
		// Example User data to show in this example (instead of Database data)
		public static IEnumerable<User> Users = new User[]
		{
			new User{ UserName = "Admin", Password = "Admin!" },
			new User { UserName = "User1", Password = "User1!" },
			new User { UserName = "User2", Password = "User2!" },
			new User { UserName = "User3", Password = "User3!" },
			new User { UserName = "User4", Password = "User4!" }
		};
	}
}
