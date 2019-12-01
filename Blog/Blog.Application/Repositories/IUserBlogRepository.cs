using Blog.Application.AppServices.Blogs;
using Blog.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Repositories
{
	public interface IUserBlogRepository
	{
		List<BlogDto> GetSubscribedBlogs(int userId);
	}
}
