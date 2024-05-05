using CST350.Models;
using Microsoft.AspNetCore.Mvc;

namespace CST350.Controllers
{
    public class RegisterController : Controller
    {
        //private readonly YourDbContext _context;

        //public RegisterController(YourDbContext context)
        //{
            //_context = context;
        //}

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Submit(RegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Error");
            }

            //_context.Registrations.Add(model.ToEntity());
            //_context.SaveChanges();

            return View("Success");
        }
    }
}
