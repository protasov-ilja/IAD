using Blog.Application.AppServices.Blogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Api.Dtos.Blogs
{
	public class BlogDataDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Info { get; set; }
		public int UserId { get; set; }
		public List<PostDto> Posts { get; set; }
	}
}
