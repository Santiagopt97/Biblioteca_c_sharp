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
using Biblioteca_c_sharp.Models;

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

        // GET: Eliminar libro 
        public async Task<IActionResult> delete(int id)
        {
            var Book = await context.Books.FirstAsync(a => a.Id == id);
            context.Books.Remove(Book);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> ShowBook(int id)
        {
            var Book = await context.Books.FirstOrDefaultAsync(a => a.Id == id);
            return View(Book);
        }

        // GET: Crear libro
        [Route("Books/Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Crear libro

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Author,Isbn,Category,Available")] Book book)
        {
            if (ModelState.IsValid)
            {
                context.Add(book);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }


        // GET: Editar libro
        [Route("editar/{id}")]
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var book = await context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: Editar libro
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Title,Author,Isbn,Category,Available")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(book);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // para ir al index de Books
        [Route("Books/IndexBooks")]
        public IActionResult IndexBooks()
        {
            return View(context.Books.ToList());
        }

        private bool BookExists(long id)
        {
            return context.Books.Any(e => e.Id == id);
        }
    }
}