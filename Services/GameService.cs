using CST350.Models;
using Microsoft.Identity.Client;

namespace CST350.Services
{
    public class GameService
    {
        private BoardModel boardModel;

        public GameService() {
            this.boardModel = BoardModel.Instance();
        }

        public int GetDim()
        {
            return boardModel.dim;
        }

        public IEnumerable<CellModel> Display()
        {
            return boardModel.board;
        }

        public bool HandleLeftClick(int ind)
        {
            if (boardModel.visit(ind) < 0)
            {
                return false;
            }
            boardModel.floodFill(ind);
            return true;
        }

        public void Lose()
        {
            boardModel.visitAll();
        }

        public void Reset()
        {
            boardModel.reset();
        }
    }
}
