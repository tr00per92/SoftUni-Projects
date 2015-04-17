namespace DistanceCalculatorSoapClient
{
    using System;
    using System.Net;
    using DistanceCalculatorService;

    public class DistanceCalculator
    {
        public static void Main()
        {
            var calc = new DistanceCalculatorClient();
            var result = calc.CalcDistance(new Point { X = 1, Y = 1 }, new Point { X = 3, Y = 3 });
            Console.WriteLine(result);

            using (var webClient = new WebClient())
            {
                var res = webClient.DownloadString("http://localhost:32705/api/Calculator?ax=1&ay=1&bx=3&by=3");
                Console.WriteLine(res);
            }
        }
    }
}
