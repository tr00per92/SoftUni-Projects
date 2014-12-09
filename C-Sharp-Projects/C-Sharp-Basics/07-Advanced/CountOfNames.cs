using System;
using System.Collections.Generic;

class CountOfNames
{
    static void Main()
    {
        Console.WriteLine("Enter the letters:");
        List<string> names = new List<string>(Console.ReadLine().Split());
        List<string> uniqueNames = new List<string>();
        for (int i = 0; i < names.Count; i++)
        {
            if (!uniqueNames.Contains(names[i]))
            {
                uniqueNames.Add(names[i]);
            }
        }
        uniqueNames.Sort();
        foreach (string uniqueName in uniqueNames)
        {
            int count = 0;
            foreach (string name in names)
            {
                if (name == uniqueName)
                {
                    count++;
                }
            }
            Console.WriteLine("{0} -> {1}", uniqueName, count);
        }
    }
}

