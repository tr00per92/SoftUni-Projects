namespace StacksAndQueues
{
    using System;

    public class LinkedStack<T>
    {
        private Node<T> firstNode;

        public int Count { get; private set; }

        public void Push(T element)
        {
            this.firstNode = new Node<T>(element, this.firstNode);
            this.Count++;
        }

        public T Pop()
        {
            if (this.firstNode == null)
            {
                throw new InvalidOperationException("The stack is empty.");
            }

            var element = this.firstNode.Value;
            this.firstNode = this.firstNode.NextNode;
            this.Count--;

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
            public Node(T value, Node<T> nextNode = null)
            {
                this.Value = value;
                this.NextNode = nextNode;
            }

            public T Value { get; private set; }

            public Node<T> NextNode { get; private set; }
        }
    }
}
