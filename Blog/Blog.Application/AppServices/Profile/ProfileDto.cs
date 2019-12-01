namespace Blog.Application.AppServices.Profile
{
	public class ProfileDto
	{
		public bool IsSuccessCreated { get; set; }
		public string ErrorInfo { get; set; }
		public int BlogId { get; set; }
		public string Login { get; set; }
		public string Password { get; set; }
		public string UserFirstName { get; set; }
		public string UserLastName { get; set; }
		public string BlogName { get; set; }
		public string BlogInfo { get; set; }
	}
}
