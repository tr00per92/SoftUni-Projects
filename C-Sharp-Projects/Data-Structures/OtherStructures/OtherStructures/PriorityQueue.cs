using System;
using System.Collections.Generic;
using System.Linq;
namespace OtherStructures
{
    public class PriorityQueue<T>
    {
        private readonly BinaryHeap<Node> heap = new BinaryHeap<Node>();

        public int Count { get { return this.heap.Count; } }

        public void Enqueue(T element, int priority)
        {
            this.heap.Insert(new Node { Element = element, Priority = priority });
        }

        public T Dequeue()
        {
            return this.heap.Pop().Element;
        }

        public T Peek()
        {
            return this.heap.Peek().Element;
        }

        private class Node : IComparable<Node>
        {
            public int Priority { get; set; }

            public T Element { get; set; }

            public int CompareTo(Node other)
            {
                return this.Priority.CompareTo(other.Priority);
            }
        }
    }
}
