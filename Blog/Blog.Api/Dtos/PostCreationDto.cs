using System;

namespace Blog.Api.Dtos
{
	public class PostCreationDto
	{
		public string Title { get; set; }
		public string Text { get; set; }
		public DateTime? PublishDateInUtc { get; set; }
		public int BlogId { get; set; }
	}
}
