using System;

namespace Blog.Core.Models
{
	public class Comment
	{
		public int Id { get; set; }
		public string Text { get; set; }
		public int PostId { get; set; }
		public int UserId { get; set; }
		public DateTime? PublishDateOnUtc { get; set; }
	}
}
