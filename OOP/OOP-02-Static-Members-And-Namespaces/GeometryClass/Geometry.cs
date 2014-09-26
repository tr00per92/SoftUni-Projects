using System;

namespace GeometryClass
{
    class Geometry
    {
        const double PI = Math.PI;

        public static double Perimeter(double sideA, double sideB, double sideC)
        {
            if (sideA + sideB <= sideC || sideB + sideC <= sideA || sideA + sideC <= sideB)
            {
                throw new ArgumentException("These 3 points don't form a valid triangle");
            }
            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
            {
                throw new ArgumentException("The lenght must be a positive number");
            }
            return sideA + sideB + sideC;
        }
        public static double Perimeter(double sideA, double sideB)
        {
            if (sideA <= 0 || sideB <= 0)
            {
                throw new ArgumentException("The lenght must be a positive number");
            }
            return 2 * sideA + 2 * sideB;            
        }
        public static double Perimeter(double radius)
        {
            if (radius <= 0)
            {
                throw new ArgumentException("The radius must be a positive number");
            }
            return 2 * PI * radius;
        }

        public static double Area(double sideA, double sideB, double sideC)
        {
            double p = Perimeter(sideA, sideB, sideC) / 2.0;
            return Math.Sqrt(p * (p - sideA) * (p - sideB) * (p - sideC));
        }
        public static double Area(double sideA, double sideB)
        {
            if (sideA <= 0 || sideB <= 0)
            {
                throw new ArgumentException("The lenght must be a positive number");
            }
            return sideA * sideB;
        }
        public static double Area(double radius)
        {
            if (radius <= 0)
            {
                throw new ArgumentException("The radius must be a positive number");
            }
            return PI * radius * radius;
        }

        public static double Volume(double sideA, double sideB, double sideC, double height)
        {
            return (1.0 / 3.0) * height * Area(sideA, sideB, sideC);
        }
        public static double Volume(double sideA, double sideB, double height)
        {
            return Area(sideA, sideB) * height;
        }
        public static double Volume(double radius)
        {
            return (4.0 / 3.0) * radius * Area(radius);
        }
    }
}
