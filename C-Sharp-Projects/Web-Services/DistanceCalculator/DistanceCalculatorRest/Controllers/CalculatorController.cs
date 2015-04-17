namespace DistanceCalculatorRest.Controllers
{
    using System;
    using System.Web.Http;

    public class CalculatorController : ApiController
    {
        public decimal GetDistance(decimal ax, decimal ay, decimal bx, decimal by)
        {
            var dx = ax - bx;
            var dy = ay - by;

            return (decimal)Math.Sqrt((double)(dx * dx + dy * dy));
        }
    }
}
