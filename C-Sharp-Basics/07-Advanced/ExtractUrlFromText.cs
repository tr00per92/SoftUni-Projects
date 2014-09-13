using System;
using System.Collections.Generic;

class ExtractUrlFromText
{
    static void Main()
    {
        Console.WriteLine("Enter the text:");
        string[] text = Console.ReadLine().Trim('.', '!', '?').Split();
        List<string> urls = new List<string>();
        for (int i = 0; i < text.Length; i++)
        {
            if(text[i].Length >= 7 && text[i].Substring(0,7) == "http://")
            {
                urls.Add(text[i]);
            }
            else if(text[i].Length >= 4 && text[i].Substring(0,4) == "www.")
            {
                urls.Add(text[i]);
            }
        }
        foreach (string url in urls)
        {
            Console.WriteLine(url);
        }
    }
}

