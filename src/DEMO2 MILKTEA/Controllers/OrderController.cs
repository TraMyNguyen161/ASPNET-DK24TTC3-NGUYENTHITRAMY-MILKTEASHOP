using Microsoft.AspNetCore.Mvc;
using MILKTEASHOP.Models;
using Microsoft.EntityFrameworkCore;

namespace MILKTEASHOP.Controllers
{
    public class OrderController : Controller
    {
        private readonly TraSuaDbContext _context;

        public OrderController(TraSuaDbContext context)
        {
            _context = context;
        }

        // Trang tạo order
        [HttpGet]
        public IActionResult Create(int productId)
        {
            ViewBag.ProductId = productId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {
                order.OrderDate = DateTime.Now;
                _context.Orders.Add(order);
                _context.SaveChanges();
                return RedirectToAction("Detail", new { id = order.OrderId });
            }
            return View(order);
        }


        public IActionResult Success()
        {
            return View();
        }
    }
}
