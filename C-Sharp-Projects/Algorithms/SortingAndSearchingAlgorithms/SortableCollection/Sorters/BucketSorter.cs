namespace SortableCollection.Sorters
{
    using System;
    using System.Collections.Generic;
    using Interfaces;

    public class BucketSorter : ISorter<int>
    {
        private const string ExceptionMessage = "BucketSorter works with non-negative numbers only.";

        public BucketSorter(double max)
        {
            if (max <= 0)
            {
                throw new ArgumentException(ExceptionMessage);
            }

            this.Max = max;
        }

        public double Max { get; private set; }

        public void Sort(List<int> collection)
        {
            var buckets = new List<int>[collection.Count];
            foreach (var element in collection)
            {
                if (element < 0)
                {
                    throw new ArgumentException(ExceptionMessage);
                }

                var bucketIndex = (int)(element / this.Max * collection.Count);
                if (buckets[bucketIndex] == null)
                {
                    buckets[bucketIndex] = new List<int>();
                }

                buckets[bucketIndex].Add(element);
            }

            var sorter = new QuickSorter<int>();
            var index = 0;
            foreach (var bucket in buckets)
            {
                if (bucket != null)
                {
                    sorter.Sort(bucket);
                    foreach (var item in bucket)
                    {
                        collection[index++] = item;
                    }
                }
            }
        }
    }
}