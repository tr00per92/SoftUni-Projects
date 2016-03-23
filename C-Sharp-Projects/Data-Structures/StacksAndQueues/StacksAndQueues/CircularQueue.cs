namespace StacksAndQueues
{
    using System;
    using System.Collections.Generic;

    public class CircularQueue<T>
    {
        private const int DefaultCapacity = 16;
        private T[] elements;
        private int startIndex;
        private int endIndex;

        public CircularQueue(int capacity = DefaultCapacity)
        {
            this.elements = new T[capacity];
        }

        public int Count { get; private set; }

        public void Enqueue(T element)
        {
            if (this.Count >= this.elements.Length)
            {
                this.Grow();
            }

            this.elements[this.endIndex] = element;
            this.endIndex = (this.endIndex + 1) % this.elements.Length;
            this.Count++;
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }

            var result = this.elements[this.startIndex];
            this.startIndex = (this.startIndex + 1) % this.elements.Length;
            this.Count--;

            return result;
        }

        public T[] ToArray()
        {
            var result = new T[this.Count];
            this.CopyElementsTo(result);

            return result;
        }

        private void Grow()
        {
            var newElements = new T[this.elements.Length * 2];
            this.CopyElementsTo(newElements);
            this.elements = newElements;
            this.startIndex = 0;
            this.endIndex = this.Count;
        }

        private void CopyElementsTo(IList<T> newElements)
        {
            var sourceIndex = this.startIndex;
            var destIndex = 0;
            for (var i = 0; i < this.Count; i++)
            {
                newElements[destIndex] = this.elements[sourceIndex];
                sourceIndex = (sourceIndex + 1) % this.elements.Length;
                destIndex++;
            }
        }
    }
}
