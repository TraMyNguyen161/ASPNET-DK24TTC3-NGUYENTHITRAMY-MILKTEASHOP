using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MILKTEASHOP.Models;

public class AccountController : Controller
{
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string username, string password)
    {
       
        if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
        {
           
            HttpContext.Session.SetString("USERNAME", username);

            return RedirectToAction("Index", "Home");
        }

        ViewBag.Error = "Sai tài khoản hoặc mật khẩu";
        return View();
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(string fullname, string email, string username, string password)
    {
    
        HttpContext.Session.SetString("USERNAME", username);

        return RedirectToAction("Index", "Home");
    }


    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index", "Home");
    }
    
}
