using System.Drawing;
using System.Net;

namespace CST350.Models
{
    public sealed class BoardModel
    {
        private const int FREQ = 5;
        private const int DIM = 16;

        public CellModel[] board { get; }

        private int numLive;
        private int numDead;
        private int numVisited;

        private static BoardModel self;

        private BoardModel()
        {
            this.board = new CellModel[DIM * DIM];
            this.numLive = DIM * DIM * FREQ / 100;
            this.numDead = (DIM * DIM) - numLive;
            this.numVisited = 0;
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

        public void Reset()
        {
            self = new BoardModel();
        }

        public bool IsWin()
        {
            return numVisited == numDead;
        }

        public void Visit(int ind)
        {
            if (
                ind < 0 ||
                ind > board.Length - 1 ||
                board[ind].visited
            )
            {
                return;
            }

            board[ind].visited = true;

            if (board[ind].live)
            {
                visitAll();
            }

            if (board[ind].numLiveNeighbors == 0)
            {
                floodFill(ind);
            }
        }

        private int ind(int i, int j)
        {
            return (DIM * i) + j;
        }
        private void visitAll()
        {
            for (int i = 0; i < board.Length; i++)
            {
                Visit(i);
            }
        }

        private void init()
        {
            for (int i = 0; i < DIM; i++)
            {
                for (int j = 0; j < DIM; j++)
                {
                    this.board[ind(i, j)] = new CellModel();
                }
            }

            Random rand = new Random();
            List<int> notLive = new List<int>();
            for (int i = 0; i < board.Length; i++)
            {
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

        private void calcLiveNeighbors()
        {
            for (int i = 0; i < DIM; i++)
            {
                for (int j = 0; j < DIM; j++)
                {
                    int prevRow = i > 0 ? -1 : 0;
                    int prevCol = j > 0 ? -1 : 0;
                    int nextRow = i < DIM - 1 ? 1 : 0;
                    int nextCol = j < DIM - 1 ? 1 : 0;
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

        private void floodFill(int ind)
        {
            Visit(ind + DIM);
            Visit(ind - DIM);
            if (ind % DIM > 0)
            {
                Visit(ind - 1);
                Visit(ind + DIM - 1);
                Visit(ind - DIM - 1);
            }
            if (ind % DIM < DIM - 1)
            {
                Visit(ind + 1);
                Visit(ind + DIM + 1);
                Visit(ind - DIM + 1);
            }
        }
    }
}
