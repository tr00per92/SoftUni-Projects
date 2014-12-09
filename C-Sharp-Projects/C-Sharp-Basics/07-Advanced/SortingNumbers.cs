using System;

class SortingNumbers
{
    static void Main()
    {
        Console.Write("Enter the number of the elements: ");
        int n = int.Parse(Console.ReadLine());
        int[] nums = new int[n];
        Console.WriteLine("Now enter the elements, each followed by [enter]:");
        for (int i = 0; i < nums.Length; i++)
        {
            nums[i] = int.Parse(Console.ReadLine());
        }
        Array.Sort(nums);
        foreach (int num in nums)
        {
            Console.WriteLine(num);
        }
    }
}

