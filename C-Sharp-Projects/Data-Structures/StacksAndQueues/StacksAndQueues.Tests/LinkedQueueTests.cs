namespace StacksAndQueues.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LinkedQueue
    {
        [TestMethod]
        public void PushPopEnqueueDequeueElement()
        {
            var queue = new LinkedQueue<int>();
            Assert.AreEqual(0, queue.Count);

            const int Element = 8;
            queue.Enqueue(Element);
            Assert.AreEqual(1, queue.Count);
            Assert.AreEqual(Element, queue.Dequeue());
            Assert.AreEqual(0, queue.Count);
        }

        [TestMethod]
        public void EnqueueDequeue1000Elements()
        {
            var queue = new LinkedQueue<string>();
            Assert.AreEqual(0, queue.Count);

            for (var i = 1; i <= 1000; i++)
            {
                queue.Enqueue("element" + i);
                Assert.AreEqual(i, queue.Count);
            }

            for (var i = 1; i <= 1000; i++)
            {
                Assert.AreEqual(1001 - i, queue.Count);
                Assert.AreEqual("element" + i, queue.Dequeue());
            }

            Assert.AreEqual(0, queue.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PopFromEmptyQueueThrowsException()
        {
            var queue = new LinkedQueue<int>();
            queue.Dequeue();
        }

        [TestMethod]
        public void EnqueueDequeueTests()
        {
            var queue = new LinkedQueue<int>();
            Assert.AreEqual(0, queue.Count);

            const int Element1 = 8;
            const int Element2 = 8;
            queue.Enqueue(Element1);
            Assert.AreEqual(1, queue.Count);
            queue.Enqueue(Element2);
            Assert.AreEqual(2, queue.Count);
            Assert.AreEqual(Element1, queue.Dequeue());
            Assert.AreEqual(1, queue.Count);
            Assert.AreEqual(Element2, queue.Dequeue());
            Assert.AreEqual(0, queue.Count);
        }

        [TestMethod]
        public void QueueToArray()
        {
            var initialArray = new[] { 3, 5, -2, 7 };
            var queue = new LinkedQueue<int>();
            foreach (var number in initialArray)
            {
                queue.Enqueue(number);
            }

            var array = queue.ToArray();
            for (var i = 0; i < array.Length; i++)
            {
                Assert.AreEqual(initialArray[i], array[i]);
            }
        }

        [TestMethod]
        public void EmptyQueueToArray()
        {
            var queue = new LinkedQueue<DateTime>();
            CollectionAssert.AreEqual(new DateTime[0], queue.ToArray());
        }
    }
}
