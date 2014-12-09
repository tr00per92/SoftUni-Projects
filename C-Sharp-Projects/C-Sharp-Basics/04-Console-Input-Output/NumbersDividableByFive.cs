using System;

class NumbersDividableByFive
{
    static void Main()
    {
        Console.Write("Enter the start of the interval: ");
        int start = int.Parse(Console.ReadLine());
        Console.Write("Enter the end of the interval: ");
        int end = int.Parse(Console.ReadLine());
        int counter = 0;
        for (int i = start; i <= end; i++)
        {
            if (i % 5 == 0)
            {
                counter++;
                Console.Write(i + " ");
            }
        }
        Console.WriteLine();
        Console.WriteLine("There are {0} numbers dividable by 5 in the interval.", counter);
    }
}

