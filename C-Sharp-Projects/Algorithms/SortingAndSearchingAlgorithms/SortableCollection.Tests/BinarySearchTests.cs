namespace SortableCollection.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BinarySearchTests
    {
        private static readonly Random random = new Random();

        [TestMethod]
        public void TestWithEmptyCollectionShouldReturnMissingElement()
        {
            var collection = new SortableCollection<int>();

            var result = collection.BinarySearch(0);
            var expected = Array.BinarySearch(collection.ToArray(), 0);

            Assert.AreEqual(expected, result, "No elements are present in an empty collection; method should return -1.");
        }

        [TestMethod]
        public void TestWithMissingElement()
        {
            var collection = new SortableCollection<int>(-1, 1, 5, 12, 50);

            var result = collection.BinarySearch(0);
            var expected = -1;

            Assert.AreEqual(expected, result, "Missing element should return -1.");
        }

        [TestMethod]
        public void TestWithItemAtMidpoint()
        {
            var collection = new SortableCollection<int>(1, 2, 3, 4, 5);

            var result = collection.BinarySearch(3);
            var expected = Array.BinarySearch(collection.ToArray(), 3);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestWithItemToTheLeftOfMidpoint()
        {
            var collection = new SortableCollection<int>(1, 2, 3, 4, 5);

            var result = collection.BinarySearch(2);
            var expected = Array.BinarySearch(collection.ToArray(), 2);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestWithItemToTheRightOfMidpoint()
        {
            var collection = new SortableCollection<int>(1, 2, 3, 4, 5);

            var result = collection.BinarySearch(4);
            var expected = Array.BinarySearch(collection.ToArray(), 4);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestWithMultipleMissingKeysSmallerThanMinimum()
        {
            const int numberOfChecks = 10000;
            const int numberOfElements = 1000;

            var elements = new int[numberOfElements];

            for (var i = 0; i < numberOfElements; i++)
            {
                elements[i] = random.Next(int.MinValue / 2, int.MaxValue / 2);
            }

            Array.Sort(elements);

            var collection = new SortableCollection<int>(elements);

            for (var i = 0; i < numberOfChecks; i++)
            {
                var item = random.Next(int.MinValue, collection.Items[0]);

                var result = collection.BinarySearch(item);

                Assert.AreEqual(-1, result);
            }
        }

        [TestMethod]
        public void TestWithMultipleMissingKeysLargerThanMaximum()
        {
            const int numberOfChecks = 10000;
            const int numberOfElements = 1000;

            var elements = new int[numberOfElements];

            for (var i = 0; i < numberOfElements; i++)
            {
                elements[i] = random.Next(int.MinValue / 2, int.MaxValue / 2);
            }

            Array.Sort(elements);

            var collection = new SortableCollection<int>(elements);

            for (var i = 0; i < numberOfChecks; i++)
            {
                var item = random.Next(collection.Items[collection.Count - 1], int.MaxValue);

                var result = collection.BinarySearch(item);

                Assert.AreEqual(-1, result);
            }
        }

        [TestMethod]
        public void TestWithMultipleKeys()
        {
            const int numberOfElements = 10000;

            var elements = new SortedSet<int>();

            for (var i = 0; i < numberOfElements; i++)
            {
                elements.Add(random.Next(-10000, 10000));
            }

            var collection = new SortableCollection<int>(elements);

            var elementsArray = elements.ToArray();
            foreach (var element in elements)
            {
                var expected = Array.BinarySearch(elementsArray, element);
                var result = collection.BinarySearch(element);

                Assert.AreEqual(expected, result);
            }
        }
    }
}