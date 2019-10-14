using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProfileController : Controller
    {
		public async Task<IActionResult> DeleteMassege(int messageId)
		{
			throw new NotImplementedException("register logic not implemented");
		}

		public async Task<IActionResult> CreateMassage(string messageData)
		{
			throw new NotImplementedException("register logic not implemented");
		}
    }
}