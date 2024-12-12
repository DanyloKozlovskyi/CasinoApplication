using Microsoft.AspNetCore.Mvc;

namespace Casino.Controllers
{
	public class UsersController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
