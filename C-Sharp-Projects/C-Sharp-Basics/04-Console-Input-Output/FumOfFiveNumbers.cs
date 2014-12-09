using System;

class FumOfFiveNumbers
{
    static void Main()
    {
        Console.WriteLine("Enter a sequence of numbers, separated by whitespaces: ");
        string[] numbers = Console.ReadLine().Split();
        double sum = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            sum += double.Parse(numbers[i]);
        }
        Console.WriteLine("Sum: {0}", sum);
    }
}

