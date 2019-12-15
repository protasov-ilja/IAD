using System;
using System.Collections.Generic;

namespace Blog.Application.AppServices.Blogs
{
	public class BlogTotalData
	{
		public bool IsSuccessCreated { get; set; }
		public string ErrorInfo { get; set; }

		public int Id { get; set; }
		public string Name { get; set; }
		public string Info { get; set; }
		public int UserId { get; set; }
		public List<PostDto> Posts { get; set; }
	}
}
