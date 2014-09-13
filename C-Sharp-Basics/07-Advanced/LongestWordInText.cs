using System;

class LongestWordInText
{
    static void Main()
    {
        Console.WriteLine("Enter the text:");
        string[] words = Console.ReadLine().Trim('.','!','?').Split();
        string longest = words[0];
        for (int i = 1; i < words.Length; i++)
        {
            if(words[i].Length > longest.Length)
            {
                longest = words[i];
            }
        }
        Console.WriteLine("The longest word is: {0}", longest);
    }
}

