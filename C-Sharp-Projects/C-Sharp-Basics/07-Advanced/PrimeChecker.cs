using System;

class PrimeChecker
{
    static void Main()
    {
        Console.Write("Enter n: ");
        long n = long.Parse(Console.ReadLine());
        Console.WriteLine("IsPrime: {0}", IsPrime(n));
    }
    static bool IsPrime(long n)
    {        
        if (n < 2)
        {
            return false;
        }
        bool prime = true;
        for (int i = 2; i <= Math.Sqrt(n); i++)
        {
            if (n % i == 0)
            {
                prime = false;
                break;
            }
        }
        return prime;
    }
}

