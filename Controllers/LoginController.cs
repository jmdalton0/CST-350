using CST350.Models;
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
            if (!ModelState.IsValid)
            {
                return View("Error");
            }

            return View("Success");
        }
    }
}
