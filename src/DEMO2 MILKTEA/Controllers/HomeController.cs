using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; 
using MILKTEASHOP.Models;            
using DEMO2_MILKTEA.Models;          

namespace DEMO2_MILKTEA.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TraSuaDbContext _context; 

        
        public HomeController(ILogger<HomeController> logger, TraSuaDbContext context)
        {
            _logger = logger;
            _context = context; 
        }

        public IActionResult Index()
        {
            
            var products = _context.Products
                                   .Include(p => p.Category) 
                                   .Where(p => p.IsActive == true) 
                                   .ToList();

            
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Card()
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