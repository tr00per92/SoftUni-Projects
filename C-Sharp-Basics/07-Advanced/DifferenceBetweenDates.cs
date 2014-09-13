using System;

class DifferenceBetweenDates
{
    static void Main()
    {
        Console.Write("Enter the first date: ");
        DateTime first = DateTime.Parse(Console.ReadLine());
        Console.Write("Enter the second date: ");
        DateTime second = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("Days between: {0}", (second - first).Days);
    }
}

