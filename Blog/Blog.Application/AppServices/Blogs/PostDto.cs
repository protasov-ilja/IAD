using System;

namespace Blog.Application.AppServices.Blogs
{
	public class PostDto
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public int BlogId { get; set; }
		public string Title { get; set; }
		public string Text { get; set; }
		public DateTime? PublishDateOnUtc { get; set; }
		public LikesOfPostData LikesData { get; set; }
	}
}
