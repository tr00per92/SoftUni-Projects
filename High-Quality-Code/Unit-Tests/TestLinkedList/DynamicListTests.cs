namespace TestLinkedList
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using CustomLinkedList;

    [TestClass]
    public class DynamicListTests
    {
        [TestMethod]
        public void ConstructorAndCountTest()
        {
            DynamicList<int> numbers = new DynamicList<int>();
            int count = numbers.Count;
            Assert.AreEqual(0, count, "The constructor don't create an empty list.");
        }

        [TestMethod]
        public void AddContainsAndIndexOfTest()
        {
            DynamicList<string> words = new DynamicList<string>();
            words.Add("Pesho");
            words.Add("Strahil");
            Assert.AreEqual(2, words.Count, "Error in the adding command.");

            Assert.IsFalse(words.Contains("Ivan"), "Contains method works incorectly.");
            Assert.IsTrue(words.Contains("Pesho"), "Error in adding or contains.");

            Assert.AreEqual(-1, words.IndexOf("Ivan"), "Error in indexOf method.");
            Assert.AreNotEqual(-1, words.IndexOf("Strahil"), "Error in indexOf method.");
        }

        [TestMethod]
        public void RemoveAndRemoveAtTest()
        {
            DynamicList<int> numbers = new DynamicList<int>();
            numbers.Add(5);
            numbers.Add(7);
            numbers.Add(9);

            numbers.Remove(5);
            Assert.IsFalse(numbers.Contains(5), "Remove method doesn't work correctly.");

            numbers.RemoveAt(1);
            Assert.AreEqual(-1, numbers.IndexOf(9), "RemoveAt method doesn't work correctly.");

            Assert.AreEqual(-1, numbers.Remove(13), "Error when trying to remove unexisting item.");

            Assert.AreEqual(0, numbers.Remove(7), "Wrong return value of remove method.");
        }

        [TestMethod]
        public void IndexationTest()
        {
            DynamicList<double> nums = new DynamicList<double>();
            nums.Add(2.5);
            nums.Add(4);
            nums.Add(-100);

            Assert.AreEqual(2.5, nums[0], "Error in the indexation");
            Assert.AreEqual(4, nums[1], "Error in the indexation");

            nums.Remove(4);
            Assert.AreEqual(-100, nums[1], "Error in the indexation");

            nums[1] = 250.5;
            Assert.AreEqual(250.5, nums[1], "Error in the indexation");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GettingInvalidIndexTest()
        {
            DynamicList<int> nums = new DynamicList<int>();
            Assert.AreEqual(0, nums[45]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SettingInvalidIndexTest()
        {
            DynamicList<int> nums = new DynamicList<int>();
            nums[5] = 15;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RemoveAtInvalidIndexTest()
        {
            DynamicList<int> nums = new DynamicList<int>();
            nums.RemoveAt(8);
        }
    }
}
