using System;

class ThirdDigitIsSeven
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int n = int.Parse(Console.ReadLine());
        bool isSeven = (n / 100) % 10 == 7;
        Console.WriteLine("Third digit 7?: " + isSeven);
    }
}

