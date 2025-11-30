using MILKTEASHOP.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MILKTEASHOP.Controllers
{
    public class CartController : Controller
    {

        private readonly TraSuaDbContext _context;

        public CartController(TraSuaDbContext context)
        {
            _context = context;
        }
        public IActionResult Add(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) return NotFound();

            var cart = GetCart();

            var item = cart.FirstOrDefault(x => x.ProductId == id);

            if (item == null)
            {
                cart.Add(new CartItem
                {
                    ProductId = id,
                    ProductName = product.ProductName,
                    ImageUrl = product.ImageUrl,
                    Price = product.BasePrice,
                    Quantity = 1
                });
            }
            else
            {
                item.Quantity++;
            }

            SaveCart(cart);

            return RedirectToAction("Index");
        }
        private List<CartItem> GetCart()
        {
            var data = HttpContext.Session.GetString("CART");
            if (data == null)
                return new List<CartItem>();

            return JsonConvert.DeserializeObject<List<CartItem>>(data);
        }

        private void SaveCart(List<CartItem> cart)
        {
            HttpContext.Session.SetString("CART", JsonConvert.SerializeObject(cart));
        }

        
        public IActionResult Index()
        {
            var cart = GetCart();
            ViewBag.Toppings = _context.Toppings.ToList(); 
            return View(cart);
        }



        
        public IActionResult Remove(int id)
        {
            var cart = GetCart();
            var item = cart.FirstOrDefault(x => x.ProductId == id);

            if (item != null)
            {
                cart.Remove(item);
                SaveCart(cart);
            }

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult UpdateToppings(List<CartItem> CartItems)
        {
            var cart = GetCart();

            foreach (var ci in CartItems)
            {
                var existing = cart.FirstOrDefault(x => x.ProductId == ci.ProductId);
                if (existing != null)
                {
                    existing.SelectedToppingIds = ci.SelectedToppingIds ?? new List<int>();
                }
            }

            SaveCart(cart);
            return RedirectToAction("Index");
        }

    }
}
