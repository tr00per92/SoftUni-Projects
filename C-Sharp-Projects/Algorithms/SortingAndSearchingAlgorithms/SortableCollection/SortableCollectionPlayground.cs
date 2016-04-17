namespace SortableCollection
{
    using System;
    using Sorters;

    public class SortableCollectionPlayground
    {
        private static readonly Random random = new Random();

        public static void Main()
        {
            const int numberOfElementsToSort = 22;
            const int maxValue = 150;

            var array = new int[numberOfElementsToSort];
            for (var i = 0; i < numberOfElementsToSort; i++)
            {
                array[i] = random.Next(maxValue);
            }

            var collectionToSort = new SortableCollection<int>(array);
            collectionToSort.Sort(new BucketSorter(maxValue));
            Console.WriteLine(collectionToSort);
            Console.WriteLine();

            collectionToSort.Shuffle();
            Console.WriteLine(collectionToSort);
            Console.WriteLine();

            collectionToSort.Sort(new QuickSorter<int>());
            Console.WriteLine(collectionToSort);
            Console.WriteLine();

            collectionToSort.Shuffle();
            Console.WriteLine(collectionToSort);
            Console.WriteLine();

            collectionToSort.Sort(new MergeSorter<int>());
            Console.WriteLine(collectionToSort);
        }
    }
}