using System;

namespace _05_BitArray
{
    class BitArrayTest
    {
        static void Main()
        {
            BitArray number = new BitArray(100000);
            Console.WriteLine(number);
            number[7] = 1;
            Console.WriteLine(number);
            //number[9999] = 1;
            //Console.WriteLine(number);
        }
    }
}
