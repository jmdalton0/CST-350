using CST350.Models;
using CST350.Services;
using Microsoft.AspNetCore.Mvc;

namespace CST350.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Submit(RegistrationViewModel model)
        {
            SecurityService securityService = new SecurityService();
            if (securityService.Register(model))
            {
                return RedirectToAction("Game");
            }
            return View("Error");
        }
    }
}
