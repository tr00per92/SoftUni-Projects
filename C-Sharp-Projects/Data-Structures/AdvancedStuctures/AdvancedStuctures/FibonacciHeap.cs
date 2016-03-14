namespace AdvancedStuctures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FibonacciHeap<T> where T : IComparable<T>
    {
        private readonly IList<Node> nodes = new List<Node>();
        private Node min;

        public int Count { get; set; }

        public void Push(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            var node = new Node(value);
            this.nodes.Add(node);
            this.Count++;
            if (this.min == null || node.CompareTo(this.min) < 0)
            {
                this.min = node;
            }
        }

        public T Peek()
        {
            if (this.min == null)
            {
                throw new InvalidOperationException("The heap is empty.");
            }

            return this.min.Value;
        }

        public T Pop()
        {
            if (this.min == null)
            {
                throw new InvalidOperationException("The heap is empty.");
            }

            var result = this.min.Value;
            this.RemoveMin();
            this.Count--;

            return result;
        }

        private void RemoveMin()
        {
            foreach (var child in this.min.Children)
            {
                this.nodes.Add(child);
            }

            this.nodes.Remove(this.min);
            if (this.nodes.Any())
            {
                this.min = this.nodes.First();
                this.Consolidate();
            }
            else
            {
                this.min = null;
            }
        }

        private void Consolidate()
        {
            var upperBound = Math.Floor(Math.Log(this.Count, (1.0 + Math.Sqrt(5)) / 2.0)) + 1;
            var items = new Node[(int)upperBound];
            for (var i = 0; i < this.nodes.Count; i++)
            {
                var item = this.nodes[i];
                var itemChildren = item.Children.Count;
                while (true)
                {
                    var child = items[itemChildren];
                    if (child == null)
                    {
                        break;
                    }

                    if (item.CompareTo(child) > 0)
                    {
                        var swapNode = item;
                        item = child;
                        child = swapNode;
                    }

                    this.nodes.Remove(child);
                    item.AddChild(child);
                    items[itemChildren] = null;
                    itemChildren++;
                    i--;
                }

                items[itemChildren] = item;
            }

            this.min = null;
            foreach (var item in items.Where(item => item != null))
            {
                if (this.min == null)
                {
                    this.nodes.Clear();
                    this.min = item;
                }
                else if (item.CompareTo(this.min) < 0)
                {
                    this.min = item;
                }

                this.nodes.Add(item);
            }
        }

        private class Node : IComparable<Node>
        {
            public Node(T value)
            {
                this.Children = new List<Node>();
                this.Value = value;
            }

            public T Value { get; private set; }

            public IList<Node> Children { get; private set; }

            public int CompareTo(Node other)
            {
                return this.Value.CompareTo(other.Value);
            }

            public void AddChild(Node child)
            {
                this.Children.Add(child);
            }
        }
    }
}