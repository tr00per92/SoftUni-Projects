using System;

class PointInACircleOutRectangle
{
    static void Main()
    {
        Console.Write("Enter X: ");
        double x = double.Parse(Console.ReadLine());
        Console.Write("Enter Y: ");
        double y = double.Parse(Console.ReadLine());
        bool inCirle = Math.Sqrt((x - 1) * (x - 1) + (y - 1) * (y - 1)) <= 1.5;
        bool outRectangle = x > 5 || x < -1 || y > 1 || y < -1;
        Console.WriteLine((inCirle && outRectangle) ? "yes" : "no");
    }
}
