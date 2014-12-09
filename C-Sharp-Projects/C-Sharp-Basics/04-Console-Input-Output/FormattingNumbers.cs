using System;

class FormattingNumbers
{
    static void Main()
    {
        Console.Write("Enter integer a: ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Enter floating-point number b: ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("Enter floating-point number c: ");
        double c = double.Parse(Console.ReadLine());
        string binaryA = Convert.ToString(a, 2);
        Console.Write("|{0,-10:X}|" , a);
        Console.Write(binaryA.PadLeft(10, '0'));
        Console.WriteLine("|{0,10:0.##}|{1,-10:0.###}|", b, c);
    }
}

