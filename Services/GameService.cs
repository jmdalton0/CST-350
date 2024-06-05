using CST350.Models;

namespace CST350.Services
{
    public class GameService
    {
        private GameModel gameModel;
        private GameDAO gameDAO;

        public GameService() {
            this.gameModel = new GameModel();
            this.gameDAO = new GameDAO();
        }

        public GameService(GameModel gameModel)
        {
            this.gameModel = gameModel;
            this.gameDAO = new GameDAO();
        }
        public GameModel NewGame()
        {
            gameDAO.Create(gameModel);
            return gameModel;
        }

        public List<GameModel> AllGames()
        {
            return gameDAO.AllGames();
        }

        public GameModel OneGame(int id)
        {
            return gameDAO.GetById(id);
        }

        public void Delete(int id)
        {
            gameDAO.Delete(id);
        }

        public GameModel LeftClick(int ind)
        {
            gameModel.Visit(ind);
            if (gameDAO.GetById(gameModel.id) != null)
            {
                gameDAO.Update(gameModel);
            }
            return gameModel;
        }

        public GameModel RightClick(int ind)
        {
            gameModel.Flag(ind);
            if (gameDAO.GetById(gameModel.id) != null)
            {
                gameDAO.Update(gameModel);
            }
            return gameModel;
        }
    }
}
