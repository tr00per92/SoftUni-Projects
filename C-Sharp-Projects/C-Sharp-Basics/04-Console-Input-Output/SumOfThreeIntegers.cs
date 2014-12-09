using System;

class SumOfThreeIntegers
{
    static void Main()
    {
        Console.WriteLine("Enter 3 number, each folloued by Enter: ");
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());
        double sum = a + b + c;
        Console.WriteLine("The sum is: " + sum);
    }
}

