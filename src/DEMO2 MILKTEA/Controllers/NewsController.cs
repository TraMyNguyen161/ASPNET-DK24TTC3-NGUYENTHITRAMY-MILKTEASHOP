using Microsoft.AspNetCore.Mvc;

namespace MILKTEASHOP.Controllers
{
    public class NewsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult TranChauDuongDen()
        {
            return View();
        }

        public IActionResult TopTopping()
        {
            return View();
        }

        public IActionResult UongTraSuaKhongTangCan()
        {
            return View();
        }
    }
}
