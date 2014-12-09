using System;

class SumOfNNumbers
{
    static void Main()
    {
        Console.Write("Enter n: ");
        int n = int.Parse(Console.ReadLine());
        double sum = 0;
        Console.WriteLine("Now enter N numbers, each followed by enter key:");
        for (int i = 0; i < n; i++)
        {
            sum += double.Parse(Console.ReadLine());
        }
        Console.WriteLine("Sum: {0}", sum);
    }
}