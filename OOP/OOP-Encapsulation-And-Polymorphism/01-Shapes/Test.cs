using System;

namespace _01_Shapes
{
    public class Test
    {
        public static void Main()
        {
            IShape[] shapes =
            {
                new Circle(10),
                new Triangle(3, 8),
                new Rectangle(4.5, 3.6),
                new Circle(7.5),
                new Triangle(7.6, 11),
                new Rectangle(5, 5.5), 
            };

            foreach (var shape in shapes)
            {
                Console.WriteLine("Figure: " + shape.GetType().Name);
                Console.WriteLine("Area: " + shape.CalculateArea());

                // cannot calculate the perimeter of a triangle with the given data
                if (!(shape is Triangle))
                {
                    Console.WriteLine("Perimeter: " + shape.CalculatePerimeter());
                }
            }
        }
    }
}
