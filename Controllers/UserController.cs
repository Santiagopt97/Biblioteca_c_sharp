using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca_c_sharp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Biblioteca_c_sharp.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly LibraryDbContext _context;

        public UserController(ILogger<UserController> logger, LibraryDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> List()
        {
            var users = await _context.Users.ToListAsync();
            return View(users);
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }

        [HttpGet]
        public IActionResult IndexUser()
        {
            return View();
        }
    }
}