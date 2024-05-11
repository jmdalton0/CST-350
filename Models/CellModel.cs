namespace CST350.Models
{
    public class CellModel
    {
        public bool live { get; set; }
        public int numLiveNeighbors { get; set; }
        public bool flagged { get; set; }
        public bool visited {  get; set; }

        public CellModel()
        {
            this.live = false;
            this.numLiveNeighbors = 0;
            this.flagged = false;
            this.visited = false;
        }
    }
}
