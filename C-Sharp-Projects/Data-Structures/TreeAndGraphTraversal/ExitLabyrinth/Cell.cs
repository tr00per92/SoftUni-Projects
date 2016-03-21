namespace ExitLabyrinth
{
    public class Cell
    {
        public int X { get; set; }

        public int Y { get; set; }

        public char Direction { get; set; }

        public Cell PreviousCell { get; set; }
    }
}