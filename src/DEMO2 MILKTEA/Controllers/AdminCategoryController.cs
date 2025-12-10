using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MILKTEASHOP.Models;

namespace MILKTEASHOP.Controllers
{
    public class AdminCategoryController : Controller
    {
        private readonly TraSuaDbContext _context;

        public AdminCategoryController(TraSuaDbContext context)
        {
            _context = context;
        }

        
        public IActionResult Index()
        {
            var categories = _context.Categories
                .Include(c => c.Products)
                .ToList();

            return View(categories); 
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category model)
        {
            if (!ModelState.IsValid)
                return View(model);

           
            if (_context.Categories.Any(c => c.CategoryName == model.CategoryName))
            {
                ModelState.AddModelError(nameof(model.CategoryName), "Tên danh mục đã tồn tại.");
                return View(model);
            }

            _context.Categories.Add(model);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
                return NotFound();

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var category = _context.Categories.Find(model.CategoryId);
            if (category == null)
                return NotFound();

            category.CategoryName = model.CategoryName;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var category = _context.Categories
                .Include(c => c.Products)
                .FirstOrDefault(c => c.CategoryId == id);

            if (category == null)
                return NotFound();

          
            if (category.Products.Any())
            {
                TempData["Error"] = "Danh mục còn sản phẩm, không thể xóa!";
                return RedirectToAction("Index");
            }

            _context.Categories.Remove(category);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
