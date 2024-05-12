using CST350.Services;
using Microsoft.AspNetCore.Mvc;

namespace CST350.Controllers
{
    public class GameController : Controller
    {
        public IActionResult Index()
        {
            GameService gameService = new GameService();
            return View(gameService.Display());
        }

        public IActionResult LeftClick(int ind)
        {
            GameService gameService = new GameService();
            if (!gameService.HandleLeftClick(ind))
            {
                return RedirectToAction("Lose");
            }
            if (gameService.IsWin())
            {
                return RedirectToAction("Win");
            }
            return RedirectToAction("Index");
        }

        public IActionResult RightClick(int ind) {
            return RedirectToAction("Index");
        }

        public IActionResult Lose()
        {
            GameService gameService = new GameService();
            gameService.End();
            ViewBag.win = false;
            return View("End", gameService.Display());
        }

        public IActionResult Win()
        {
            GameService gameService = new GameService();
            gameService.End();
            ViewBag.win = true;
            return View("End", gameService.Display());
        }

        public IActionResult Reset()
        {
            GameService gameService = new GameService();
            gameService.Reset();
            return RedirectToAction("Index");
        }
    }
}
