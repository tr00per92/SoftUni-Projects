using System;

class CalculateGCD
{
    static void Main()
    {
        Console.Write("Enter a: ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Enter b: ");
        int b = int.Parse(Console.ReadLine());
        while (b != 0)
        {
            int gcd = b;
            b = a % b;
            a = gcd;
        }
        Console.WriteLine("GCD(a,b) = {0}", a);
    }
}

