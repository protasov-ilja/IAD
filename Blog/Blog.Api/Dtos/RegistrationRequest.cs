﻿namespace Blog.Api.Dtos
{
	public class RegistrationRequest
	{
		public string Login { get; set; }
		public string Password { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
	}
}
