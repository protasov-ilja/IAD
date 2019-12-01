using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Blog.Api.Dtos;
using Blog.Application.AppServices.Profile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
	[Route("api/[controller]")]
	[Authorize]
	[ApiController]
	public class EditorController : Controller
    {
		private IProfileService _profileService;

		public EditorController(IProfileService profileService)
		{
			_profileService = profileService;
		}

		[HttpPost("user-data")]
		public async Task<ResponseDto<ProfileDto>> ShowUserData()
		{
			var login = this.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

			if (login == null)
			{
				throw new Exception("Error login not found!");
			}

			var userData = await _profileService.GetUserInfo(login.Value);

			return new ResponseDto<ProfileDto>
			{
				HttpStatus = 200,
			};
		}

		[HttpPost("user-edit")]
		public async Task<IActionResult> SaveChanges([FromBody] ProfileDto profileDto)
		{
			var login = this.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

			if (login == null)
			{
				throw new Exception("Error login not found!");
			}

			var userData = await _profileService.EditUserInfo(login.Value, profileDto);

			throw new NotImplementedException("Save logic not emplemented");
		}
    }
}