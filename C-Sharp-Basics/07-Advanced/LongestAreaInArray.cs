using System;
using System.Collections.Generic;

class LongestAreaInArray
{
    static void Main()
    {
        Console.Write("Enter the number of the elements: ");
        int n = int.Parse(Console.ReadLine());
        string[] input = new string[n];
        Console.WriteLine("Now enter the elements, each followed by [enter]:");
        for (int i = 0; i < input.Length; i++)
        {
            input[i] = Console.ReadLine();
        }
        List<string> LongestSequence = new List<string>();
        LongestSequence.Add(input[0]);
        int length = 1, maxLength = 1;
        for (int i = 0; i < input.Length - 1; i++)
        {
            if (input[i] != input[i + 1])
            {
                length = 1;
            }
            else if (input[i] == input[i+1])
            {
                length++;
            }
            if (length > maxLength)
            {
                LongestSequence.Clear();
                for (int j = 0; j < length; j++)
                {
                    LongestSequence.Add(input[i]);
                }
                maxLength = length;
            }
        }
        Console.WriteLine(maxLength);
        foreach (string item in LongestSequence)
        {
            Console.WriteLine(item);
        }
    }
}

