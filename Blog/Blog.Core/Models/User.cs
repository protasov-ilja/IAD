namespace Blog.Core.Models
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

		//public User(string login, string password, string firstName = null, string lastName = null)
		//{
		//	Login = login;
		//	Password = password;
		//	FirstName = firstName;
		//	LastName = lastName;
		//}

		//public User(int id, string login, string password, string firstName = null, string lastName = null)
		//{
		//	Id = id;
		//	Login = login;
		//	Password = password;
		//	FirstName = firstName;
		//	LastName = lastName;
		//}
	}
}
