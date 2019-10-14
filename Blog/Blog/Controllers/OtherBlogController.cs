﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
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