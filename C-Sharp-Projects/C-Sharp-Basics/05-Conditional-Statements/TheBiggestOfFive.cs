using System;

class TheBiggestOfFive
{
    static void Main()
    {
        Console.WriteLine("Enter 5 numbers, each followed by [enter]:");
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());
        double d = double.Parse(Console.ReadLine());
        double e = double.Parse(Console.ReadLine());
        double biggest = a;
        if (b >= a && b >= c && b >= d && b >= e)
        {
            biggest = b;
        }
        else if (c >= a && c >= b && c >= d && c >= e)
        {
            biggest = c;
        }
        else if (d >= a && d >= b && d >= c && d >= e)
        {
            biggest = d;
        }
        else if (e > a && e > b && e > d && e > c)
        {
            biggest = e;
        }
        Console.WriteLine("Biggest: {0}", biggest);
    }
}

