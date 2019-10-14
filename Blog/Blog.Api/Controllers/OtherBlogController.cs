using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OtherBlogController : Controller
    {
		public async Task<IActionResult> RatePost(string rateData)
		{
			throw new NotImplementedException("register logic not implemented");
		}

		public async Task<IActionResult> SubscribeOnBlog(string blogData)
		{
			throw new NotImplementedException("register logic not implemented");
		}
    }
}