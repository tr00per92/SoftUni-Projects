namespace LinearDataStructurestLists
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class LinkedList<T> : IEnumerable<T>
    {
        private ListNode<T> head;

        public int Count { get; private set; }

        public void Add(T element)
        {
            var newHead = new ListNode<T>(element);
            if (this.Count > 0)
            {
                newHead.NextNode = this.head;
            }

            this.head = newHead;
            this.Count++;
        }

        public T Remove(int index)
        {
            if (index < 0 || index > this.Count - 1)
            {
                throw new InvalidOperationException("Invalid index.");
            }

            var counter = 0;
            var currentNode = this.head;
            var prevNode = this.head;
            while (counter < index)
            {
                counter++;
                prevNode = currentNode;
                currentNode = currentNode.NextNode;
            }

            prevNode.NextNode = currentNode.NextNode;
            var element = currentNode.Value;
            this.Count--;
            if (this.Count == 0)
            {
                this.head = null;
            }

            return element;
        }

        public void ForEach(Action<T> action)
        {
            foreach (var item in this)
            {
                action(item);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = this.head;
            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private class ListNode<T>
        {
            public ListNode(T value)
            {
                this.Value = value;
            }

            public T Value { get; private set; }

            public ListNode<T> NextNode { get; set; }
        }
    }
}
