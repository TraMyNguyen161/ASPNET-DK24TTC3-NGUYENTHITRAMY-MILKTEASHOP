using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MILKTEASHOP.Models;
using Microsoft.EntityFrameworkCore;

namespace MILKTEASHOP.Controllers
{
    public class ProductController : Controller
    {
        private readonly TraSuaDbContext _context;

        public ProductController(TraSuaDbContext context)
        {
            _context = context;
        }
        
        public IActionResult List(string search = "")
        {
            ViewBag.Categories = _context.Categories.ToList();
            var products = _context.Products.Include(x => x.Category).AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                products = products.Where(x => x.ProductName.Contains(search));
            }

            return View(products.ToList());
        }

        
        public IActionResult Detail(int id)
        {
            var product = _context.Products
                .Include(x => x.Category)
                .FirstOrDefault(x => x.ProductId == id);

            if (product == null)
                return NotFound();

            var related = _context.Products
                .Where(x => x.CategoryId == product.CategoryId && x.ProductId != id)
                .Take(4).ToList();

            ViewBag.Related = related;

            return View(product);
        }
        
        [HttpPost]
        public IActionResult Create(Product product, IFormFile imageFile)
        {
            if (ModelState.IsValid)
            {
               
                if (imageFile != null && imageFile.Length > 0)
                {
                    string fileName = Guid.NewGuid() + Path.GetExtension(imageFile.FileName);
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        imageFile.CopyTo(stream);
                    }

                    product.ImageUrl = "/images/" + fileName;
                }

                _context.Products.Add(product);
                _context.SaveChanges();

                return RedirectToAction("List");
            }

            ViewBag.Categories = _context.Categories.ToList();
            return View(product);
        }
        
        public IActionResult Category(int id)
        {
            
            ViewBag.Categories = _context.Categories.ToList();

           
            var products = _context.Products
                .Include(p => p.Category)
                .Where(p => p.CategoryId == id)
                .ToList();

            return View("List", products); 
        }
        public IActionResult MilkTea()
        {
            ViewBag.Categories = _context.Categories.ToList();

            var data = _context.Products
                .Include(p => p.Category)
                .Where(p => p.Category.CategoryName == "Trà sữa")
                .ToList();

            return View("CategoryView", data);
        }

        public IActionResult FruitTea()
        {
            ViewBag.Categories = _context.Categories.ToList();

            var data = _context.Products
                .Include(p => p.Category)
                .Where(p => p.Category.CategoryName == "Trà trái cây")
                .ToList();

            return View("CategoryView", data);
        }

        public IActionResult Yogurt()
        {
            ViewBag.Categories = _context.Categories.ToList();

            var data = _context.Products
                .Include(p => p.Category)
                .Where(p => p.Category.CategoryName == "Sữa chua")
                .ToList();

            return View("CategoryView", data);
        }




    }
}
