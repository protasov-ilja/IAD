﻿using System.Collections.Generic;
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
	[AllowAnonymous]
	[ApiController]
	public class HomeController : Controller
	{
		public IBlogsService _blogsService;

		public HomeController(IBlogsService blogsService)
		{
			_blogsService = blogsService;
		}

		[HttpGet("user-subscriptions")]
		public async Task<ResponseDto<List<BlogDto>>> GetSubscriptions([FromQuery] int userId)
		{
			var data = await _blogsService.GetUserSubscriptions(userId);

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

		//public async Task<IActionResult> ReadBlog(string blogData)
		//{
		//	throw new NotImplementedException("register logic not implemented");
		//}
	}
}
