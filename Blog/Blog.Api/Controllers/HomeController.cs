using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HomeController : Controller
	{
		public async Task<IActionResult> ShowSubscriptionBlogs()
		{
			throw new NotImplementedException("register logic not implemented");
		}

		public async Task<IActionResult> ReadBlog(string blogData)
		{
			throw new NotImplementedException("register logic not implemented");
		}
	}
}
