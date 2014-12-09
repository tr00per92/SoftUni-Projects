using System;

namespace GeometryClass
{
    class GeometryTest
    {
        static void Main()
        {
            Console.WriteLine(Geometry.Area(65));
            Console.WriteLine(Geometry.Perimeter(13, 12.5));
            Console.WriteLine(Geometry.Volume(24, 30, 18, 67.8));
            Console.WriteLine(Geometry.Volume(50));
            Console.WriteLine(Geometry.Perimeter(18, 12.5, 14));
            Console.WriteLine(Geometry.Perimeter(55));
            Console.WriteLine(Geometry.Area(17, 14.5, 8));
            Console.WriteLine(Geometry.Area(20, 30));
            Console.WriteLine(Geometry.Volume(40, 30, 18));
        }
    }
}
