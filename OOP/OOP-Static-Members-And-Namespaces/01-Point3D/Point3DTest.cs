using System;
using System.Globalization;
using System.Threading;

namespace _01_Point3D
{
    class Point3DTest
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            Point3D start = Point3D.StartingPoint;
            Console.WriteLine(start);
            Point3D p = new Point3D(2.3, 4.8, 16.9);
            Console.WriteLine(p);
            Point3D q = new Point3D(2.8, 16, -5);
            Console.WriteLine(p);

            double distance = DistanceCalculator.CalcDistance(q, p);
            Console.WriteLine("The distance between the points is: " + distance);

            Path3D myPath = new Path3D(p, q, start);
            Console.WriteLine("My path is: ");
            Console.WriteLine(myPath);
            Console.WriteLine("My path's total lenght is: " + myPath.TotalDistance);

            Storage.WritePathToTxt(myPath);

            Path3D readedPath = Storage.ReadPathFromTxt("../../txtFiles/input.txt");
            Console.WriteLine("This path war read from the text file: ");
            Console.WriteLine(readedPath);
            Console.WriteLine("Readed path's total lenght is: " + readedPath.TotalDistance);
        }
    }
}
