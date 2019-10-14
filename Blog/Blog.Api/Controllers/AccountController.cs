using Blog.Api.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Blog.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		[HttpPost]
		public async Task<IActionResult> Authorize([FromBody]LoginDto loginData)
		{
			throw new NotImplementedException("Authorization logic not emplemented");
		}

		public async Task<IActionResult> Logout()
		{
			throw new NotImplementedException("Authorization logic not emplemented");
		}

		[HttpPost]
		public async Task<IActionResult> Register([FromBody]RegistrationDto registrationData)
		{
			throw new NotImplementedException("register logic not implemented");
		}
	}
}
