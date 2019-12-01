using System.Threading.Tasks;

namespace Blog.Application.AppServices.Profile
{
	public interface IProfileService
	{
		Task<ProfileDto> GetUserInfo(string login);
		Task<EditResultDto> EditUserInfo(string login, ProfileDto profileDto);
	}
}
