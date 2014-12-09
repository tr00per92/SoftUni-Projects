using System;

class BinaryToDecimal
{
    static void Main()
    {
        Console.WriteLine("Enter a number in binary form:");
        string input = Console.ReadLine();
        long result = 0, pow = 1;
        for (int i = input.Length - 1; i >= 0; i--)
        {
            result += int.Parse(input[i].ToString()) * pow;
            pow *= 2;
        }
        Console.WriteLine("Number in decimal: {0}", result);
    }
}
