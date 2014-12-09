using System;
using System.Collections.Generic;
using System.Text;

namespace _01_Point3D
{
    class Path3D
    {
        // constructor that accepts any number of points
        public Path3D(params Point3D[] points)
        {
            this.Points = new List<Point3D>(points);
        }

        public IList<Point3D> Points { get; set; }
        public double TotalDistance
        { 
            get 
            {
                double result = 0;
                for (int i = 0; i < this.Points.Count - 1; i++)
                {
                    result += DistanceCalculator.CalcDistance(this.Points[i], this.Points[i + 1]);
                }
                return result;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            foreach (var point in this.Points)
            {
                result.Append(point + "\n");
            }
            return result.ToString().Trim();
        }
    }
}
