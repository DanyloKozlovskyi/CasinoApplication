using Casino.DataAccess.Dtos;
using Casino.DataAccess.Models;
using Casino.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Casino.Controllers
{
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;
        private readonly ILogger<UsersController> logger;
        // how much pages represent
        private const int PAGES_RANGE_SIZE = 9;

        public UsersController(IUsersService _usersService, ILogger<UsersController> _logger)
        {
            usersService = _usersService;
            logger = _logger;
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
        {
            int totalPersons = await usersService.CountUsers();
            int totalPages = (int)Math.Ceiling((double)totalPersons / pageSize);

            int startPage = Math.Max(1, page - PAGES_RANGE_SIZE / 2);
            int endPage = Math.Min(totalPages, startPage + PAGES_RANGE_SIZE - 1);

            if (endPage - startPage + 1 < PAGES_RANGE_SIZE)
            {
                startPage = Math.Max(1, endPage - PAGES_RANGE_SIZE + 1);
            }

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.StartPage = startPage;
            ViewBag.EndPage = endPage;

            var users = await usersService.GetPage(page, pageSize);
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
