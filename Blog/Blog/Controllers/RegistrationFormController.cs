using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class RegistrationFormController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

		public IActionResult Register()
		{
			throw new NotImplementedException("register logic not implemented");
		}
    }
}