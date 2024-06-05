using System.Text;

namespace CST350.Models
{
    public class GameModel
    {
        private const int DIM = 16;
        private const int SIZE = DIM * DIM;
        private const int FREQ = 10;
        private const int NUM_LIVE = SIZE * FREQ / 100;

        public int id { get; set; }

        public List<CellModel> cells { get; set; }

        public GameModel()
        {
            this.id = 0;
            this.cells = new List<CellModel>();
            this.Init();
        }

        public GameModel(int id, string cells)
        {
            this.id = id;
            this.cells = Deserialize(cells);
            Calc();
        }

        private int Ind(int i, int j)
        {
            return (DIM * i) + j;
        }

        public string Serialize()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < cells.Count; i++)
            {
                CellModel cell = cells[i];
                if (cell.live)
                {
                    sb.Append('L');
                }
                if (cell.visited)
                {
                    sb.Append('V');
                }
                if (cell.flagged)
                {
                    sb.Append('F');
                }
                sb.Append('|');
            }
            return sb.ToString();
        }

        public List<CellModel> Deserialize(string data)
        {
            CellModel cell = new CellModel();
            List<CellModel > cells = new List<CellModel>();
            using (StringReader sr = new StringReader(data))
            {
                while (sr.Peek() >= 0)
                {
                    int next = sr.Read();
                    if (next == 'L')
                    {
                        cell.live = true;
                    }
                    if (next == 'V')
                    {
                        cell.visited = true;
                    }
                    if (next == 'F')
                    {
                        cell.flagged = true;
                    }
                    if (next == '|')
                    {
                        cells.Add(cell);
                        cell = new CellModel();
                    }
                }
            }
            return cells;
        }

        public void Init()
        {
            for (int i = 0; i < SIZE; i++)
            {
                cells.Add(new CellModel());
            }

            Random rand = new Random();
            int numLived = 0;
            while (numLived < NUM_LIVE)
            {
                int next = rand.Next(SIZE);
                cells.ElementAt(next).live = true;
                numLived++;
            }

            Calc();
        }

        private void Calc() {
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
                            if (cells.ElementAt(Ind(i + u, j + v)).live)
                            {
                                cells.ElementAt(Ind(i, j)).numLiveNeighbors++;
                            }
                        }
                    }
                }
            }
        }

        public void Flag(int ind)
        {
            cells.ElementAt(ind).flagged = !cells.ElementAt(ind).flagged;
        }

        public void Visit(int ind)
        {
            if (ind < 0 ||
                ind > cells.Count - 1 ||
                cells.ElementAt(ind).visited ||
                cells.ElementAt(ind).flagged
            )
            {
                return;
            }

            cells.ElementAt(ind).visited = true;

            if (cells.ElementAt(ind).numLiveNeighbors == 0)
            {
                FloodFill(ind);
            }
        }

        private void FloodFill(int ind)
        {
            Visit(ind + DIM);
            Visit(ind - DIM);
            if (ind % DIM > 0)
            {
                Visit(ind - 1);
                Visit(ind - DIM - 1);
                Visit(ind + DIM - 1);
            }
            if (ind % DIM < DIM - 1)
            {
                Visit(ind + 1);
                Visit(ind - DIM + 1);
                Visit(ind + DIM + 1);
            }
        }
    }
}
