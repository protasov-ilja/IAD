using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class BlogsSearchController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }

		public IActionResult SearchBlogsByName()
		{

		}

		public IActionResult ReadBlog()
		{

		}
    }
}