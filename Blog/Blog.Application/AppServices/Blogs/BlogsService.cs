using Blog.Application.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Application.AppServices.Blogs
{
	public class BlogsService : IBlogsService
	{
		private readonly IUserBlogRepository _blogRepository;

		public BlogsService(IUserBlogRepository blogRepository)
		{
			_blogRepository = blogRepository;
		}

		public async Task<BlogsData> GetUserSubscriptions(int userId)
		{
			var subscribedUserBlogs = _blogRepository.GetSubscribedBlogs(userId);

			return new BlogsData {
				IsSuccessCreated = true,
				Blogs = subscribedUserBlogs
			};
		}
	}
}
