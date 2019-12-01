namespace Blog.Application.AppServices.Blogs
{
	public class BlogDto
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public string Name { get; set; }
		public string Info { get; set; }
		public bool AlreadySubscribed { get; set; }
		public string ImageUri { get; set; }
	}
}
