using Blog.Application.AppServices.Blogs;
using Blog.Core.Models;
using Repositories.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Application.Repositories
{
	public interface IUserBlogRepository : IRepository<UserBlog>
	{
		List<BlogDto> GetSubscribedBlogs(int userId);
		Task<UserBlog> GetInfoByUserId(int userId);
		Task<UserBlog> GetAsync(int id);
		Task<UserBlog> GetAsyncByUserId(int userId);
		List<BlogDto> GetAllBlogs(int userId);
	}
}
