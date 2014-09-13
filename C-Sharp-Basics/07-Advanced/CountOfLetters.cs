using System;
using System.Collections.Generic;

class CountOfLetters
{
    static void Main()
    {
        Console.WriteLine("Enter the letters:");
        List<string> letters = new List<string>(Console.ReadLine().Split());
        List<string> uniqueLetters = new List<string>();
        for (int i = 0; i < letters.Count; i++)
        {
            if (!uniqueLetters.Contains(letters[i]))
            {
                uniqueLetters.Add(letters[i]);
            }
        }
        uniqueLetters.Sort();
        foreach (string uniqueLetter in uniqueLetters)
        {
            int count = 0;
            foreach (string letter in letters)
            {
                if (letter == uniqueLetter)
                {
                    count++;
                }
            }
            Console.WriteLine("{0} -> {1}", uniqueLetter, count);
        }
    }
}

