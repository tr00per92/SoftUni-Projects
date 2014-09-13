using System;

class ExchangeIfGreater
{
    static void Main()
    {
        Console.Write("Enter a: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Enter b: ");
        double b = double.Parse(Console.ReadLine());
        if (a > b)
        {
            a += b;
            b = a - b;
            a -= b;
        }
        Console.WriteLine("{0} {1}", a, b);
    }
}