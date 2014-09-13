using System;

class Fibonacci
{
    static void Main()
    {
        Console.Write("Enter n: ");
        int n = int.Parse(Console.ReadLine());
        long first = 0, second = 1, third = 1;
        for (int i = 0; i < n; i++)
        {
            Console.Write(first + " ");
            third = first + second;
            first = second;
            second = third;
        }
        Console.WriteLine();
    }
}