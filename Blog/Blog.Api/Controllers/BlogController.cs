using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Blog.Api.Dtos;
using Blog.Application.AppServices.Blogs;
using Blog.Application.AppServices.Subscription;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
	[Route("api/[controller]")]
	[Authorize]
	[ApiController]
	public class BlogController : Controller
    {
		private ISubscriptionsService _subscriptionsService;
		private IBlogsService _blogsService;

		public BlogController(ISubscriptionsService subscriptionsService, IBlogsService blogsService)
		{
			_blogsService = blogsService;
			_subscriptionsService = subscriptionsService;
		}

		public async Task<IActionResult> RatePost(string rateData)
		{
			throw new NotImplementedException("register logic not implemented");
		}

		[HttpGet("show")]
		public async Task<ResponseDto<bool>> ShowBlog(int blogId)
		{
			var login = this.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

			if (login == null)
			{
				return new ResponseDto<bool>
				{
					HttpStatus = 401,
					ErrorInfo = "such login not found!"
				};
			}

			await _blogsService.GetBlogData(blogId, login.Value);
			return new ResponseDto<bool>
			{
				HttpStatus = 200,
				Result = true,
			};

		}

		[HttpPost("subscribe")]
		public async Task<ResponseDto<bool>> SubscribeOnBlog([FromBody] int blogId)
		{
			var login = this.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

			if (login == null)
			{
				return new ResponseDto<bool>
				{
					HttpStatus = 401,
					ErrorInfo = "such login not found!"
				};
			}

			var data = await _subscriptionsService.SubscribedOnBlog(login.Value, blogId);

			if (!data.IsSuccessCreated)
			{
				return new ResponseDto<bool>
				{
					HttpStatus = 401,
					ErrorInfo = data.ErrorInfo
				};
			}

			return new ResponseDto<bool>
			{
				HttpStatus = 200,
				Result = data.IsSuccessCreated
			};
		}

		[HttpPost("unsubscribe")]
		public async Task<ResponseDto<bool>> UnsubscribeOnBlog([FromBody] int blogId)
		{
			var login = this.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

			if (login == null)
			{
				return new ResponseDto<bool>
				{
					HttpStatus = 401,
					ErrorInfo = "such login not found!"
				};
			}

			var data = await _subscriptionsService.UnsubscribedOnBlog(login.Value, blogId);

			if (!data.IsSuccessCreated)
			{
				return new ResponseDto<bool>
				{
					HttpStatus = 401,
					ErrorInfo = data.ErrorInfo
				};
			}

			return new ResponseDto<bool>
			{
				HttpStatus = 200,
				Result = data.IsSuccessCreated,
			};
		}
	}
}