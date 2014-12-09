using System;

class ExtractBit
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter the index p: ");
        int p = int.Parse(Console.ReadLine());
        int bitP = (n >> p) & 1;
        Console.WriteLine("Bit @P = " + bitP);
    }
}

