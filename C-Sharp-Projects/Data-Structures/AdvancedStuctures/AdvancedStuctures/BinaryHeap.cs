namespace AdvancedStuctures
{
    using System;
    using System.Collections.Generic;

    public class BinaryHeap<T> where T : IComparable<T>
    {
        private readonly IList<T> heap;

        public BinaryHeap()
        {
            this.heap = new List<T>();
        }

        public BinaryHeap(IEnumerable<T> elements)
        {
            this.heap = new List<T>(elements);
            for (var i = this.heap.Count / 2; i >= 0; i--)
            {
                this.HeapifyDown(i);
            }
        }

        public int Count
        {
            get { return this.heap.Count; }
        }

        public T ExtractMax()
        {
            var max = this.heap[0];
            this.heap[0] = this.heap[this.Count - 1];
            this.heap.RemoveAt(this.Count - 1);
            if (this.Count > 0)
            {
                this.HeapifyDown(0);
            }

            return max;
        }

        public T PeekMax()
        {
            return this.heap[0];
        }

        public void Insert(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            this.heap.Add(value);
            this.HeapifyUp(this.Count - 1);
        }

        private void HeapifyDown(int index)
        {
            while (true)
            {
                var leftIndex = 2 * index + 1;
                var rightIndex = 2 * index + 2;
                var largestIndex = index;

                if (leftIndex < this.Count && this.heap[leftIndex].CompareTo(this.heap[largestIndex]) > 0)
                {
                    largestIndex = leftIndex;
                }

                if (rightIndex < this.Count && this.heap[rightIndex].CompareTo(this.heap[largestIndex]) > 0)
                {
                    largestIndex = rightIndex;
                }

                if (largestIndex == index)
                {
                    break;
                }

                var old = this.heap[index];
                this.heap[index] = this.heap[largestIndex];
                this.heap[largestIndex] = old;
                index = largestIndex;
            }
        }

        private void HeapifyUp(int index)
        {
            var parentIndex = (index - 1) / 2;
            while (index > 0 && this.heap[index].CompareTo(this.heap[parentIndex]) > 0)
            {
                var parent = this.heap[parentIndex];
                this.heap[parentIndex] = this.heap[index];
                this.heap[index] = parent;
                index = parentIndex;
                parentIndex = (index - 1) / 2;
            }
        }
    }
}