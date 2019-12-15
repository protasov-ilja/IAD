using Blog.Application.Repositories;
using Blog.Core.Models;
using Repositories.Abstractions;
using System.Threading.Tasks;

namespace Blog.Application.AppServices.Blogs
{
	public class BlogsService : IBlogsService
	{
		private readonly IUserBlogRepository _blogRepository;
		private readonly IUserRepository _userRepository;
		private readonly IPostRepository _postRepository;
		private readonly ILikeInPostRepository _likesRepository;
		private readonly IUnitOfWork _unitOfWork;

		public BlogsService(IUserBlogRepository blogRepository, IUserRepository userRepository, IPostRepository postRepository, IUnitOfWork unitOfWork, ILikeInPostRepository likesRepository)
		{
			_unitOfWork = unitOfWork;
			_postRepository = postRepository;
			_userRepository = userRepository;
			_blogRepository = blogRepository;
			_likesRepository = likesRepository;
		}

		public async Task<BlogsData> GetUserSubscriptions(string login)
		{
			var user = await _userRepository.GetAsync(login);

			if (user == null)
			{
				return new BlogsData
				{
					IsSuccessCreated = false,
					ErrorInfo = "such login not found"
				};
			}


			var subscribedUserBlogs = _blogRepository.GetSubscribedBlogs(user.Id);

			if (subscribedUserBlogs == null)
			{
				return new BlogsData
				{
					IsSuccessCreated = false,
					ErrorInfo = "Error in query!"
				};
			}

			return new BlogsData
			{
				IsSuccessCreated = true,
				Blogs = subscribedUserBlogs
			};
		}

		public async Task<BlogTotalData> GetBlogData(int blogId, string login)
		{
			var user = await _userRepository.GetAsync(login);

			if (user == null)
			{
				return new BlogTotalData
				{
					IsSuccessCreated = false,
					ErrorInfo = "such login not found"
				};
			}

			var blogInfo = await _blogRepository.GetAsync(user.Id);

			var postsInfo = _postRepository.GetPostsByBlog(blogInfo.Id);

			for (var i = 0; i < postsInfo.Count; ++i)
			{
				postsInfo[i].LikesData = _likesRepository.GetLikesOfPost(postsInfo[i].Id, user.Id);
			}

			return new BlogTotalData
			{
				IsSuccessCreated = true,
				Id = blogInfo.Id,
				Name = blogInfo.Name,
				Info = blogInfo.Info,
				UserId = blogInfo.UserId,
				Posts = postsInfo
			};
		}

		public async Task<BoolResponseDto> RatePost(RateData rateData)
		{
			var user = await _userRepository.GetAsync(rateData.Login);

			if (user == null)
			{
				return new BoolResponseDto
				{
					IsSuccessCreated = false,
					ErrorInfo = "such login not found!"
				};
			}

			_likesRepository.Add(
				new LikeInPost
				{
					PostId = rateData.PostId,
					UserId = user.Id,
					IsNegative = rateData.IsNegative
				});

			await _unitOfWork.CommitAsync();

			return new BoolResponseDto
			{
				IsSuccessCreated = true
			};
		}

		public async Task<BoolResponseDto> CreateBlog(string login)
		{
			var user = await _userRepository.GetAsync(login);

			if (user == null)
			{
				return new BoolResponseDto
				{
					IsSuccessCreated = false,
					ErrorInfo = "such login not found!"
				};
			}

			var blog = new UserBlog { Info = "Paste you info here", Name = login, UserId = user.Id };

			_blogRepository.Add(blog);

			await _unitOfWork.CommitAsync();

			return new BoolResponseDto
			{
				IsSuccessCreated = true
			};
		}

		public async Task<BoolResponseDto> UnratePost(RateData rateData)
		{
			var user = await _userRepository.GetAsync(rateData.Login);

			if (user == null)
			{
				return new BoolResponseDto
				{
					IsSuccessCreated = false,
					ErrorInfo = "such login not found!"
				};
			}

			var like = await _likesRepository.GetAsyncByUserId(user.Id);

			if (like == null)
			{
				return new BoolResponseDto
				{
					IsSuccessCreated = false,
					ErrorInfo = "such like of user not found!"
				};
			}

			_likesRepository.Remove(like);

			return new BoolResponseDto
			{
				IsSuccessCreated = true
			};
		}

		public async Task<BoolResponseDto> CreatePost(PostDto postDto, string login)
		{
			var user = await _userRepository.GetAsync(login);

			if (user == null)
			{
				return new BoolResponseDto
				{
					IsSuccessCreated = false,
					ErrorInfo = "such login not found!"
				};
			}

			var blogInfo = await _blogRepository.GetAsync(user.Id);

			if (blogInfo == null)
			{
				return new BoolResponseDto
				{
					IsSuccessCreated = false,
					ErrorInfo = "such blog not found!"
				};
			}

			var post = new Post
			{
				Title = postDto.Title,
				Text = postDto.Text,
				PublishDateOnUtc = postDto.PublishDateOnUtc,
				UserBlogId = blogInfo.Id,
				UserId = user.Id
			};

			_postRepository.Add(post);

			await _unitOfWork.CommitAsync();

			return new BoolResponseDto
			{
				IsSuccessCreated = true
			};
		}

		public async Task<BoolResponseDto> RemovePost(RemovePostDto postData)
		{
			var user = await _userRepository.GetAsync(postData.Login);

			if (user == null)
			{
				return new BoolResponseDto
				{
					IsSuccessCreated = false,
					ErrorInfo = "such login not found!"
				};
			}

			var blogInfo = await _blogRepository.GetAsync(user.Id);

			if (blogInfo == null)
			{
				return new BoolResponseDto
				{
					IsSuccessCreated = false,
					ErrorInfo = "such blog not found!"
				};
			}
			var post = await _postRepository.GetAsync(postData.PostId);

			if (post == null)
			{
				return new BoolResponseDto
				{
					IsSuccessCreated = false,
					ErrorInfo = "such post not found!"
				};
			}

			_postRepository.Remove(post);

			await _unitOfWork.CommitAsync();

			return new BoolResponseDto
			{
				IsSuccessCreated = true
			};
		}
	}
}
