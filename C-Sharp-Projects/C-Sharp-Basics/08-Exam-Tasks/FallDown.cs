using System;

class FallDown
{
    static void Main()
    {
        byte[] nums = new byte[8];
        for (int i = 0; i < 8; i++)
        {
            nums[i] = byte.Parse(Console.ReadLine());
        }
        for (sbyte i = 0; i < 8; i++)
        {
            byte mask = (byte)(1 << i);
            byte ones = 0;
            for (sbyte j = 0; j < 8; j++)
            {
                if ((nums[j] & mask) != 0)
                {
                    ones++;
                }
            }
            if (ones > 0)
            {
                for (sbyte j = 0; j < 8; j++)
                {
                    if (j > 7 - ones)
                    {
                        nums[j] |= mask;
                    }
                    else
                    {
                        nums[j] &= (byte)(~mask);
                    }
                }
            }
        }
        foreach (int num in nums)
        {
            Console.WriteLine(num);
        }
    }
}