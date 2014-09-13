using System;

class DecimalToBinary
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        long num = long.Parse(Console.ReadLine());
        if (num == 0)
        {
            Console.WriteLine(0); return;
        }
        string binary = "";
        while (num > 0)
        {
            binary += num % 2;
            num /= 2;
        }
        char[] temp = binary.ToCharArray();   //reversing the string
        Array.Reverse(temp);
        binary = new string(temp);
        Console.WriteLine(binary);
    }
}
