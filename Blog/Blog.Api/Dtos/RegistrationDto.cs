namespace Blog.Api.Dtos
{
	public class RegistrationDto
	{
		public string Login { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string ConfirmPassword { get; set; }
	}
}
