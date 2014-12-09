using System;

class BitsExchange
{
    static void Main()
    {
        Console.Write("Enter n: ");
        uint n = uint.Parse(Console.ReadLine());
        uint mask1 = 7, mask2 = 7;       //we need mask = 111, so we can change 3 bits
        mask1 = mask1 << 3;     //mask for bits 3,4,5
        mask2 = mask2 << 24;    //mask for bits 24,25,26

        uint bits1 = n & mask1;
        bits1 = bits1 >> 3;         //saves the bits in positions 3,4,5

        uint bits2 = n & mask2;
        bits2 = bits2 >> 24;        //saves the bits in positions 24,25,26

        n = n & ~mask1;
        n = n & ~mask2;         //sets the bits in positions 3,4,5 and 24,25,26 to 0

        bits1 = bits1 << 24;
        n = n | bits1;

        bits2 = bits2 << 3;
        n = n | bits2;

        Console.WriteLine("Result: " + n);

        //num = (num & (~(7u << 3 | 7u << 24))) | (((num & (7u << 3)) << 21) | ((num & (7u << 24)) >> 21));
    }
}

