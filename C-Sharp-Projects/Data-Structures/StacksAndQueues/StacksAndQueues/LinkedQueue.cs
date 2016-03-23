namespace StacksAndQueues
{
    using System;

    public class LinkedQueue<T>
    {
        private Node<T> firstNode;
        private Node<T> lastNode; 

        public int Count { get; private set; }

        public void Enqueue(T element)
        {
            if (this.firstNode == null)
            {
                this.firstNode = this.lastNode = new Node<T>(element);
            }
            else
            {
                this.lastNode = this.lastNode.NextNode = new Node<T>(element);
            }

            this.Count++;
        }

        public T Dequeue()
        {
            if (this.firstNode == null)
            {
                throw new InvalidOperationException("The queue is empty.");
            }

            this.Count--;
            var element = this.firstNode.Value;
            this.firstNode = this.firstNode.NextNode;
            if (this.firstNode == null)
            {
                this.lastNode = null;
            }
            
            return element;
        }

        public T[] ToArray()
        {
            var result = new T[this.Count];
            var node = this.firstNode;
            for (var i = 0; i < this.Count; i++)
            {
                result[i] = node.Value;
                node = node.NextNode;
            }

            return result;
        }

        private class Node<T>
        {
            public Node(T value)
            {
                this.Value = value;
            }

            public T Value { get; private set; }

            public Node<T> NextNode { get; set; }
        }
    }
}
