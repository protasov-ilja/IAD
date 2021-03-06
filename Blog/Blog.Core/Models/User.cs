﻿namespace Blog.Core.Models
{
	public class User
	{
		public int Id { get; set; }
		public string Login { get; set; }
		public string Password { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string ImageUri { get; set; }
		public string Status { get; set; }
		public string RefreshToken { get; set; }
	}
}
