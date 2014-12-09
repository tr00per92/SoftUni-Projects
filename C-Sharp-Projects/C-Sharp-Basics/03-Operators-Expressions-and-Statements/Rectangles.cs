using System;

class Rectangles
{
    static void Main()
    {
        Console.Write("Enter the width of the rectangle: ");
        double width = double.Parse(Console.ReadLine());
        Console.Write("Enter the heigth of the rectangle: ");
        double heigth = double.Parse(Console.ReadLine());
        double perimeter = 2 * width + 2 * heigth;
        double area = width * heigth;
        Console.WriteLine("The perimeter is: " + perimeter);
        Console.WriteLine("The area is: " + area);
    }
}

