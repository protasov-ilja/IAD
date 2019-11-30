using Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Application.AppServices.Blogs
{
	public class BlogsService : IBlogsService
	{
		private readonly IUserRepository _userRepository;
		private readonly IJwtSigningEncodingKey _signingEncodingKey;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IUserBlogRepository _blogRepository;

		public AccountService(IUserRepository userRepository, IJwtSigningEncodingKey signingEncodingkey, IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
			_signingEncodingKey = signingEncodingkey;
			_userRepository = userRepository;
		}

		public Task<List<int>> GetUserSubscriptions(int userId)
		{
			var user = await _userRepository.GetAsync(login);
		}
	}
}
