using System;

class OddOrEven
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int n = int.Parse(Console.ReadLine());
        bool odd = n % 2 != 0;
        Console.WriteLine("Odd?: " + odd);
    }
}

