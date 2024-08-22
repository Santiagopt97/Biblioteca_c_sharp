using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca_c_sharp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Biblioteca_c_sharp.Controllers
{
    [Route("[controller]")]
    public class BooksController : Controller
    {
        private readonly LibraryDbContext context;

        public BooksController(LibraryDbContext _context)
        {
            context = _context;
        } 


        // public BooksController(ILogger<BooksController> logger)
        // {
        //     _logger = logger;
        // }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }

        public async Task<IActionResult> delete (int id)
        {
            var Book = await context.Books.FirstAsync(a => a.Id == id);
            context.Books.Remove(Book);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}