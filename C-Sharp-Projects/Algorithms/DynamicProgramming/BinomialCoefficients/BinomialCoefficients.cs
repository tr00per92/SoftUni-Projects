namespace BinomialCoefficients
{
    using System;
    using System.Numerics;

    public class BinomialCoefficients
    {
        private const int Max = 3001;
        private static readonly BigInteger[,] binomCoefficients = new BigInteger[Max, Max];

        public static void Main()
        {
            Console.Write("n = ");
            var n = int.Parse(Console.ReadLine());
            Console.Write("k = ");
            var k = int.Parse(Console.ReadLine());
            Console.WriteLine("result = " + FindBinomCoefficient(n, k));
        }

        private static BigInteger FindBinomCoefficient(int n, int k)
        {
            if (k > n)
            {
                return 0;
            }

            if (k == 0 || k == n)
            {
                return 1;
            }

            if (binomCoefficients[n, k] == 0)
            {
                binomCoefficients[n, k] = FindBinomCoefficient(n - 1, k - 1) + FindBinomCoefficient(n - 1, k);
            }

            return binomCoefficients[n, k];
        }
    }
}