using CST350.Models;
using CST350.Services;
using Microsoft.AspNetCore.Mvc;

namespace CST350.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase 
    {
        GameService service;

        public GameController()
        {
            this.service = new GameService();
        }

        [HttpGet]
        public ActionResult<IEnumerable<GameModel>> Index()
        {
            return service.AllGames();
        }

        [HttpGet("{id}")]
        public ActionResult<GameModel> OneGame(int id)
        {
            return service.OneGame(id);
        }

        [HttpDelete("{id}")]
        public EmptyResult Delete(int id)
        {
            service.Delete(id);
            return new EmptyResult();
        }

        [HttpGet("new")]
        public ActionResult<GameModel> NewGame()
        {
            return service.NewGame();
        }

        [HttpPost("leftClick")]
        public ActionResult<GameModel> LeftClick(int ind, GameModel gameModel)
        {
            this.service = new GameService(gameModel);
            return service.LeftClick(ind);
        }

        [HttpPost("rightCLick")]
        public ActionResult<GameModel> rightClick(int ind, GameModel gameModel)
        {
            this.service = new GameService(gameModel);
            return service.RightClick(ind);
        }

    }
}
