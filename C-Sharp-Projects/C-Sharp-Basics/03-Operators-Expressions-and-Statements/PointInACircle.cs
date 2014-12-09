using System;

class PointInACircle
{
    static void Main()
    {
        Console.Write("Enter X: ");
        double x = double.Parse(Console.ReadLine());
        Console.Write("Enter Y: ");
        double y = double.Parse(Console.ReadLine());
        bool inside = Math.Sqrt(x * x + y * y) <= 2;
        Console.WriteLine("Inside: " + inside);
    }
}
