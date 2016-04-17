namespace SortableCollection.Sorters
{
    using System;
    using System.Collections.Generic;
    using Interfaces;

    public class HeapSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            var heap = new Heap(collection);
            for (var i = collection.Count - 1; i >= 0; i--)
            {
                collection[i] = heap.ExtractMax();
            }
        }

        private class Heap
        {
            private readonly IList<T> heap;

            public Heap(IEnumerable<T> elements)
            {
                this.heap = new List<T>(elements);
                for (var i = this.heap.Count / 2; i >= 0; i--)
                {
                    this.HeapifyDown(i);
                }
            }

            private int Count
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
        }
    }
}