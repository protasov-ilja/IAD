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
	public class BlogsSearchController : Controller
    {
		public IBlogsService _blogsService;

		public BlogsSearchController(IBlogsService blogsService)
		{
			_blogsService = blogsService;
		}

		[HttpGet("all")]
		public async Task<ResponseDto<List<BlogDto>>> SearchBlogsByName(string blogName)
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

			var data = await _blogsService.GetAllBlogs(login.Value);

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
    }
}