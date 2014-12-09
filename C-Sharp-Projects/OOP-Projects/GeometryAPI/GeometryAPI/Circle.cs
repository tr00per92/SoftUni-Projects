using System;

namespace GeometryAPI
{
    public class Circle : Figure, IAreaMeasurable, IFlat
    {
        public Circle(Vector3D center, double radius)
            : base(center)
        {
            this.Radius = radius;
        }

        public double Radius { get; private set; }

        public override double GetPrimaryMeasure()
        {
            return this.GetArea();
        }

        public double GetArea()
        {
            return this.Radius * this.Radius * Math.PI;
        }

        public Vector3D GetNormal()
        {
            Vector3D center = this.GetCenter();
            Vector3D A = new Vector3D(center.X + this.Radius, center.Y, center.Z);
            Vector3D B = new Vector3D(center.X, center.Y + this.Radius, center.Z);
            Vector3D normal = Vector3D.CrossProduct(center - A, center - B);
            normal.Normalize();
            return normal;
        }
    }
}
