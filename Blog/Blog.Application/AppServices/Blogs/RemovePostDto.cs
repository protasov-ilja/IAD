namespace Blog.Application.AppServices.Blogs
{
	public class RemovePostDto
	{
		public string Login { get; set; }
		public int BlogId { get; set; }
		public int PostId { get; set; }
	}
}
