using System;

class BitsExchangeAdv
{
    static void Main()
    {
        uint n;
        Console.Write("Enter n: ");
        bool parseSuccess = uint.TryParse(Console.ReadLine(), out n);
        Console.Write("Enter p: ");
        sbyte p = sbyte.Parse(Console.ReadLine());
        Console.Write("Enter q: ");
        sbyte q = sbyte.Parse(Console.ReadLine());
        Console.Write("Enter k: ");
        sbyte k = sbyte.Parse(Console.ReadLine());

        if (!parseSuccess || k + Math.Max(p, q) > 32 || q < 0 || p < 0)     //check for out of range and wrong input
        {
            Console.WriteLine("out of range");
            return;
        }
        if (k > Math.Abs(p-q))      //check for overlap
        {
            Console.WriteLine("overlapping");
            return;
        }

        uint mask1 = (uint)(1 << k) - 1;
        uint mask2 = (uint)(1 << k) - 1;      //creating masks with "K" ones at the end
        mask1 = mask1 << p;     //mask for the first k bits (starting from p)
        mask2 = mask2 << q;    //mask for the second k bits (starting from q)

        uint bits1 = n & mask1;
        bits1 = bits1 >> p;

        uint bits2 = n & mask2;
        bits2 = bits2 >> q;

        n = n & ~mask1;
        n = n & ~mask2;

        bits1 = bits1 << q;
        n = n | bits1;

        bits2 = bits2 << p;
        n = n | bits2;

        Console.WriteLine("Result: " + n);        
    }
}

