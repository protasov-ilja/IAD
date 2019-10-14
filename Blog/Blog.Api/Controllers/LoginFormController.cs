using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LoginFormController : ControllerBase
	{
		public LoginFormController()
		{

		}

		public IActionResult Index()
		{
			return View();
		}

		public async Task<IActionResult> Login()
		{
			throw new NotImplementedException("Authorization logic not emplemented");
		}

		public async Task<IActionResult> Logout()
		{
			throw new NotImplementedException("Authorization logic not emplemented");
		}
    }
}