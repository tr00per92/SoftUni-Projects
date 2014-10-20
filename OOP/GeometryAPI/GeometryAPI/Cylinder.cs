using System;

namespace GeometryAPI
{
    public class Cylinder : Figure, IAreaMeasurable, IVolumeMeasurable
    {
        public Cylinder(Vector3D top, Vector3D bottom, double radius)
            : base(top, bottom)
        {
            this.Radius = radius;
        }

        public double Radius { get; private set; }

        public Vector3D Top
        {
            get
            {
                return new Vector3D(this.vertices[0].X, this.vertices[0].Y, this.vertices[0].Z);
            }
        }

        public Vector3D Bottom
        {
            get
            {
                return new Vector3D(this.vertices[1].X, this.vertices[1].Y, this.vertices[1].Z);
            }
        }

        public override double GetPrimaryMeasure()
        {
            return this.GetVolume();
        }

        public double GetArea()
        {
            double baseArea = this.Radius * this.Radius * Math.PI;
            double topAndBottomArea = baseArea * 2;
            double basePerimeter = 2 * Math.PI * this.Radius;
            double sideArea = basePerimeter * (this.Top - this.Bottom).Magnitude;
            double area = sideArea + topAndBottomArea;
            return area;
        }

        public double GetVolume()
        {
            return this.Radius * this.Radius * Math.PI * (this.Top - this.Bottom).Magnitude;
        }
    }
}
