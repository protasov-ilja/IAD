using System;

namespace Blog.Api.Dtos
{
	public class CommentViewDto
	{
		public int BlogId { get; set; }
		public string UserFirstName { get; set; }
		public string UserLastName { get; set; }
		public int UserId { get; set; }
		public DateTime? PublishDateInUtc { get; set; }
		public int PostId { get; set; }
		public string Text { get; set; }
	}
}
