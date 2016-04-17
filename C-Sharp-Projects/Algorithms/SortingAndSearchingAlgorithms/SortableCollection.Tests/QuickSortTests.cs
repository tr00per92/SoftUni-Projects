namespace SortableCollection.Tests
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Sorters;

    [TestClass]
    public class QuickSortTests
    {
        private static readonly ISorter<int> testSorter = new QuickSorter<int>();
        private static readonly Random random = new Random();

        [TestMethod]
        public void TestSortWithNoElements()
        {
            var emptyCollection = new SortableCollection<int>();
            emptyCollection.Sort(testSorter);

            CollectionAssert.AreEqual(
                new int[0],
                emptyCollection.ToArray(),
                "Sorting empty collection should have no effect.");
        }

        [TestMethod]
        public void TestSortWithOneElement()
        {
            var collection = new SortableCollection<int>(1);
            collection.Sort(testSorter);

            CollectionAssert.AreEqual(
                new[] { 1 },
                collection.ToArray(),
                "Sorting collection with single element should have no effect.");
        }

        [TestMethod]
        public void TestSortWithTwoElements()
        {
            var collection = new SortableCollection<int>(1, -5);
            collection.Sort(testSorter);

            CollectionAssert.AreEqual(
                new[] { -5, 1 },
                collection.ToArray(),
                "Sort method should sort the elements in ascending order.");
        }

        [TestMethod]
        public void TestSortWithMultipleElements()
        {
            var collection = new SortableCollection<int>(3, 44, 38, 5, 47, 15, 36, 26, 27, 2, 46, 4, 19, 50, 48);
            var copy = new[] { 3, 44, 38, 5, 47, 15, 36, 26, 27, 2, 46, 4, 19, 50, 48 };

            collection.Sort(testSorter);
            Array.Sort(copy);

            CollectionAssert.AreEqual(
                copy,
                collection.ToArray(),
                "Sort method should sort the elements in ascending order.");
        }

        [TestMethod]
        public void TestSortWithMultipleElementsMultipleTimes()
        {
            const int numberOfAttempts = 10000;
            const int maxNumberOfElements = 1000;

            for (var i = 0; i < numberOfAttempts; i++)
            {
                var numberOfElements = random.Next(0, maxNumberOfElements + 1);

                var originalElements = new List<int>(maxNumberOfElements);

                for (var j = 0; j < numberOfElements; j++)
                {
                    originalElements.Add(random.Next(int.MinValue, int.MaxValue));
                }

                var collection = new SortableCollection<int>(originalElements);

                originalElements.Sort();
                collection.Sort(testSorter);

                CollectionAssert.AreEqual(
                    originalElements,
                    collection.ToArray(),
                    "Sort method should sort the elements in ascending order.");
            }
        }
    }
}