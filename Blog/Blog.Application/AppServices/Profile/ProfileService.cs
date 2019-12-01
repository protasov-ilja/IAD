using Blog.Application.Repositories;
using Repositories.Abstractions;
using System.Threading.Tasks;

namespace Blog.Application.AppServices.Profile
{
	public class ProfileService : IProfileService
	{
		private IUserRepository _userRepository;
		private IUnitOfWork _unitOfWork;
		private IUserBlogRepository _blogRepository;

		public ProfileService(IUserRepository userRepository, IUnitOfWork unitOfWork, IUserBlogRepository blogRepository) 
		{
			_blogRepository = blogRepository;
			_unitOfWork = unitOfWork;
			_userRepository = userRepository;
		}

		public async Task<ProfileDto> GetUserInfo(string login)
		{
			var user = await _userRepository.GetAsync(login);
			if (user == null)
			{
				return new ProfileDto
				{
					IsSuccessCreated = false,
					ErrorInfo = "string error such user not found!"
				};
			}

			var blog = await _blogRepository.GetInfoByUserId(user.Id);
			if (blog == null)
			{
				return new ProfileDto
				{
					IsSuccessCreated = false,
					ErrorInfo = "string error such blog not found!"
				};
			}

			return new ProfileDto
			{
				IsSuccessCreated = true,
				BlogId = blog.Id,
				Login = user.Login,
				Password = user.Password,
				UserFirstName = user.FirstName,
				UserLastName = user.FirstName,
				BlogInfo = blog.Info
			};
		}

		public async Task<EditResultDto> EditUserInfo(string login, ProfileDto profileDto)
		{
			var user = await _userRepository.GetAsync(login);
			if (user == null)
			{
				return new EditResultDto
				{
					IsSuccessUpdated = false,
					ErrorInfo = "string error such user not found!"
				};
			}

			var blog = await _blogRepository.GetInfoByUserId(user.Id);
			if (blog == null)
			{
				return new EditResultDto
				{
					IsSuccessUpdated = false,
					ErrorInfo = "string error such blog not found!"
				};
			}

			user.Password = profileDto.Password;
			user.FirstName = profileDto.UserFirstName;
			user.LastName = profileDto.UserLastName;

			blog.Info = profileDto.BlogInfo;
			blog.Name = profileDto.BlogName;

			await _unitOfWork.CommitAsync();

			return new EditResultDto
			{
				IsSuccessUpdated = true
			};
		}
	}
}
