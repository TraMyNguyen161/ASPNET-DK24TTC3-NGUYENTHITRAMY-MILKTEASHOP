using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MILKTEASHOP.Models;

namespace MILKTEASHOP.Controllers
{
    public class AdminOrderController : Controller
    {
        private readonly TraSuaDbContext _context;

        public AdminOrderController(TraSuaDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var orders = _context.Orders
                .Include(o => o.OrderDetails)
                .OrderByDescending(o => o.OrderDate)
                .ToList();

            return View(orders);
        }


        public IActionResult Detail(int id)
        {
            var order = _context.Orders
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Product)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.OrderDetailToppings)
                        .ThenInclude(ot => ot.Topping)
                .FirstOrDefault(o => o.OrderId == id);

            if (order == null) return NotFound();

            return View(order);
        }

        [HttpPost]
        public IActionResult UpdateStatus(int id, int status)
        {
            var order = _context.Orders.FirstOrDefault(o => o.OrderId == id);

            if (order == null)
                return NotFound();

            order.Status = status;   
            _context.SaveChanges();

            TempData["Success"] = "Đã cập nhật trạng thái đơn hàng!";
            return RedirectToAction("Detail", new { id });
        }



        [HttpPost]
        public IActionResult Delete(int id)
        {
            var order = _context.Orders
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.OrderDetailToppings)
                .FirstOrDefault(o => o.OrderId == id);

            if (order == null)
                return NotFound();

            foreach (var od in order.OrderDetails)
            {
                _context.OrderDetailToppings.RemoveRange(od.OrderDetailToppings);
            }

            _context.OrderDetails.RemoveRange(order.OrderDetails);
            _context.Orders.Remove(order);

            _context.SaveChanges();

            TempData["Success"] = "Đã xóa đơn hàng!";
            return RedirectToAction("Index");
        }
    }
}
