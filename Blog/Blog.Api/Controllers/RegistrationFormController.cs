using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RegistrationFormController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

		public async Task<IActionResult> Register()
		{
			throw new NotImplementedException("register logic not implemented");
		}
    }
}