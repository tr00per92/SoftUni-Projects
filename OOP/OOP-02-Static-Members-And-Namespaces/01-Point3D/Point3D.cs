using System;

namespace _01_Point3D
{
    class Point3D
    {
        private static readonly Point3D startingPoint = new Point3D(0, 0, 0);

        public Point3D(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public static Point3D StartingPoint
        {
            get { return Point3D.startingPoint; }
        }

        public override string ToString()
        {
            return String.Format("X: {0} Y: {1} Z: {2}", this.X, this.Y, this.Z);
        }
    }
}
