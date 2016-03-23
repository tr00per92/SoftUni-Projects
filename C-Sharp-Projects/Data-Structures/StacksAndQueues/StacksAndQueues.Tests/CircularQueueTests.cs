namespace StacksAndQueues.Tests
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UnitTestsCircularQueue
    {
        [TestMethod]
        public void EnqueueEmptyQueueShouldAddElement()
        {
            // Arrange
            var queue = new CircularQueue<int>();

            // Act
            queue.Enqueue(5);

            // Assert
            Assert.AreEqual(1, queue.Count);
        }

        [TestMethod]
        public void EnqueueDequeShouldWorkCorrectly()
        {
            // Arrange
            var queue = new CircularQueue<string>();
            const string element = "some value";

            // Act
            queue.Enqueue(element);
            var elementFromQueue = queue.Dequeue();

            // Assert
            Assert.AreEqual(0, queue.Count);
            Assert.AreEqual(element, elementFromQueue);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DequeueEmptyQueueThrowsException()
        {
            // Arrange
            var queue = new CircularQueue<int>();

            // Act
            queue.Dequeue();

            // Assert: expect and exception
        }

        [TestMethod]
        public void EnqueueDequeue100ElementsShouldWorkCorrectly()
        {
            // Arrange
            var queue = new CircularQueue<int>();
            const int NumberOfElements = 1000;

            // Act
            for (var i = 0; i < NumberOfElements; i++)
            {
                queue.Enqueue(i);
            }

            // Assert
            for (var i = 0; i < NumberOfElements; i++)
            {
                Assert.AreEqual(NumberOfElements - i, queue.Count);
                var element = queue.Dequeue();
                Assert.AreEqual(i, element);
                Assert.AreEqual(NumberOfElements - i - 1, queue.Count);
            }
        }

        [TestMethod]
        public void CircularQueueEnqueueDequeueManyChunksShouldWorkCorrectly()
        {
            // Arrange
            var queue = new CircularQueue<int>();
            const int Chunks = 100;

            // Act & Assert in a loop
            var value = 1;
            for (var i = 0; i < Chunks; i++)
            {
                Assert.AreEqual(0, queue.Count);
                var chunkSize = i + 1;
                for (var counter = 0; counter < chunkSize; counter++)
                {
                    Assert.AreEqual(value - 1, queue.Count);
                    queue.Enqueue(value);
                    Assert.AreEqual(value, queue.Count);
                    value++;
                }

                for (var counter = 0; counter < chunkSize; counter++)
                {
                    value--;
                    Assert.AreEqual(value, queue.Count);
                    queue.Dequeue();
                    Assert.AreEqual(value - 1, queue.Count);
                }

                Assert.AreEqual(0, queue.Count);
            }
        }

        [TestMethod]
        public void Enqueue500ElementsToArrayShouldWorkCorrectly()
        {
            // Arrange
            var array = Enumerable.Range(1, 500).ToArray();
            var queue = new CircularQueue<int>();

            // Act
            foreach (var num in array)
            {
                queue.Enqueue(num);
            }

            var arrayFromQueue = queue.ToArray();

            // Assert
            CollectionAssert.AreEqual(array, arrayFromQueue);
        }

        [TestMethod]
        public void InitialCapacity1EnqueueDequeue20ElementsShouldWorkCorrectly()
        {
            // Arrange
            const int ElementsCount = 20;
            const int InitialCapacity = 1;

            // Act
            var queue = new CircularQueue<int>(InitialCapacity);
            for (var i = 0; i < ElementsCount; i++)
            {
                queue.Enqueue(i);
            }

            // Assert
            Assert.AreEqual(ElementsCount, queue.Count);
            for (var i = 0; i < ElementsCount; i++)
            {
                var elementFromQueue = queue.Dequeue();
                Assert.AreEqual(i, elementFromQueue);
            }

            Assert.AreEqual(0, queue.Count);
        }
    }
}
