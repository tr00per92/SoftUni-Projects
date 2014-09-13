using System;

class FibonacciNumbers
{
    static void Main()
    {
        Console.Write("Enter n: ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Fib(n) = {0}", Fib(n));
    }
    static long Fib(int n)
    {
        long first = 0, second = 1, next = 1;
        if (n == 0 || n == 1)
        {
            return 1;
        }
        else
        {
            for (int i = 0; i < n; i++)
            {
                next = first + second;
                first = second;
                second = next;
            }
            return next;
        }
    }
}

