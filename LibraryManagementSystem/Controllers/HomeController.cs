using System.Diagnostics;
using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

namespace LibraryManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            //  En son eklenen 3 kitabı getir
            var books = _context.Books
                                .Where(b => !string.IsNullOrEmpty(b.CoverImagePath)) // Kapak resmi varsa al
                                .OrderByDescending(b => b.Id) // Son eklenenleri öne al
                                .Take(3)
                                .ToList();

            //  Eğer veritabanında hiç kitap yoksa, varsayılan kitapları ekle
            if (!books.Any())
            {
                books = new List<Book>
                {
                    new Book { Title = "The Great Adventure", Author = "John Doe", CoverImagePath = "https://source.unsplash.com/300x200/?book", Description = "An exciting journey." },
                    new Book { Title = "Knowledge is Power", Author = "Jane Smith", CoverImagePath = "https://source.unsplash.com/300x200/?library", Description = "Unlock the power of knowledge." },
                    new Book { Title = "Learning Never Ends", Author = "Mark Brown", CoverImagePath = "https://source.unsplash.com/300x200/?education", Description = "Expand your mind and horizon." }
                };
            }

            return View(books);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
