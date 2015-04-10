using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class MatrixWalkTest
{
    [TestMethod]
    public void OneDimensionTest()
    {
        var matrix = new MatrixWalk(1);
        Assert.AreEqual("  1\r\n", matrix.ToString());
    }

    [TestMethod]
    public void TwoDimensionsTest()
    {
        var matrix = new MatrixWalk(2);
        Assert.AreEqual("  1  4\r\n  3  2\r\n", matrix.ToString());
    }

    [TestMethod]
    public void ThreeDimensionsTest()
    {
        var matrix = new MatrixWalk(3);
        Assert.AreEqual("  1  7  8\r\n  6  2  9\r\n  5  4  3\r\n", matrix.ToString());
    }

    [TestMethod]
    public void FiveDimensionsTest()
    {
        var matrix = new MatrixWalk(5);
        Assert.AreEqual(string.Format(
                "{0}{5}{1}{5}{2}{5}{3}{5}{4}{5}",
                "  1 13 14 15 16",
                " 12  2 21 22 17",
                " 11 23  3 20 18",
                " 10 25 24  4 19",
                "  9  8  7  6  5",
                "\r\n"), 
                matrix.ToString());
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void NegativeDimensionsTest()
    {
        var matrix = new MatrixWalk(-1);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TooManyDimentionsTest()
    {
        var matrix = new MatrixWalk(101);
    }
}
