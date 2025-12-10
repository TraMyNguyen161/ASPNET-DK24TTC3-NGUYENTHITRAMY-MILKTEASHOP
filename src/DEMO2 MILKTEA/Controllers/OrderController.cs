using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult Details(int id)
        {
            var order = _context.Orders
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.OrderDetailToppings)
                        .ThenInclude(odt => odt.Topping)
                .FirstOrDefault(o => o.OrderId == id);

            if (order == null)
                return NotFound();

            return View(order);
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

            order.TotalAmount = total;
            order.OrderDate = DateTime.Now;

            
            _context.Orders.Add(order);
            _context.SaveChanges();

         
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
