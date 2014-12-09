using System;

class ASCIITable
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        for (int i = 0; i <= 255; i++)
        {
            Console.WriteLine((char)i);
        }
    }
}