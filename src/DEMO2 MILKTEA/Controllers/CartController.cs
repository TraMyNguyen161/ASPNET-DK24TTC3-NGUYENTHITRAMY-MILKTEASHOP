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

        
        public IActionResult Add(int id, string size = "M", string sugar = "100", string ice = "100")
        {
            var product = _context.Products.Find(id);
            if (product == null) return NotFound();

            var cart = GetCart();

           
            var existing = cart.FirstOrDefault(x =>
                x.ProductId == id &&
                x.Size == size &&
                x.SugarLevel == int.Parse(sugar) &&
                x.IceLevel == int.Parse(ice)
            );

            if (existing != null)
            {
                existing.Quantity++;
            }
            else
            {
                var item = new CartItem
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    ImageUrl = product.ImageUrl,
                    Price = product.BasePrice,
                    Quantity = 1,
                    Size = size,
                    SugarLevel = int.Parse(sugar),
                    IceLevel = int.Parse(ice),
                    SelectedToppingIds = new List<int>()
                };

                cart.Add(item);
            }

            SaveCart(cart);
            return RedirectToAction("Index");
        }

        
        private List<CartItem> GetCart()
        {
            var data = HttpContext.Session.GetString("CART");
            if (string.IsNullOrEmpty(data))
                return new List<CartItem>();

            try
            {
                return JsonConvert.DeserializeObject<List<CartItem>>(data);
            }
            catch
            {
                return new List<CartItem>();
            }
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
        public IActionResult UpdateToppings(int productId, List<int> toppingIds)
        {
            var cart = GetCart();
            var item = cart.FirstOrDefault(x => x.ProductId == productId);

            if (item != null)
            {
                item.SelectedToppingIds = toppingIds ?? new List<int>();
                SaveCart(cart);
            }

            return Ok();
        }

        [HttpPost]
        public IActionResult UpdateSize(int productId, string size)
        {
            var cart = GetCart();
            var item = cart.FirstOrDefault(x => x.ProductId == productId);

            if (item != null)
            {
                item.Size = size;
                SaveCart(cart);
            }

            return Ok();
        }

        [HttpPost]
        public IActionResult UpdateSugar(int productId, string sugar)
        {
            var cart = GetCart();
            var item = cart.FirstOrDefault(x => x.ProductId == productId);

            if (item != null)
            {
                item.SugarLevel = int.Parse(sugar);
                SaveCart(cart);
            }

            return Ok();
        }

       
        [HttpPost]
        public IActionResult UpdateIce(int productId, string ice)
        {
            var cart = GetCart();
            var item = cart.FirstOrDefault(x => x.ProductId == productId);

            if (item != null)
            {
                item.IceLevel = int.Parse(ice);
                SaveCart(cart);
            }

            return Ok();
        }
    }
}
