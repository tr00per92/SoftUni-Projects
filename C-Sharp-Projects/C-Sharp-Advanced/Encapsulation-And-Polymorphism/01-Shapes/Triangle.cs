using System;

namespace _01_Shapes
{
    public class Triangle : BasicShape
    {
        public Triangle(double width, double height)
            : base(width, height)
        {
        }

        public override double CalculateArea()
        {
            return (this.Width * this.Height) / 2;
        }

        public override double CalculatePerimeter()
        {
            throw new NotImplementedException();
        }
    }
}
