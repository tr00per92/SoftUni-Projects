using System;

class DivideBySevenAndFive
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int n = int.Parse(Console.ReadLine());
        bool divided = n % 35 == 0 && n != 0;
        Console.WriteLine("Divided by seven and five?: " + divided);
    }
}

