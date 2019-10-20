using System;

namespace Blog.Api.Dtos
{
	public class CommentCreatedDto
	{
		public int BlogId { get; set; }
		public int PostId { get;set; }
		public string Text { get; set; }
		public DateTime? PublishDateInUtc { get; set; }
		public int CommentedUserId { get; set; } 
	}
}
