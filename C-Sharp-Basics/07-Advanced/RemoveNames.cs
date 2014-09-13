using System;
using System.Collections.Generic;

class RemoveNames
{
    static void Main()
    {
        Console.WriteLine("Enter the first list of names:");
        List<string> first = new List<string>(Console.ReadLine().Split());
        Console.WriteLine("Now enter the first list of names:");
        List<string> second = new List<string>(Console.ReadLine().Split());
        foreach (string name in second)
        {
            while (first.Contains(name))
            {
                first.Remove(name);
            }
        }
        foreach (string name in first)
        {
            Console.Write(name + " ");
        }
        Console.WriteLine();
    }
}

