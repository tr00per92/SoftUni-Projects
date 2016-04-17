namespace SortableCollection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private static readonly Random random = new Random();

        public SortableCollection()
        {
            this.Items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.Items = new List<T>(items);
        }

        public SortableCollection(params T[] items)
            : this(items.AsEnumerable())
        {
        }

        public List<T> Items { get; private set; }

        public int Count
        {
            get { return this.Items.Count; }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.Items);
        }

        public int BinarySearch(T item)
        {
            return this.BinarySearch(item, 0, this.Count - 1);
        }

        public void Shuffle()
        {
            for (var i = 0; i < this.Count; i++)
            {
                var index = i + (int)(random.NextDouble() * (this.Count - i));
                var temp = this.Items[index];
                this.Items[index] = this.Items[i];
                this.Items[i] = temp;
            }
        }

        public T[] ToArray()
        {
            return this.Items.ToArray();
        }

        public override string ToString()
        {
            return string.Join(", ", this.Items);
        }

        private int BinarySearch(T item, int start, int end)
        {
            if (start > end)
            {
                return -1;
            }

            var midPoint = start + (end - start) / 2;
            if (this.Items[midPoint].CompareTo(item) > 0)
            {
                return this.BinarySearch(item, start, midPoint - 1);
            }

            if (this.Items[midPoint].CompareTo(item) < 0)
            {
                return this.BinarySearch(item, midPoint + 1, end);
            }

            return midPoint;
        }
    }
}