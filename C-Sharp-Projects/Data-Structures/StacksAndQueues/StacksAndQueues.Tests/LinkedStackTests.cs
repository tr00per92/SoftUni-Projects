namespace StacksAndQueues.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LinkedStackTests
    {
        [TestMethod]
        public void PushPopElement()
        {
            var stack = new LinkedStack<int>();
            Assert.AreEqual(0, stack.Count);

            const int Element = 8;
            stack.Push(Element);
            Assert.AreEqual(1, stack.Count);
            Assert.AreEqual(Element, stack.Pop());
            Assert.AreEqual(0, stack.Count);
        }

        [TestMethod]
        public void PushPop1000Elements()
        {
            var stack = new LinkedStack<string>();
            Assert.AreEqual(0, stack.Count);

            for (var i = 1; i <= 1000; i++)
            {
                stack.Push("element" + i);
                Assert.AreEqual(i, stack.Count);
            }

            for (var i = 1000; i >= 1; i--)
            {
                Assert.AreEqual(i, stack.Count);
                Assert.AreEqual("element" + i, stack.Pop());
            }

            Assert.AreEqual(0, stack.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PopFromEmptyStackThrowsException()
        {
            var stack = new LinkedStack<int>();
            stack.Pop();
        }

        [TestMethod]
        public void PushPopTests()
        {
            var stack = new LinkedStack<int>();
            Assert.AreEqual(0, stack.Count);

            const int Element1 = 8;
            const int Element2 = 8;
            stack.Push(Element1);
            Assert.AreEqual(1, stack.Count);
            stack.Push(Element2);
            Assert.AreEqual(2, stack.Count);
            Assert.AreEqual(Element2, stack.Pop());
            Assert.AreEqual(1, stack.Count);
            Assert.AreEqual(Element1, stack.Pop());
            Assert.AreEqual(0, stack.Count);
        }

        [TestMethod]
        public void StackToArray()
        {
            var initialArray = new[] { 3, 5, -2, 7 };
            var stack = new LinkedStack<int>();
            foreach (var number in initialArray)
            {
                stack.Push(number);
            }

            var array = stack.ToArray();
            for (var i = 0; i < array.Length; i++)
            {
                Assert.AreEqual(initialArray[3 - i], array[i]);
            }
        }

        [TestMethod]
        public void EmptyStackToArray()
        {
            var stack = new LinkedStack<DateTime>();
            CollectionAssert.AreEqual(new DateTime[0], stack.ToArray());
        }
    }
}
