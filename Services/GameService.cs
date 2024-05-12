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

        public IEnumerable<CellModel> Display()
        {
            return boardModel.board;
        }

        public bool HandleLeftClick(int ind)
        {
            boardModel.floodFill(ind);
            return boardModel.visit(ind);
        }

        public bool IsWin()
        {
            return boardModel.isWin();
        }

        public void End()
        {
            boardModel.visitAll();
        }

        public void Reset()
        {
            boardModel.reset();
        }
    }
}
