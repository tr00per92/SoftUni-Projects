using System;

class RandomNumbersInGivenRange
{
    static void Main()
    {
        Console.Write("Enter n: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter min value: ");
        int min = int.Parse(Console.ReadLine());
        Console.Write("Enter max value: ");
        int max = int.Parse(Console.ReadLine());
        Random rnd = new Random();
        for (int i = 0; i < n; i++)
        {
            Console.Write(rnd.Next(min, max+1) + " ");
        }
        Console.WriteLine();
    }
}

