using System;

class CheckForAPlayCard
{
    static void Main()
    {
        Console.Write("Enter the string: ");
        string str = Console.ReadLine();
        if (str == "2" || str == "3" || str == "4" || str == "5" || str == "6" || str == "7" ||
            str == "8" || str == "9" || str == "10" || str == "J" || str == "Q" || str == "K" || str == "A")
        {
            Console.WriteLine("yes");
        }
        else
        {
            Console.WriteLine("no");
        }
    }
}

