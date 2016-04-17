namespace SortableCollection.Sorters
{
    using System;
    using System.Collections.Generic;
    using Interfaces;

    public class QuickSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            this.Sort(collection, 0, collection.Count - 1);
        }

        private void Sort(IList<T> collection, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            var pivot = collection[start];
            var storeIndex = start + 1;
            for (var i = start + 1; i <= end; i++)
            {
                if (collection[i].CompareTo(pivot) < 0)
                {
                    this.Swap(i, storeIndex, collection);
                    storeIndex++;
                }
            }

            storeIndex--;
            this.Swap(start, storeIndex, collection);
            this.Sort(collection, start, storeIndex - 1);
            this.Sort(collection, storeIndex + 1, end);
        }

        private void Swap(int firstIndex, int secondIndex, IList<T> collection)
        {
            var temp = collection[firstIndex];
            collection[firstIndex] = collection[secondIndex];
            collection[secondIndex] = temp;
        }
    }
}