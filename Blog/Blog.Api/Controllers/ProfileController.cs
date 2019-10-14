using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProfileController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }

		public async Task<IActionResult> DeleteMassege()
		{
			throw new NotImplementedException("register logic not implemented");
		}

		public async Task<IActionResult> CreateMassege()
		{
			throw new NotImplementedException("register logic not implemented");
		}

		public async Task<IActionResult> EditProfile()
		{
			throw new NotImplementedException("register logic not implemented");
		}
    }
}