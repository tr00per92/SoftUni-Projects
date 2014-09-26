using System;

namespace _01_Point3D
{
    static class DistanceCalculator
    {
        public static double CalcDistance(Point3D firstPoint, Point3D secondPoint)
        {
            return Math.Sqrt ( (secondPoint.X - firstPoint.X) * (secondPoint.X - firstPoint.X)
                + (secondPoint.Y - firstPoint.Y) * (secondPoint.Y - firstPoint.Y)
                + (secondPoint.Z - firstPoint.Z) * (secondPoint.Z - firstPoint.Z) );
        }
    }
}
