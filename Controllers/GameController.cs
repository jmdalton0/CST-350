using CST350.Services;
using Microsoft.AspNetCore.Mvc;

namespace CST350.Controllers
{
    public class GameController : Controller
    {
        public IActionResult Index()
        {
            GameService gameService = new GameService();
            ViewBag.DIM = gameService.GetDim();
            return View(gameService.Display());
        }

        public IActionResult LeftClick(int ind)
        {
            GameService gameService = new GameService();
            if (!gameService.HandleLeftClick(ind))
            {
                return RedirectToAction("Lose");
            }
            return RedirectToAction("Index");
        }

        public IActionResult RightClick(int ind) {
            return RedirectToAction("Index");
        }

        public IActionResult Lose()
        {
            GameService gameService = new GameService();
            gameService.Lose();
            return RedirectToAction("Index");
        }

        public IActionResult Reset()
        {
            GameService gameService = new GameService();
            gameService.Reset();
            return RedirectToAction("Index");
        }
    }
}
