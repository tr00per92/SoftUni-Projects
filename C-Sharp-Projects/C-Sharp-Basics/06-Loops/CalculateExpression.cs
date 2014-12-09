using System;
using System.Numerics;

class CalculateExpression
{
    static void Main()
    {
        Console.Write("Enter n: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter k(k<n): ");
        int k = int.Parse(Console.ReadLine());
        BigInteger numerator = 1, denominator = 1;
        for (int i = k + 1; i <= n; i++)
        {
            numerator *= i;
        }
        for (int i = 1; i <= n - k; i++)
        {
            denominator *= i;
        }
        Console.WriteLine("Result: {0}", numerator / denominator);
    }
}

