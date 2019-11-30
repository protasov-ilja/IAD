using System;
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

		public HomeController(/*IBlogsService blogsService*/)
		{
			//_blogsService = blogsService
		}

		[HttpGet("user-subscriptions")]
		public async Task<ResponseDto<List<int>>> GetSubscriptions(int userId)
		{
			var data = await _blogsService.GetUserSubscriptions(userId);

			return new ResponseDto<List<int>>
			{
				Result = 200
			};
		}


		[HttpGet("my-name")]
		public string[] GetMyName()
		{
			var login = this.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

			return new string[] { login?.Value, "Ilya" };
		}

		//[HttpPost("token")]
		//public ActionResult GetToken()
		//{

		//}

		//public async Task<IActionResult> ShowSubscriptionBlogs()
		//{
		//	throw new NotImplementedException("register logic not implemented");
		//}

		//public async Task<IActionResult> ReadBlog(string blogData)
		//{
		//	throw new NotImplementedException("register logic not implemented");
		//}
	}
}
