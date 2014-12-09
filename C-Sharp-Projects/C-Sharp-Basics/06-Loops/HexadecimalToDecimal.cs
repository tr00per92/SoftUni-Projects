using System;

class HexadecimalToDecimal
{
    static void Main()
    {
        Console.WriteLine("Enter a number in hexadecimal form:");
        string input = Console.ReadLine();
        long result = 0, pow = 1, tempNum = 0;
        for (int i = input.Length - 1; i >= 0; i--)
        {            
            switch (input[i])
            {   case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                case '0': tempNum = int.Parse(input[i].ToString()); break;
                case 'A': tempNum = 10; break;
                case 'B': tempNum = 11; break;
                case 'C': tempNum = 12; break;
                case 'D': tempNum = 13; break;
                case 'E': tempNum = 14; break;
                case 'F': tempNum = 15; break;
                default: Console.WriteLine("Wrong input!"); return;
	        }
            result += tempNum * pow;
            pow *= 16;
        }
        Console.WriteLine("Number in decimal: {0}", result);
    }
}

