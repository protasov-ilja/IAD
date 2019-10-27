using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Api.Dtos
{
	public class UserDto
	{
		public string Login { get; set; }
		public string Password { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public int Id { get; set; }
		public string Role { get; set; }
	}
}
