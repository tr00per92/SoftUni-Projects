namespace EgyptianFractions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var inputTokens = input.Split('/');
            var fraction = decimal.Parse(inputTokens[0]) / decimal.Parse(inputTokens[1]);
            if (fraction > 1)
            {
                Console.WriteLine("Error (fraction is equal to or greater than 1).");
                return;
            }

            var resultDenominators = new List<int>();
            var currentDenominator = 2;
            while (fraction > 0.0000001M)
            {
                var currentFraction = 1M / currentDenominator;
                if (currentFraction <= fraction)
                {
                    resultDenominators.Add(currentDenominator);
                    fraction -= currentFraction;
                }

                currentDenominator++;
            }

            Console.WriteLine($"{input} = {string.Join(" + ", resultDenominators.Select(x => "1/" + x))}");
        }
    }
}
