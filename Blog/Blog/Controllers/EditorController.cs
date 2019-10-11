using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class EditorController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }

		public IActionResult SaveChanges()
		{
			throw new NotImplementedException("Save logic not emplemented");
		}
    }
}