using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MILKTEASHOP.Models;

namespace MILKTEASHOP.Controllers
{
    public class AdminProductController : Controller
    {
        private readonly TraSuaDbContext _context;

        public AdminProductController(TraSuaDbContext context)
        {
            _context = context;
        }

        
        public IActionResult Index(string search = "")
        {
            var products = _context.Products
                .Include(p => p.Category)
                .Where(p => search == "" || p.ProductName.Contains(search))
                .OrderByDescending(p => p.ProductId)
                .ToList();

            ViewBag.Search = search;

            return View(products);
        }



        public IActionResult Create()
        {
            ViewBag.Categories = _context.Categories
                .Select(c => new SelectListItem
                {
                    Value = c.CategoryId.ToString(),
                    Text = c.CategoryName
                })
                .ToList();

            return View();
        }



        [HttpPost]
        public IActionResult Create(Product p)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(p);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Categories = _context.Categories.ToList();
            return View(p);
        }



        [HttpPost]
        public IActionResult Edit(Product model, IFormFile imageFile)
        {
            if (!ModelState.IsValid)
            {
                
                ViewBag.Categories = new SelectList(
                    _context.Categories.ToList(),
                    "CategoryId",
                    "CategoryName",
                    model.CategoryId
                );

                return View(model);
            }

            var product = _context.Products.Find(model.ProductId);
            if (product == null) return NotFound();

            product.ProductName = model.ProductName;
            product.BasePrice = model.BasePrice;
            product.CategoryId = model.CategoryId;
            product.Description = model.Description;
            product.IsActive = model.IsActive;
            if (imageFile != null && imageFile.Length > 0)
            {
              
                var rootPath = Directory.GetCurrentDirectory();
                var uploadFolder = Path.Combine(rootPath, "wwwroot", "images", "products");

                if (!Directory.Exists(uploadFolder))
                {
                    Directory.CreateDirectory(uploadFolder);
                }

             
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                var filePath = Path.Combine(uploadFolder, fileName);

              
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }

                product.ImageUrl = "/images/products/" + fileName;
            }


            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) return NotFound();

            ViewBag.Categories = new SelectList(
                _context.Categories.ToList(),
                "CategoryId",
                "CategoryName",
                product.CategoryId
            );

            return View(product);
        }

        public IActionResult Delete(int id)
        {
            var p = _context.Products.Find(id);
            if (p == null) return NotFound();

            _context.Products.Remove(p);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
