using System;

class DecimalToHexadecimal
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        long num = long.Parse(Console.ReadLine());
        if (num == 0)
        {
            Console.WriteLine(0); return;
        }
        string hex = "", tempChar = "";
        while (num > 0)
        {
            switch (num % 16)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                case 0: tempChar = (num % 16).ToString(); break;
                case 10: tempChar = "A"; break;
                case 11: tempChar = "B"; break;
                case 12: tempChar = "C"; break;
                case 13: tempChar = "D"; break;
                case 14: tempChar = "E"; break;
                case 15: tempChar = "F"; break;
                default: Console.WriteLine("Wrong input!"); return;
            }
            hex += tempChar;
            num /= 16;
        }
        char[] temp = hex.ToCharArray();   //reversing the string
        Array.Reverse(temp);
        hex = new string(temp);
        Console.WriteLine(hex);
    }
}

