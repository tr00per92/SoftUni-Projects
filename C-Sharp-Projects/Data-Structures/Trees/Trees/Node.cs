namespace Trees
{
    using System.Collections.Generic;

    public class Node
    {
        public Node(int value, Node parent = null)
        {
            this.Value = value;
            this.Parent = parent;
            this.Children = new List<Node>();
        }

        public int Value { get; private set; }

        public Node Parent { get; private set; }

        public IList<Node> Children { get; private set; }
    }
}