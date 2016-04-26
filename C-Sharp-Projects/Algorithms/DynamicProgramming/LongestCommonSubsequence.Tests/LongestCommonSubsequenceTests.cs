namespace LongestCommonSubsequence.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LongestCommonSubsequenceTests
    {
        [TestMethod]
        public void TestSimilarStrings()
        {
            const string first = "Petko Marinov";
            const string second = "Pletko Malinov";
            const string expectedLcs = "Petko Mainov";
            var actualLcs = LongestCommonSubsequence.FindLongestCommonSubsequence(first, second);
            Assert.AreEqual(expectedLcs, actualLcs);
        }

        [TestMethod]
        public void TestSimilarLongStrings()
        {
            const string first =
                "dynamic progamming we brak the oiginal prolem to smaller sub-problms that hae the same strcture";
            const string second =
                "In dynmic prgamming we break th oriinal problem to smaler subprobems that have the sme struture";
            const string expectedLcs =
                "dynmic prgamming we brak th oiinal prolem to smaler subprobms that hae the sme strture";
            var actualLcs = LongestCommonSubsequence.FindLongestCommonSubsequence(first, second);
            Assert.AreEqual(expectedLcs, actualLcs);
        }

        [TestMethod]
        public void TestEqualStrings()
        {
            const string first = "hello";
            const string second = "hello";
            const string expectedLcs = "hello";
            var actualLcs = LongestCommonSubsequence.FindLongestCommonSubsequence(first, second);
            Assert.AreEqual(expectedLcs, actualLcs);
        }

        [TestMethod]
        public void TestNonOverlappingStrings()
        {
            const string first = "hello";
            const string second = "rakiya";
            const string expectedLcs = "";
            var actualLcs = LongestCommonSubsequence.FindLongestCommonSubsequence(first, second);
            Assert.AreEqual(expectedLcs, actualLcs);
        }

        [TestMethod]
        public void TestSingleLetterOverlappingStrings()
        {
            const string first = "hello";
            const string second = "beer";
            const string expectedLcs = "e";
            var actualLcs = LongestCommonSubsequence.FindLongestCommonSubsequence(first, second);
            Assert.AreEqual(expectedLcs, actualLcs);
        }

        [TestMethod]
        public void TestSingleLetter()
        {
            const string first = "a";
            const string second = "a";
            const string expectedLcs = "a";
            var actualLcs = LongestCommonSubsequence.FindLongestCommonSubsequence(first, second);
            Assert.AreEqual(expectedLcs, actualLcs);
        }

        [TestMethod]
        [Timeout(500)]
        public void TestPerformance3000Letters()
        {
            var first = "xxxxx" + new string('a', 3000) + "xxxxx";
            var second = "bbb" + new string('a', 3000) + "bbb";
            var expectedLcs = new string('a', 3000);
            var actualLcs = LongestCommonSubsequence.FindLongestCommonSubsequence(first, second);
            Assert.AreEqual(expectedLcs, actualLcs);
        }
    }
}