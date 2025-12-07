using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace MILKTEASHOP.Controllers
{
    public class AdminController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }
          
    }
}
