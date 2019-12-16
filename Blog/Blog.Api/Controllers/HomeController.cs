using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Blog.Api.Dtos;
using Blog.Application.AppServices.Blogs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
	[Route("api/[controller]")]
	[Authorize]
	[ApiController]
	public class HomeController : Controller
	{
		public IBlogsService _blogsService;

		public HomeController(IBlogsService blogsService)
		{
			_blogsService = blogsService;
		}

		
		[HttpGet("user-subscriptions")]
		public async Task<ResponseDto<List<BlogDto>>> GetSubscriptions()
		{
			var login = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

			if (login == null)
			{
				return new ResponseDto<List<BlogDto>>
				{
					HttpStatus = 401,
					ErrorInfo = "such login not found!"
				};
			}

			var data = await _blogsService.GetUserSubscriptions(login.Value);

			if (!data.IsSuccessCreated)
			{
				return new ResponseDto<List<BlogDto>>
				{
					HttpStatus = 401,
					ErrorInfo = "Server error!"
				};
			}

			return new ResponseDto<List<BlogDto>>
			{
				HttpStatus = 200,
				Result = data.Blogs
			};
		}

		[HttpGet("my-name")]
		public async Task<string[]> GetMyName()
		{
			var login = this.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

			return new string[] { login?.Value, "Ilya" };
		}
	}
}
