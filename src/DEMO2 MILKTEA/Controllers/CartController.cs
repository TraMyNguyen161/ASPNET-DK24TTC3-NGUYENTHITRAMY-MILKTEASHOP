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
                // ============================
        // Lấy giỏ hàng từ session
        // ============================
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

        // ============================
        // Hiển thị giỏ hàng
        // ============================
        public IActionResult Index()
        {
            var cart = GetCart();
            return View(cart);
        }

                    
        // ============================
        // XÓA 1 SẢN PHẨM KHỎI GIỎ
        // ============================
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
    }
}
