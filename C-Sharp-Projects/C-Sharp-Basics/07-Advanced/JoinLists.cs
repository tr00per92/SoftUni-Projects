using System;
using System.Collections.Generic;

class JoinLists
{
    static void Main()
    {
        Console.WriteLine("Enter the first list of integers:");
        string[] firstLine = Console.ReadLine().Split();
        Console.WriteLine("Now enter the first list of integers:");
        string[] secondLine = Console.ReadLine().Split();
        List<int> numbers = new List<int>();
        for (int i = 0; i < firstLine.Length; i++)
        {
            int currentNum = int.Parse(firstLine[i]);
            if (!numbers.Contains(currentNum))
            {
                numbers.Add(currentNum);
            }
        }
        for (int i = 0; i < secondLine.Length; i++)
        {
            int currentNum = int.Parse(secondLine[i]);
            if (!numbers.Contains(currentNum))
            {
                numbers.Add(currentNum);
            }
        }
        numbers.Sort();
        foreach (int num in numbers)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }
}

