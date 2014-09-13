using System;

class TrailingZerosInN
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        long num = long.Parse(Console.ReadLine());
        long zeros = 0, divisor = 5;
        while (num / divisor > 0)
        {
            zeros += num / divisor;
            divisor *= 5;
        }
        Console.WriteLine(zeros);
    }
}

