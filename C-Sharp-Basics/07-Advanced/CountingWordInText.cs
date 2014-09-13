using System;

class CountingWordInText
{
    static void Main()
    {
        Console.Write("Enter the word to count: ");
        string target = Console.ReadLine().ToLower();
        Console.WriteLine("Now enter the text:");
        string[] text = Console.ReadLine().ToLower().Split(new char[] { ' ', '.', ',', '"', '@', '!', '?', '/', '\\', ':', ';', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
        int count = 0;
        foreach (string word in text)
        {
            if(word == target)
            {
                count++;
            }
        }
        Console.WriteLine(count);
    }
}

