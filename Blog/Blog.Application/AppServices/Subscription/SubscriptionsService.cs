using Blog.Application.Repositories;
using Blog.Core.Models;
using Repositories.Abstractions;
using System.Threading.Tasks;

namespace Blog.Application.AppServices.Subscription
{
	public class SubscriptionsService : ISubscriptionsService
	{
		private readonly ISubscriberOfBlogRepository _subscriberOfBlogRepository;
		private readonly IUserRepository _userRepository;
		private readonly IUserBlogRepository _blogRepository;
		private readonly IUnitOfWork _unitOfWork;

		public SubscriptionsService(ISubscriberOfBlogRepository subscriberOfBlogRepository, IUserRepository userRepository, IUserBlogRepository blogRepository, IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
			_blogRepository = blogRepository;
			_userRepository = userRepository;
			_subscriberOfBlogRepository = subscriberOfBlogRepository;
		}

		public async Task<SubscriptionResult> SubscribedOnBlog(string login, int blogId)
		{
			var user = await _userRepository.GetAsync(login);
			if (user == null)
			{
				return new SubscriptionResult
				{
					IsSuccessCreated = false,
					ErrorInfo = "string error such user not found!"
				};
			}

			var blog = await _blogRepository.GetAsync(blogId);
			if (blog == null)
			{
				return new SubscriptionResult
				{
					IsSuccessCreated = false,
					ErrorInfo = "string error such blog not found!"
				};
			}

			var subscription = new SubscriberOfBlog
			{
				UserBlogId = blogId,
				UserId = user.Id
			};

			_subscriberOfBlogRepository.Add(subscription);

			await _unitOfWork.CommitAsync();

			return new SubscriptionResult
			{
				IsSuccessCreated = true
			};
		}

		public async Task<SubscriptionResult> UnsubscribedOnBlog(string login, int blogId)
		{
			var user = await _userRepository.GetAsync(login);
			if (user == null)
			{
				return new SubscriptionResult
				{
					IsSuccessCreated = false,
					ErrorInfo = "string error such user not found!"
				};
			}

			var blog = await _blogRepository.GetAsync(blogId);
			if (blog == null)
			{
				return new SubscriptionResult
				{
					IsSuccessCreated = false,
					ErrorInfo = "string error such blog not found!"
				};
			}

			var subscription = await _subscriberOfBlogRepository.GetAsyncByUserIdAndBlogId(user.Id, blogId);
			if (subscription == null)
			{
				return new SubscriptionResult
				{
					IsSuccessCreated = false,
					ErrorInfo = "string error such subscription not found!"
				};
			}

			_subscriberOfBlogRepository.Remove(subscription);

			await _unitOfWork.CommitAsync();

			return new SubscriptionResult
			{
				IsSuccessCreated = true
			};
		}
	}
}
