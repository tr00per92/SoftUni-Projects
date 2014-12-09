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
        BigInteger result = 1;
        for (int i = k + 1; i <= n; i++)
        {
            result *= i;
        }
        Console.WriteLine("n! / k! = {0}", result);
    }
}

