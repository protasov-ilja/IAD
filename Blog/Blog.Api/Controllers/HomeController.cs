using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
	[Route("api/[controller]")]
	[Authorize]
	[ApiController]
	public class HomeController : Controller
	{
		[HttpGet("my-name")]
		public string[] GetMyName()
		{
			var nameIdentifier = this.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

			return new string[] { nameIdentifier?.Value, "Ilya" };
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
