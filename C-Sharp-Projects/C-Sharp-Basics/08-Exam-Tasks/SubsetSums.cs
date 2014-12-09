using System;

class SubsetSums
{
    static void Main()
    {
        long target = long.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());
        long[] nums = new long[n];
        for (int i = 0; i < nums.Length; i++)
        {
            nums[i] = long.Parse(Console.ReadLine());
        }
        int result = 0;
        for (int i = 1; i <= Math.Pow(2, (double)(nums.Length)) - 1; i++)
        {
            long sum = 0;
            for (int j = 0; j < nums.Length; j++)
            {
                int mask = 1 << j;
                if ((i & mask) != 0)
                {
                    sum += nums[j];
                }
            }
            if(sum == target)
            {
                result++;
            }
        }
        Console.WriteLine(result);
    }
}

