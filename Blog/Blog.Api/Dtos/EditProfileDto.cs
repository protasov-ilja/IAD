namespace Blog.Api.Dtos
{
	public class EditProfileDto
	{
		public int UserId { get; set; }
		public string BlogId { get; set; }
		public string UserFirstName { get; set; }
		public string UserLastName { get; set; }
		public string BlogName { get; set; }
		public string BlogInfo { get; set; }
		public string Password{ get; set; }
	}
}
