namespace ComplexOperations
{
    using System;
    using System.Diagnostics;

    public class ComplexOperations
    {
        public static void Main()
        {
            const int testsCount = 3000000;
            Stopwatch stopwatch = new Stopwatch();
            
            #region Sqrt

            Console.WriteLine("Sqrt Tests");

            stopwatch.Start();
            for (float i = 0; i < testsCount; i++)
            {
                Math.Sqrt(i);
            }

            stopwatch.Stop();
            Console.WriteLine("Float - {0}", stopwatch.Elapsed);
            stopwatch.Reset();

            stopwatch.Start();
            for (double i = 0; i < testsCount; i++)
            {
                Math.Sqrt(i);
            }

            stopwatch.Stop();
            Console.WriteLine("Double - {0}", stopwatch.Elapsed);
            stopwatch.Reset();

            stopwatch.Start();
            for (decimal i = 0; i < testsCount; i++)
            {
                Math.Sqrt((double)i);
            }

            stopwatch.Stop();
            Console.WriteLine("Decimal - {0}", stopwatch.Elapsed);
            stopwatch.Reset();
            Console.WriteLine();

            #endregion

            #region Log

            Console.WriteLine("Natural Logarithm Tests");

            stopwatch.Start();
            for (float i = 0; i < testsCount; i++)
            {
                Math.Log10(i);
            }

            stopwatch.Stop();
            Console.WriteLine("Float - {0}", stopwatch.Elapsed);
            stopwatch.Reset();

            stopwatch.Start();
            for (double i = 0; i < testsCount; i++)
            {
                Math.Log10(i);
            }

            stopwatch.Stop();
            Console.WriteLine("Double - {0}", stopwatch.Elapsed);
            stopwatch.Reset();

            stopwatch.Start();
            for (decimal i = 0; i < testsCount; i++)
            {
                Math.Log10((double)i);
            }

            stopwatch.Stop();
            Console.WriteLine("Decimal - {0}", stopwatch.Elapsed);
            stopwatch.Reset();
            Console.WriteLine();

            #endregion

            #region Sinus

            Console.WriteLine("Sinus Tests");

            stopwatch.Start();
            for (float i = 0; i < testsCount; i++)
            {
                Math.Sin(i);
            }

            stopwatch.Stop();
            Console.WriteLine("Float - {0}", stopwatch.Elapsed);
            stopwatch.Reset();

            stopwatch.Start();
            for (double i = 0; i < testsCount; i++)
            {
                Math.Sin(i);
            }

            stopwatch.Stop();
            Console.WriteLine("Double - {0}", stopwatch.Elapsed);
            stopwatch.Reset();

            stopwatch.Start();
            for (decimal i = 0; i < testsCount; i++)
            {
                Math.Sin((double)i);
            }

            stopwatch.Stop();
            Console.WriteLine("Decimal - {0}", stopwatch.Elapsed);
            stopwatch.Reset();
            Console.WriteLine();

            #endregion
        }
    }
}
