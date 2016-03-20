namespace OtherStructures
{
    using System;

    public class BinaryHeap<T> where T : IComparable<T>
    {
        private const int DefaultCapacity = 16;
        private T[] elements;

        public BinaryHeap(int capacity = DefaultCapacity)
        {
            this.elements = new T[capacity];
            this.Count = 0;
        }

        public int Count { get; private set; }

        public int Capacity { get { return this.elements.Length; } }
        
        public void Insert(T item)
        {
            if (this.Count == this.elements.Length)
            {
                this.Expand();
            }

            this.elements[this.Count] = item;
            this.HeapifyUp(this.Count);
            this.Count++;
        }

        public T Peek()
        {
            return this.elements[0];
        }

        public T Pop()
        {
            var item = this.elements[0];
            this.elements[0] = this.elements[this.Count - 1];
            this.HeapifyDown(0);
            this.Count--;

            return item;
        }

        private void Expand()
        {
            var expandedArray = new T[this.Capacity * 2];
            Array.Copy(this.elements, 0, expandedArray, 0, this.elements.Length);
            this.elements = expandedArray;
        }

        private void HeapifyUp(int index)
        {
            var parentIndex = (index - 1) / 2;
            if (this.elements[index].CompareTo(this.elements[parentIndex]) > 0)
            {
                var parent = this.elements[parentIndex];
                this.elements[parentIndex] = this.elements[index];
                this.elements[index] = parent;
                this.HeapifyUp(parentIndex);
            }
        }

        private void HeapifyDown(int index)
        {
            var largestChildIndex = index;
            var leftChildIndex = 2 * index + 1;
            var rightChildIndex = leftChildIndex + 1;
            if (leftChildIndex < this.Count && this.elements[leftChildIndex].CompareTo(this.elements[largestChildIndex]) > 0)
            {
                largestChildIndex = leftChildIndex;
            }

            if (rightChildIndex < this.Count && this.elements[rightChildIndex].CompareTo(this.elements[largestChildIndex]) > 0)
            {
                largestChildIndex = rightChildIndex;
            }

            if (largestChildIndex != index)
            {
                var item = this.elements[index];
                this.elements[index] = this.elements[largestChildIndex];
                this.elements[largestChildIndex] =  item;
                this.HeapifyDown(largestChildIndex);
            }
        }
    }
}
