using CST350.Models;

namespace CST350.Services
{
    public class GameService
    {
        private BoardModel boardModel;

        public GameService() {
            this.boardModel = BoardModel.Instance();
        }

        public IEnumerable<CellModel> Display()
        {
            return boardModel.board;
        }

        public string Message()
        {
            return boardModel.Message();
        }

        public void Reset()
        {
            boardModel.Reset();
        }
        public void HandleLeftClick(int ind)
        {
            boardModel.Visit(ind);
            GameDAO gameDAO = new GameDAO();
            gameDAO.Create(boardModel);
        }

        public void HandleRightClick(int ind)
        {
            boardModel.Flag(ind);
        }

    }
}
