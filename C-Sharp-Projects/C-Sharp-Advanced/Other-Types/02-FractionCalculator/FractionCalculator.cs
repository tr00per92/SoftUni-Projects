using System;

namespace _02_FractionCalculator
{
    class FractionCalculator
    {
        public static void Main()
        {
            Fraction fraction1 = new Fraction(22, 7);
            Console.WriteLine(fraction1);
            Fraction fraction2 = new Fraction(40, 4);
            Console.WriteLine(fraction2);
            Fraction result = fraction1 + fraction2;
            Console.WriteLine(result.Numerator);
            Console.WriteLine(result.Denominator);
            Console.WriteLine(result);
            Console.WriteLine(fraction2 - fraction1);
        }
    }
}
