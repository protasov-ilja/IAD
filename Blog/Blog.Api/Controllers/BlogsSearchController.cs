using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BlogsSearchController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }

		public async Task<IActionResult> SearchBlogsByName()
		{
			throw new NotImplementedException("register logic not implemented");
		}

		public async Task<IActionResult> ReadBlog()
		{
			throw new NotImplementedException("register logic not implemented");
		}
    }
}