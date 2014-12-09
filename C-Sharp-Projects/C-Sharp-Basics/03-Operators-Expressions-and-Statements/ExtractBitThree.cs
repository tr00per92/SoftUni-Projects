using System;

class ExtractBitThree
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int n = int.Parse(Console.ReadLine());
        int bitThree = (n >> 3) & 1;
        Console.WriteLine("Bit #3: " + bitThree);
    }
}

