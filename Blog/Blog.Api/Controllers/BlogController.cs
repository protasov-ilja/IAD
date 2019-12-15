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

		#region PostRating
		[HttpPost("rate")]
		public async Task<ResponseDto<bool>> RatePost([FromBody] PostRateDto rateDto)
		{
			var login = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

			if (login == null)
			{
				return new ResponseDto<bool>
				{
					HttpStatus = 401,
					ErrorInfo = "such login not found!"
				};
			}

			var data = new RateData { BlogId = rateDto.BlogId, Login = login.Value, PostId = rateDto.PostId, IsNegative = rateDto.IsNegative };
			var pesponseData = await _blogsService.RatePost(data);

			if (!pesponseData.IsSuccessCreated)
			{
				return new ResponseDto<bool>
				{
					HttpStatus = 401,
					ErrorInfo = pesponseData.ErrorInfo
				};
			}

			return new ResponseDto<bool>
			{
				HttpStatus = 200,
				Result = pesponseData.IsSuccessCreated,
			};
		}

		[HttpPost("unrate")]
		public async Task<ResponseDto<bool>> UnratePost([FromBody] PostRateDto rateDto)
		{
			var login = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

			if (login == null)
			{
				return new ResponseDto<bool>
				{
					HttpStatus = 401,
					ErrorInfo = "such login not found!"
				};
			}

			var data = new RateData { BlogId = rateDto.BlogId, Login = login.Value, PostId = rateDto.PostId, IsNegative = rateDto.IsNegative };
			var pesponseData = await _blogsService.UnratePost(data);

			if (!pesponseData.IsSuccessCreated)
			{
				return new ResponseDto<bool>
				{
					HttpStatus = 401,
					ErrorInfo = pesponseData.ErrorInfo
				};
			}

			return new ResponseDto<bool>
			{
				HttpStatus = 200,
				Result = pesponseData.IsSuccessCreated,
			};
		}
		#endregion

		[HttpGet("show")]
		public async Task<ResponseDto<BlogTotalData>> ShowBlog(int blogId)
		{
			var login = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

			if (login == null)
			{
				return new ResponseDto<BlogTotalData>
				{
					HttpStatus = 401,
					ErrorInfo = "such login not found!"
				};
			}

			var blogData = await _blogsService.GetBlogData(blogId, login.Value);

			return new ResponseDto<BlogTotalData>
			{
				HttpStatus = 200,
				Result = blogData
			};
		}

		#region Subscriptions
		[HttpPost("subscribe")]
		public async Task<ResponseDto<bool>> SubscribeOnBlog([FromBody] int blogId)
		{
			var login = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

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
			var login = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

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
		#endregion

		[HttpPost("create-post")]
		public async Task<ResponseDto<bool>> CreatePost([FromBody] PostCreationDto postCreationDto)
		{
			var login = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

			if (login == null)
			{
				return new ResponseDto<bool>
				{
					HttpStatus = 401,
					ErrorInfo = "such login not found!"
				};
			}

			var post = new PostDto
			{
				BlogId = postCreationDto.BlogId,
				Title = postCreationDto.Title,
				Text = postCreationDto.Text,
				PublishDateOnUtc = postCreationDto.PublishDateInUtc.Value
			};

			await _blogsService.CreatePost(post, login.Value);

			return new ResponseDto<bool>
			{
				HttpStatus = 200,
				Result = true
			};
		}

		[HttpPost("delete-post")]
		public async Task<ResponseDto<bool>> DeletePost([FromBody] PostDeleteDto postDeleteDto)
		{
			var login = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

			if (login == null)
			{
				return new ResponseDto<bool>
				{
					HttpStatus = 401,
					ErrorInfo = "such login not found!"
				};
			}

			var post = new RemovePostDto
			{
				Login = login.Value,
				BlogId = postDeleteDto.BlogId,
				PostId = postDeleteDto.PostId
			};

			await _blogsService.RemovePost(post);

			return new ResponseDto<bool>
			{
				HttpStatus = 200,
				Result = true
			};
		}
	}
}