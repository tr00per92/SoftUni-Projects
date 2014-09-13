using System;

class TheBiggestOfThree
{
    static void Main()
    {
        Console.WriteLine("Enter 3 numbers, each followed by [enter]:");
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());
        double biggest = a;
        if (b >= a && b >= c)
        {
            biggest = b;
        }
        else if (c > a && c > b)
        {
            biggest = c;
        }
        Console.WriteLine("Biggest: {0}", biggest);
    }
}

