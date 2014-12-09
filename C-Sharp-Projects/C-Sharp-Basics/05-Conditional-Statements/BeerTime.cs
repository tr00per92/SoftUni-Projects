using System;
class BeerTime
{
    static void Main()
    {
        Console.Write("Enter a time in format \"hh:mm tt\": ");
        DateTime time = new DateTime();
        bool valid = DateTime.TryParse(Console.ReadLine(), out time);
        if (valid)
        {
            if (time.Hour < 13 && time.Hour >= 3)
            {
                Console.WriteLine("non-beer time");
            }
            else
            {
                Console.WriteLine("beer time");
            }
        }
        else
        {
            Console.WriteLine("invalid time");
        }
    }
}

