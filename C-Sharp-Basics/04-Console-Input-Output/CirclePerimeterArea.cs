using System;

class CirclePerimeterArea
{
    static void Main()
    {
        Console.Write("Enter r: ");
        double r = double.Parse(Console.ReadLine());
        double perimeter = 2 * r * Math.PI;
        double area = r * r * Math.PI;
        Console.WriteLine("The perimeter of the cirle is: {0:F2}", perimeter);
        Console.WriteLine("The area of the cirle is: {0:F2}", area);
    }
}

