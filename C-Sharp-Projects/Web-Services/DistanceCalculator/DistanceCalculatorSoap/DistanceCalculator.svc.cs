namespace DistanceCalculator
{
    using System;

    public class DistanceCalculator : IDistanceCalculator
    {
        public decimal CalcDistance(Point startPoint, Point endPoint)
        {
            var dx = startPoint.X - endPoint.X;
            var dy = startPoint.Y - endPoint.Y;

            return (decimal)Math.Sqrt((double)(dx * dx + dy * dy));
        }
    }
}
