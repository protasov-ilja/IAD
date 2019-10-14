namespace Blog.Core.Models
{
	public class SubscriberOfBlog
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public int UserBlogId { get; set; }
	}
}
