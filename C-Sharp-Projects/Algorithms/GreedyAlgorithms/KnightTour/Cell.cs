namespace KnightTour
{
    public struct Cell
    {
        public Cell(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; }

        public int Col { get; }

        public override string ToString()
        {
            return $"[{this.Row} {this.Col}]";
        }
    }
}
