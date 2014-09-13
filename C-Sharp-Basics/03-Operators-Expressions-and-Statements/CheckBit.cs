using System;

class CheckBit
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter the index p: ");
        int p = int.Parse(Console.ReadLine());
        bool bitP = ((n >> p) & 1) == 1;
        Console.WriteLine("Bit @p == 1: " + bitP);
    }
}

