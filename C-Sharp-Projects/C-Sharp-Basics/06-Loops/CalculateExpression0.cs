using System;

class CalculateExpression
{
    static void Main()
    {
        Console.Write("Enter n: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter x: ");
        int x = int.Parse(Console.ReadLine());
        double fact = 1, pow = 1, sum = 1;
        for (int i = 1; i <= n; i++)
        {
            fact *= i;
            pow *= x;
            sum += fact / pow;
        }
        Console.WriteLine("S = {0:F5}", sum);
    }
}

