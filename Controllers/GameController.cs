using CST350.Services;
using Microsoft.AspNetCore.Mvc;

namespace CST350.Controllers
{
    public class GameController : Controller
    {
        private GameService service;

        public GameController()
        {
            this.service = new GameService();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Display()
        {
            return PartialView("Board", service.Display());
        }

        public void Reset()
        {
            service.Reset();
        }

        public void HandleLeftClick(int ind)
        {
            service.HandleLeftClick(ind);
        }

    }
}
