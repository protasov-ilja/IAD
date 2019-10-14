using System;

namespace Blog.Core.Models
{
	public class Post
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Text { get; set; }
		public DateTime? PublishDateOnUtc { get; set; }
		public int BlogId { get; set; }
		public int UserId { get; set; }
	}
}
