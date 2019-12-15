using Blog.Application.AppServices.Blogs;
using Blog.Core.Models;
using Repositories.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Application.Repositories
{
	public interface IPostRepository : IRepository<Post>
	{
		Task<Post> GetAsync(int id);
		void GetPostsDataByBlog(int blogId);

		List<PostDto> GetPostsByBlog(int blogId);
	}
}
