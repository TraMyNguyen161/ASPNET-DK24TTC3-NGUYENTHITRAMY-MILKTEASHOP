using Microsoft.AspNetCore.Mvc;
using MILKTEASHOP.Models;
using Newtonsoft.Json;

namespace MILKTEASHOP.Controllers
{
    public class OrderController : Controller
    {
        private readonly TraSuaDbContext _context;

        public OrderController(TraSuaDbContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public IActionResult Create()
        {
            var cart = HttpContext.Session.GetString("CART");
            var cartItems = string.IsNullOrEmpty(cart)
                ? new List<CartItem>()
                : JsonConvert.DeserializeObject<List<CartItem>>(cart) ?? new List<CartItem>();

            ViewBag.CartItems = cartItems;
            ViewBag.Toppings = _context.Toppings.ToList();

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Order order)
        {
            var cart = HttpContext.Session.GetString("CART");
            var cartItems = string.IsNullOrEmpty(cart)
                ? new List<CartItem>()
                : JsonConvert.DeserializeObject<List<CartItem>>(cart) ?? new List<CartItem>();

            if (!ModelState.IsValid || !cartItems.Any())
            {
                ViewBag.CartItems = cartItems;
                ViewBag.Toppings = _context.Toppings.ToList();
                return View(order);
            }

            // 🟩 1. TÍNH TỔNG TIỀN
            decimal total = 0;

            foreach (var ci in cartItems)
            {
                decimal toppingTotal = 0;

                if (ci.SelectedToppingIds != null && ci.SelectedToppingIds.Any())
                {
                    toppingTotal = _context.Toppings
                                           .Where(t => ci.SelectedToppingIds.Contains(t.ToppingId))
                                           .Sum(t => t.Price);
                }

                total += (ci.Price + toppingTotal) * ci.Quantity;
            }

            // Gán tổng tiền vào Order
            order.TotalAmount = total;
            order.OrderDate = DateTime.Now;

            // 🟩 2. Lưu đơn trước để có OrderId
            _context.Orders.Add(order);
            _context.SaveChanges();

            // 🟩 3. Lưu OrderDetails
            foreach (var ci in cartItems)
            {
                var detail = new OrderDetail
                {
                    OrderId = order.OrderId,
                    ProductId = ci.ProductId,
                    Quantity = ci.Quantity,
                    Size = ci.Size,
                    SugarLevel = ci.SugarLevel,
                    IceLevel = ci.IceLevel,
                    PriceAtOrder = ci.Price
                };

                _context.OrderDetails.Add(detail);
                _context.SaveChanges();

                if (ci.SelectedToppingIds != null && ci.SelectedToppingIds.Any())
                {
                    var toppingList = _context.Toppings
                                              .Where(t => ci.SelectedToppingIds.Contains(t.ToppingId))
                                              .ToList();

                    foreach (var t in toppingList)
                    {
                        _context.OrderDetailToppings.Add(new OrderDetailTopping
                        {
                            OrderDetailId = detail.OrderDetailId,
                            ToppingId = t.ToppingId,
                            PriceAtOrder = t.Price
                        });
                    }
                }
            }

            _context.SaveChanges();
            HttpContext.Session.Remove("CART");

            return RedirectToAction("Success");
        }


        public IActionResult Success()
        {
            return View();
        }
    }
}
