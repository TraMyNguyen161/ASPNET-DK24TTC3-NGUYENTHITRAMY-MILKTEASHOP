using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Cần dòng này để dùng lệnh .Include
using MILKTEASHOP.Models;            // Namespace chứa Product và DbContext (quan trọng)
using DEMO2_MILKTEA.Models;          // Namespace chứa ErrorViewModel (của project cũ)

namespace DEMO2_MILKTEA.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TraSuaDbContext _context; // 1. Khai báo biến để lưu kết nối DB

        // 2. Inject DbContext vào Constructor (Hàm khởi tạo)
        public HomeController(ILogger<HomeController> logger, TraSuaDbContext context)
        {
            _logger = logger;
            _context = context; // Gán context vào biến để dùng
        }

        public IActionResult Index()
        {
            // 3. Lấy danh sách sản phẩm từ Database
            var products = _context.Products
                                   .Include(p => p.Category) // Lấy kèm tên Danh mục (nếu cần hiển thị)
                                   .Where(p => p.IsActive == true) // Chỉ lấy món đang bán (tùy chọn)
                                   .ToList();

            // 4. Truyền dữ liệu (Model) sang View
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Card()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}