namespace ShortestPath
{
    using System;

    public class Node : IComparable<Node>
    {
        public Node(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; set; }

        public int Col { get; private set; }
	
        public int Distance { get; set; }
	
        public Node PreviousNode { get; set; }

        public int CompareTo(Node other)
        {
            return this.Distance.CompareTo(other.Distance);
        }
    }
}
