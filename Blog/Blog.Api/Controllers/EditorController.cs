using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EditorController : Controller
    {
		public async Task<IActionResult> SaveChanges(string profileData)
		{
			throw new NotImplementedException("Save logic not emplemented");
		}
    }
}