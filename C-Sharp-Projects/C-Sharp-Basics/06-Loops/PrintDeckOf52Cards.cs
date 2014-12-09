using System;

class PrintDeckOf52Cards
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        for (int i = 2; i <= 14; i++)
        {
            for (int j = 1; j <= 4; j++)
            {
                switch (i)
                {
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                    case 10: Console.Write(i); break;
                    case 11: Console.Write("J"); break;
                    case 12: Console.Write("Q"); break;
                    case 13: Console.Write("K"); break;
                    case 14: Console.Write("A"); break;
                }
                switch (j)
                {
                    case 1: Console.Write("♣ "); break;
                    case 2: Console.Write("♦ "); break;
                    case 3: Console.Write("♥ "); break;
                    case 4: Console.Write("♠ "); break;
                }
            }
            Console.WriteLine();
        }
    }
}

