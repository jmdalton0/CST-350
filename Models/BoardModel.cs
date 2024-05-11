using System.Drawing;
using System.Net;

namespace CST350.Models
{
    public sealed class BoardModel
    {
        private int FREQ = 15;
        private int DIM = 16;

        public int dim {  get; }
        public CellModel[] board { get; }

        private int numVisited;
        private int numLive;

        private static BoardModel self;

        private BoardModel()
        {
            this.dim = DIM;
            this.board = new CellModel[dim * dim];
            this.numVisited = 0;
            this.numLive = dim * dim * FREQ / 100;
            init();
        }

        public static BoardModel Instance()
        {
            if (self == null)
            {
                self = new BoardModel();
            }
            return self;
        }

        public void reset()
        {
            self = new BoardModel();
        }

        private int ind(int i, int j)
        {
            return (dim * i) + j;
        }

        private void init()
        {
            for (int i = 0; i < dim; i++)
            {
                for (int j = 0; j < dim; j++)
                {
                    this.board[ind(i, j)] = new CellModel();
                }
            }

            Random rand = new Random();
            List<int> notLive = new List<int>();
            for (int i = 0; i < board.Length; i++) {
                notLive.Add(i);
            }
            for (int i = 0; i < numLive; i++)
            {
                int next = notLive.ElementAt(rand.Next(notLive.Count));
                board[next].live = true;
                notLive.Remove(next);
            }

            calcLiveNeighbors();
        }

        public int visit(int ind)
        {
            CellModel cell = this.board[ind];
            if (cell.live)
            {
                return -1;
            }
            cell.visited = true;
            numVisited++;
            return cell.numLiveNeighbors;
        }

        public void visitAll()
        {
            for (int i = 0; i < board.Length; i++)
            {
                board[i].visited = true;
            }
        }

        private void calcLiveNeighbors()
        {
            for (int i = 0; i < dim; i++)
            {
                for (int j = 0; j < dim; j++)
                {
                    int prevRow = i > 0 ? -1 : 0;
                    int prevCol = j > 0 ? -1 : 0;
                    int nextRow = i < dim - 1 ? 1 : 0;
                    int nextCol = j < dim - 1 ? 1 : 0;
                    for (int u = prevRow; u <= nextRow; u++)
                    {
                        for (int v = prevCol; v <= nextCol; v++)
                        {
                            if (board[ind(i + u, j + v)].live)
                            {
                                board[ind(i, j)].numLiveNeighbors++;
                            }
                        }
                    }
                }
            }
        }

        public void floodFill(int ind)
        {

        }

    }
}
