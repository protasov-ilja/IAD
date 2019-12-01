using System;
using System.Collections.Generic;
using System.Text;

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

		public int LikesAmount { get; set; }
		public int DislikesAmount { get; set; }
	}
}
