using System;

namespace _01_InterestCalculator
{
    public class InterestCalculator
    {
        public delegate decimal CalcInterest(decimal sum, decimal interest, decimal years);

        public decimal Money { get; set; }

        public InterestCalculator(decimal sum, decimal interest, decimal years, CalcInterest interestType)
        {
            CalcInterest GetInterest = interestType;
            this.Money = GetInterest(sum, interest, years);
        }

        public static void Main()
        {
            // using Func<>
            Func<decimal, decimal, decimal, decimal> GetInterest = GetSimpleInterest;
            Console.WriteLine(Math.Round(GetInterest(500m, 0.056m, 10m), 4));

            GetInterest = GetCompoundInterest;
            Console.WriteLine(Math.Round(GetInterest(2500m, 0.072m, 15m), 4));

            // using delegates and InterestCalculator constructor
            InterestCalculator simple = new InterestCalculator(500m, 0.056m, 10m, GetSimpleInterest);
            Console.WriteLine(Math.Round(simple.Money, 4));

            InterestCalculator compound = new InterestCalculator(2500m, 0.072m, 15m, GetCompoundInterest);
            Console.WriteLine(Math.Round(compound.Money, 4));

        }

        public static decimal GetSimpleInterest(decimal sum, decimal interest, decimal years)
        {
            return sum * (1 + interest * years);
        }

        public static decimal GetCompoundInterest(decimal sum, decimal interest, decimal years)
        {
            int totalPeriods = (int)(12 * years);
            for (int i = 0; i < totalPeriods; i++)
            {
                sum *= 1 + interest / 12;
            }
            return sum;
        }
    }
}
