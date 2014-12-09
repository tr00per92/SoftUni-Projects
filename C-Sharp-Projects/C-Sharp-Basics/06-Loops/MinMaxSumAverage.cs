using System;

class MinMaxSumAverage
{
    static void Main()
    {
        Console.Write("Enter the number of lines: ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Now enter the numbers, each followed by [enter]:");
        int min = int.MaxValue, max = int.MinValue, sum = 0;
        for (int i = 0; i < n; i++)
        {
            int num = int.Parse(Console.ReadLine());
            sum += num;
            min = Math.Min(min, num);
            max = Math.Max(max, num);
        }
        double average = (double)sum / n;
        Console.WriteLine("min = {0}", min);
        Console.WriteLine("max = {0}", max);
        Console.WriteLine("sum = {0}", sum);
        Console.WriteLine("avg = {0:F2}", average);
    }
}

