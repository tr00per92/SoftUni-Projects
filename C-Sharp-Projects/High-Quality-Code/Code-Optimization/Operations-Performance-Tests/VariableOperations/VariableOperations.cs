namespace VariableOperations
{
    using System;
    using System.Diagnostics;

    public class VariableOperations
    {
        public static void Main()
        {
            const int testsCount = 3000000;
            Stopwatch stopwatch = new Stopwatch();

            #region AddTests

            Console.WriteLine("Add Tests");

            int intSum = int.MinValue;
            stopwatch.Start();
            for (int i = 0; i < testsCount; i++)
            {
                intSum += i;
            }

            stopwatch.Stop();
            Console.WriteLine("Int - {0}", stopwatch.Elapsed);
            stopwatch.Reset();

            long longSum = long.MinValue;
            stopwatch.Start();
            for (long i = 0; i < testsCount; i++)
            {
                longSum += i;
            }
            
            stopwatch.Stop();
            Console.WriteLine("Long - {0}", stopwatch.Elapsed);
            stopwatch.Reset();

            double doubleSum = double.MinValue;
            stopwatch.Start();
            for (double i = 0; i < testsCount; i++)
            {
                doubleSum += i;
            }

            stopwatch.Stop();
            Console.WriteLine("Double - {0}", stopwatch.Elapsed);
            stopwatch.Reset();

            float floatSum = float.MinValue;
            stopwatch.Start();
            for (float i = 0; i < testsCount; i++)
            {
                floatSum += i;
            }

            stopwatch.Stop();
            Console.WriteLine("Float - {0}", stopwatch.Elapsed);
            stopwatch.Reset();

            decimal decimalSum = decimal.MinValue;
            stopwatch.Start();
            for (decimal i = 0; i < testsCount; i++)
            {
                decimalSum += i;
            }

            stopwatch.Stop();
            Console.WriteLine("Decimal - {0}", stopwatch.Elapsed);
            stopwatch.Reset();
            Console.WriteLine();

            #endregion
            
            #region SubtractTest

            Console.WriteLine("Subtract Tests");

            intSum = int.MaxValue;
            stopwatch.Start();
            for (int i = 0; i < testsCount; i++)
            {
                intSum -= i;
            }

            stopwatch.Stop();
            Console.WriteLine("Int - {0}", stopwatch.Elapsed);
            stopwatch.Reset();

            longSum = long.MaxValue;
            stopwatch.Start();
            for (long i = 0; i < testsCount; i++)
            {
                longSum -= i;
            }

            stopwatch.Stop();
            Console.WriteLine("Long - {0}", stopwatch.Elapsed);
            stopwatch.Reset();

            doubleSum = double.MaxValue;
            stopwatch.Start();
            for (double i = 0; i < testsCount; i++)
            {
                doubleSum -= i;
            }

            stopwatch.Stop();
            Console.WriteLine("Double - {0}", stopwatch.Elapsed);
            stopwatch.Reset();

            floatSum = float.MaxValue;
            stopwatch.Start();
            for (float i = 0; i < testsCount; i++)
            {
                floatSum -= i;
            }

            stopwatch.Stop();
            Console.WriteLine("Float - {0}", stopwatch.Elapsed);
            stopwatch.Reset();

            decimalSum = decimal.MaxValue;
            stopwatch.Start();
            for (decimal i = 0; i < testsCount; i++)
            {
                decimalSum -= i;
            }

            stopwatch.Stop();
            Console.WriteLine("Decimal - {0}", stopwatch.Elapsed);
            stopwatch.Reset();
            Console.WriteLine();

            #endregion

            #region IncrementTests

            Console.WriteLine("Increment Tests");

            intSum = int.MinValue;
            stopwatch.Start();
            for (int i = 0; i < testsCount; i++)
            {
                intSum++;
            }

            stopwatch.Stop();
            Console.WriteLine("Int - {0}", stopwatch.Elapsed);
            stopwatch.Reset();

            longSum = long.MinValue;
            stopwatch.Start();
            for (long i = 0; i < testsCount; i++)
            {
                longSum++;
            }

            stopwatch.Stop();
            Console.WriteLine("Long - {0}", stopwatch.Elapsed);
            stopwatch.Reset();
            
            doubleSum = double.MinValue;
            stopwatch.Start();
            for (double i = 0; i < testsCount; i++)
            {
                doubleSum++;
            }

            stopwatch.Stop();
            Console.WriteLine("Double - {0}", stopwatch.Elapsed);
            stopwatch.Reset();

            floatSum = float.MinValue;
            stopwatch.Start();
            for (float i = 0; i < testsCount; i++)
            {
                floatSum++;
            }

            stopwatch.Stop();
            Console.WriteLine("Float - {0}", stopwatch.Elapsed);
            stopwatch.Reset();

            decimalSum = decimal.MinValue;
            stopwatch.Start();
            for (decimal i = 0; i < testsCount; i++)
            {
                decimalSum++;
            }

            stopwatch.Stop();
            Console.WriteLine("Decimal - {0}", stopwatch.Elapsed);
            stopwatch.Reset();
            Console.WriteLine();

            #endregion
            
            #region MultiplyTests

            Console.WriteLine("Multiply Tests");

            intSum = 1;
            stopwatch.Start();
            for (int i = 1; i < testsCount; i++)
            {
                intSum *= i;
            }

            stopwatch.Stop();
            Console.WriteLine("Int - {0}", stopwatch.Elapsed);
            stopwatch.Reset();

            longSum = 1L;
            stopwatch.Start();
            for (long i = 1; i < testsCount; i++)
            {
                longSum *= i;
            }

            stopwatch.Stop();
            Console.WriteLine("Long - {0}", stopwatch.Elapsed);
            stopwatch.Reset();

            doubleSum = 1.0;
            stopwatch.Start();
            for (double i = 1; i < testsCount; i++)
            {
                doubleSum *= i;
            }

            stopwatch.Stop();
            Console.WriteLine("Double - {0}", stopwatch.Elapsed);
            stopwatch.Reset();

            floatSum = 1F;
            stopwatch.Start();
            for (float i = 1; i < testsCount; i++)
            {
                floatSum *= i;
            }

            stopwatch.Stop();
            Console.WriteLine("Float - {0}", stopwatch.Elapsed);
            stopwatch.Reset();

            decimalSum = 0M;
            stopwatch.Start();
            for (decimal i = 1; i < testsCount; i++)
            {
                decimalSum *= i;
            }

            stopwatch.Stop();
            Console.WriteLine("Decimal - {0}", stopwatch.Elapsed);
            stopwatch.Reset();
            Console.WriteLine();

            #endregion
            
            #region DivisionTests

            Console.WriteLine("Division Tests");

            intSum = int.MaxValue;
            stopwatch.Start();
            for (int i = 1; i < testsCount; i++)
            {
                intSum /= i;
            }

            stopwatch.Stop();
            Console.WriteLine("Int - {0}", stopwatch.Elapsed);
            stopwatch.Reset();

            longSum = long.MaxValue;
            stopwatch.Start();
            for (long i = 1; i < testsCount; i++)
            {
                longSum /= i;
            }

            stopwatch.Stop();
            Console.WriteLine("Long - {0}", stopwatch.Elapsed);
            stopwatch.Reset();

            doubleSum = double.MaxValue;
            stopwatch.Start();
            for (double i = 1; i < testsCount; i++)
            {
                doubleSum /= i;
            }

            stopwatch.Stop();
            Console.WriteLine("Double - {0}", stopwatch.Elapsed);
            stopwatch.Reset();

            floatSum = float.MaxValue;
            stopwatch.Start();
            for (float i = 1; i < testsCount; i++)
            {
                floatSum /= i;
            }

            stopwatch.Stop();
            Console.WriteLine("Float - {0}", stopwatch.Elapsed);
            stopwatch.Reset();

            decimalSum = decimal.MaxValue;
            stopwatch.Start();
            for (decimal i = 1; i < testsCount; i++)
            {
                decimalSum /= i;
            }

            stopwatch.Stop();
            Console.WriteLine("Decimal - {0}", stopwatch.Elapsed);
            stopwatch.Reset();
            Console.WriteLine();

            #endregion
        }
    }
}
