using Blog.Core.Models;
using Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Repositories
{
	public interface IPostRepository : IRepository<Post>
	{
		void GetPostsDataByBlog(int blogId);
	}
}
