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
        // === Hiển thị danh sách sản phẩm và tìm kiếm ===
        // Danh sách sản phẩm
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

        // Chi tiết sản phẩm
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
                // Lưu ảnh
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
        // LỌC SẢN PHẨM THEO DANH MỤC
        public IActionResult Category(int id)
        {
            // Lấy danh sách danh mục cho sidebar
            ViewBag.Categories = _context.Categories.ToList();

            // Lấy sản phẩm theo category
            var products = _context.Products
                .Include(p => p.Category)
                .Where(p => p.CategoryId == id)
                .ToList();

            return View("List", products); // dùng lại view List.cshtml
        }


    }
}
