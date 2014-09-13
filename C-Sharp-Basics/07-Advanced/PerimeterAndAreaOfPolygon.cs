using System;

class Point
{
    public double X { get; set; }
    public double Y { get; set; }
}

class PerimeterAndAreaOfPolygon
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Point[] polygon = new Point[n + 1];         //Creating polygon of points

        for (int i = 0; i < polygon.Length - 1; i++)        //Filling the point values
        {
            string[] input = Console.ReadLine().Split();
            Point currentPoint = new Point() { X = double.Parse(input[0]), Y = double.Parse(input[1])};
            polygon[i] = currentPoint;
        }
        polygon[polygon.Length - 1] = polygon[0];       //"Closing" the polygon

        double perimeter = CalcPerimeter(polygon);
        Console.WriteLine("Perimeter: {0:F2}", perimeter);
        double area = CalcArea(polygon);
        Console.WriteLine("Area: {0:F2}", area);
    }

    static double CalcArea(Point[] polygon)
    {
        double area = 0;
        for (int i = 0; i < polygon.Length - 1; i++)
        {
            double currentScore = polygon[i].X * polygon[i + 1].Y - polygon[i].Y * polygon[i + 1].X;
            area += currentScore;
        }
        area /= 2;
        return Math.Abs(area);
    }

    static double CalcPerimeter(Point[] polygon)
    {
        double perimeter = 0;
        for (int i = 0; i < polygon.Length - 1; i++)
        {
            double dx = polygon[i + 1].X - polygon[i].X;
            double dy = polygon[i + 1].Y - polygon[i].Y;
            double currentDistance = Math.Sqrt(dx * dx + dy * dy);
            perimeter += currentDistance;
        }
        return Math.Abs(perimeter);
    }
}

