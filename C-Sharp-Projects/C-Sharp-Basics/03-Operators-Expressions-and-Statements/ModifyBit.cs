using System;

class ModifyBit
{
    static void Main()
    {
        Console.Write("Enter n: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter v (0 or 1): ");
        int v = int.Parse(Console.ReadLine());
        Console.Write("Enter p: ");
        int p = int.Parse(Console.ReadLine());
        if (v == 0)
        {
            int mask = ~(1 << p);
            n = n & mask;
        }
        else if (v == 1) 
        {
            int mask = 1 << p;
            n = n | mask;
        }
        Console.WriteLine("Result: " + n);
    }
}

