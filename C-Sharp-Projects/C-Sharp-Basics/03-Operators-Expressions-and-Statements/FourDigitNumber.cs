using System;

class FourDigitNumber
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int n = int.Parse(Console.ReadLine());
        int d = n % 10;
        int c = (n / 10) % 10;
        int b = (n / 100) % 10;
        int a = (n / 1000) % 10;
        Console.WriteLine("The sum of the digits is: {0}", a+b+c+d);
        Console.WriteLine("Reversed: {0}{1}{2}{3}", d, c, b, a);
        Console.WriteLine("Last digit first: {0}{1}{2}{3}", d, a, b, c);
        Console.WriteLine("Exchange second and third digit: {0}{1}{2}{3}", a, c, b, d);
    }
}

