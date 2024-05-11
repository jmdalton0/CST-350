using CST350.Models;
using CST350.Services;
using Microsoft.AspNetCore.Mvc;

namespace CST350.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Submit(LoginViewModel model)
        {
            SecurityService securityService = new SecurityService();
            if (securityService.Login(model)) {
                return RedirectToAction("Index", "Game");
            }
            return View("Error");
        }
    }
}
