using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OtherBlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

		public async Task<IActionResult> RatePost()
		{
			throw new NotImplementedException("register logic not implemented");
		}

		public async Task<IActionResult> SubscribeOnBlog()
		{
			throw new NotImplementedException("register logic not implemented");
		}
    }
}