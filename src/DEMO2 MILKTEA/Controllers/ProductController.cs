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

        // Danh sách sản phẩm
        public IActionResult List(string search = "")
        {
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
    }
}
