namespace SortableCollection.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Sorters;

    [TestClass]
    public class BucketSortTests
    {
        private const int NumberOfTests = 5000;
        private const int MinNumberOfElementsToSort = 1;
        private const int MaxNumberOfElementsToSort = 10000;
        private const int MaxValueCeiling = int.MaxValue;
        private static readonly Random random = new Random();

        [TestMethod]
        public void TestSortWithMultipleRandomElements()
        {
            for (var i = 0; i < NumberOfTests; i++)
            {
                var numberOfElements = random.Next(MinNumberOfElementsToSort, MaxNumberOfElementsToSort + 1);
                var maxValue = random.Next(MaxValueCeiling);

                var elements = new int[numberOfElements];

                for (var j = 0; j < numberOfElements; j++)
                {
                    elements[j] = random.Next(maxValue);
                }

                var collection = new SortableCollection<int>(elements);

                Array.Sort(elements);
                collection.Sort(new BucketSorter(maxValue));

                CollectionAssert.AreEqual(elements, collection.ToArray());
            }
        }
    }
}