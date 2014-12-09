using System;

class NumberComparer
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Enter another number: ");
        double b = double.Parse(Console.ReadLine());
        Console.WriteLine("Greater : {0}", a > b ? a : b);
    }
}

