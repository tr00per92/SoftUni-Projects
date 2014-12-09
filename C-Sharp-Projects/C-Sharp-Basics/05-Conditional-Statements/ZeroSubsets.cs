using System;

class ZeroSubsets
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        bool flag = false;
        int[] num = new int[5];        
        for (int i = 0; i < 5; i++)
        {
            num[i] = int.Parse(input[i]);
        }
        for (int i = 1; i < 32; i++)
        {
            int sum = 0;
            string output = "";
            for (int j = 0; j < 5; j++)
            {
                int bit = (i & (1 << j)) >> j;
                if (bit == 1)
                {
                    sum += num[j];
                    output += num[j] + " + ";
                }
            }            
            if (sum == 0)
            {
                flag = true;
                output = output.Trim(' ', '+') + " = " + sum;
                Console.WriteLine(output);
            }
        }
        if (!flag)
        {
            Console.WriteLine("no zero subset");
        }
    }
}

