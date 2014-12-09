using System;

class Lines
{
    static void Main()
    {
        //byte[] nums = { 3, 0, 0, 0, 0, 0, 0, 0 };
        byte[] nums = new byte[8];
        for (int i = 0; i < 8; i++)
        {
            nums[i] = byte.Parse(Console.ReadLine());
        }
        bool found = false;
        byte left = 0, right = 0, pillar = 0;
        for (sbyte k = 7; k >= 0; k--)
        {
            pillar = (byte)k;
            left = 0;
            right = 0;
            for (sbyte i = 0; i < 8; i++)
            {
                for (sbyte j = 0; j < 8; j++)
                {
                    byte mask = (byte)(1 << j);
                    if ((nums[i] & mask) != 0)
                    {
                        if (j > pillar)
                        {
                            left++;
                        }
                        else if (j < pillar)
                        {
                            right++;
                        }
                    }
                }
            }
            if (left == right)
            {
                found = true;
                break;
            }
        }
        if (!found)
        {
            Console.WriteLine("No");
        }
        else
        {
            Console.WriteLine(pillar);
            Console.WriteLine(left);
        }
    }
}

