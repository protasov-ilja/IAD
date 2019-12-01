using Blog.Application.Repositories;
using Blog.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Application.AppServices.Blogs
{
	public class BlogsService : IBlogsService
	{
		private readonly IUserBlogRepository _blogRepository;
		private readonly IUserRepository _userRepository;
		private readonly IPostRepository _postRepository;

		public BlogsService(IUserBlogRepository blogRepository, IUserRepository userRepository, IPostRepository postRepository)
		{
			_postRepository = postRepository;
			_userRepository = userRepository;
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

		public async Task GetBlogData(int blogId, string login)
		{
			var user = await _userRepository.GetAsync(login);

			if (user != null)
			{
			}

			var blogData = _blogRepository.GetInfoByUserId(user.Id);

			_postRepository.GetPostsDataByBlog(blogId);
		}
	}
}
