using Casino.DataAccess.Dtos;
using Casino.DataAccess.Models;
using Casino.Services;
using Microsoft.AspNetCore.Mvc;

namespace Casino.Controllers
{
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;
        private readonly ILogger<UsersController> logger;
        // AddSingleton
        public UsersController(IUsersService _usersService, ILogger<UsersController> _logger)
        {
            usersService = _usersService;
            logger = _logger;
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = await usersService.GetUsers();
            return View(users);
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> Create(UserCreate userCreate)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Errors = ModelState.Values.SelectMany(v => v.Errors).
                    Select(e => e.ErrorMessage).ToList();
                return View(userCreate);
            }
            User user = await usersService.AddUser(userCreate);

            return RedirectToAction("Index", "Users");
        }
    }
}
