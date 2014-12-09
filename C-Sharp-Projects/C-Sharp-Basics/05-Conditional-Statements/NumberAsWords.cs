using System;

class NumberAsWords
{
    static void Main()
    {
        Console.Write("Enter a number from 0 to 999: ");
        int numb = int.Parse(Console.ReadLine());

        if (numb == 0)
        {
            Console.WriteLine("zero"); return;
        }

        int ones = numb % 10;
        int tens = (numb / 10) % 10;
        int hundreds = (numb / 100) % 10;        

        switch (hundreds)
        {
            case 1:
                Console.Write("one hundred "); break;
            case 2:
                Console.Write("two hundred "); break;
            case 3:
                Console.Write("three hundred "); break;
            case 4:
                Console.Write("four hundred "); break;
            case 5:
                Console.Write("five hundred "); break;
            case 6:
                Console.Write("six hundred "); break;
            case 7:
                Console.Write("seven hundred "); break;
            case 8:
                Console.Write("eight hundred "); break;
            case 9:
                Console.Write("nine hundred "); break;
        }

        if ((tens != 0 || ones != 0) && hundreds != 0)
        {
            Console.Write("and ");
        }

        switch (tens)
        {
            case 1:
                switch (ones)
                {
                    case 0:
                        Console.WriteLine("ten"); return;
                    case 1:
                        Console.WriteLine("eleven"); return;
                    case 2:
                        Console.WriteLine("twelve"); return;
                    case 3:
                        Console.WriteLine("thirteen"); return;
                    case 4:
                        Console.WriteLine("fourteen"); return;
                    case 5:
                        Console.WriteLine("fifteen"); return;
                    case 6:
                        Console.WriteLine("sixteen"); return;
                    case 7:
                        Console.WriteLine("seventeen"); return;
                    case 8:
                        Console.WriteLine("eighteen"); return;
                    case 9:
                        Console.WriteLine("nineteen"); return;
                }
                break;
            case 2:
                Console.Write("twenty "); break;
            case 3:
                Console.Write("thirty "); break;
            case 4:
                Console.Write("fourty "); break;
            case 5:
                Console.Write("fifty "); break;
            case 6:
                Console.Write("sixty "); break;
            case 7:
                Console.Write("seventy "); break;
            case 8:
                Console.Write("eighty "); break;
            case 9:
                Console.Write("ninety "); break;
        }
        switch (ones)
        {
            case 1:
                Console.Write("one"); break;
            case 2:
                Console.Write("two"); break;
            case 3:
                Console.Write("three"); break;
            case 4:
                Console.Write("four"); break;
            case 5:
                Console.Write("five"); break;
            case 6:
                Console.Write("six"); break;
            case 7:
                Console.Write("seven"); break;
            case 8:
                Console.Write("eight"); break;
            case 9:
                Console.Write("nine"); break;
        }
        Console.WriteLine();
    }
}

