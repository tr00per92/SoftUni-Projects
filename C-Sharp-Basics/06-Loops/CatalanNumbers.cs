using System;
using System.Numerics;

class CatalanNumbers
{
    static void Main()
    {
        Console.Write("Enter n: ");
        int n = int.Parse(Console.ReadLine());
        BigInteger numerator = 1, denominator = 1;
        for (int i = n + 2; i <= 2*n; i++)
        {
            numerator *= i;
        }
        for (int i = 1; i <= n; i++)
        {
            denominator *= i;
        }
        Console.WriteLine("Catalan(n): {0}", numerator / denominator);
    }
}

