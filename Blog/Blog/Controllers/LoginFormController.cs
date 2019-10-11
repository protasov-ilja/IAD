using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
	public class LoginFormController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Login()
		{
			throw new NotImplementedException("Authorization logic not emplemented");
		}

		public IActionResult Logout()
		{
			throw new NotImplementedException("Authorization logic not emplemented");
		}
    }
}