namespace SortingAlgorithms
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Text;

    public class SortingAlgorithms
    {
        public static void Main()
        {
            Stopwatch stopwatch = new Stopwatch();

            #region Ordered Ints

            Console.WriteLine("Ordered int tests");
            Console.WriteLine();

            List<int> orderedInts = ListGenerator.GenerateOrderedIntList();
            Console.WriteLine("Before sort: {0}", ListToString(orderedInts));
            stopwatch.Start();
            orderedInts = Sorters.SelectionSort(orderedInts);
            stopwatch.Stop();
            Console.WriteLine("After selection sort: {0}", ListToString(orderedInts));
            Console.WriteLine("Time - {0}", stopwatch.Elapsed);
            stopwatch.Reset();
            Console.WriteLine();

            orderedInts = ListGenerator.GenerateOrderedIntList();
            Console.WriteLine("Before sort: {0}", ListToString(orderedInts));
            stopwatch.Start();
            orderedInts = Sorters.InsertionSort(orderedInts);
            stopwatch.Stop();
            Console.WriteLine("After insertion sort: {0}", ListToString(orderedInts));
            Console.WriteLine("Time - {0}", stopwatch.Elapsed);
            stopwatch.Reset();
            Console.WriteLine();

            orderedInts = ListGenerator.GenerateOrderedIntList();
            Console.WriteLine("Before sort: {0}", ListToString(orderedInts));
            stopwatch.Start();
            orderedInts = Sorters.QuickSort(orderedInts);
            stopwatch.Stop();
            Console.WriteLine("After quick sort: {0}", ListToString(orderedInts));
            Console.WriteLine("Time - {0}", stopwatch.Elapsed);
            stopwatch.Reset();
            Console.WriteLine();

            #endregion

            #region Ordered Doubles

            Console.WriteLine("Ordered double tests");
            Console.WriteLine();

            List<double> orderedDoubles = ListGenerator.GenerateOrderedDoubleList();
            Console.WriteLine("Before sort: {0}", ListToString(orderedDoubles));
            stopwatch.Start();
            orderedDoubles = Sorters.SelectionSort(orderedDoubles);
            stopwatch.Stop();
            Console.WriteLine("After selection sort: {0}", ListToString(orderedDoubles));
            Console.WriteLine("Time - {0}", stopwatch.Elapsed);
            stopwatch.Reset();
            Console.WriteLine();

            orderedDoubles = ListGenerator.GenerateOrderedDoubleList();
            Console.WriteLine("Before sort: {0}", ListToString(orderedDoubles));
            stopwatch.Start();
            orderedDoubles = Sorters.InsertionSort(orderedDoubles);
            stopwatch.Stop();
            Console.WriteLine("After insertion sort: {0}", ListToString(orderedDoubles));
            Console.WriteLine("Time - {0}", stopwatch.Elapsed);
            stopwatch.Reset();
            Console.WriteLine();

            orderedDoubles = ListGenerator.GenerateOrderedDoubleList();
            Console.WriteLine("Before sort: {0}", ListToString(orderedDoubles));
            stopwatch.Start();
            orderedDoubles = Sorters.QuickSort(orderedDoubles);
            stopwatch.Stop();
            Console.WriteLine("After quick sort: {0}", ListToString(orderedDoubles));
            Console.WriteLine("Time - {0}", stopwatch.Elapsed);
            stopwatch.Reset();
            Console.WriteLine();

            #endregion

            #region Ordered Strings

            Console.WriteLine("Ordered string tests");
            Console.WriteLine();

            List<string> orderedStrings = ListGenerator.GenerateOrderedStringList();
            Console.WriteLine("Before sort: {0}", ListToString(orderedStrings));
            stopwatch.Start();
            orderedStrings = Sorters.SelectionSort(orderedStrings);
            stopwatch.Stop();
            Console.WriteLine("After selection sort: {0}", ListToString(orderedStrings));
            Console.WriteLine("Time - {0}", stopwatch.Elapsed);
            stopwatch.Reset();
            Console.WriteLine();

            orderedStrings = ListGenerator.GenerateOrderedStringList();
            Console.WriteLine("Before sort: {0}", ListToString(orderedStrings));
            stopwatch.Start();
            orderedStrings = Sorters.InsertionSort(orderedStrings);
            stopwatch.Stop();
            Console.WriteLine("After insertion sort: {0}", ListToString(orderedStrings));
            Console.WriteLine("Time - {0}", stopwatch.Elapsed);
            stopwatch.Reset();
            Console.WriteLine();

            orderedStrings = ListGenerator.GenerateOrderedStringList();
            Console.WriteLine("Before sort: {0}", ListToString(orderedStrings));
            stopwatch.Start();
            orderedStrings = Sorters.QuickSort(orderedStrings);
            stopwatch.Stop();
            Console.WriteLine("After quick sort: {0}", ListToString(orderedStrings));
            Console.WriteLine("Time - {0}", stopwatch.Elapsed);
            stopwatch.Reset();
            Console.WriteLine();

            #endregion

            #region Reverse Ordered Ints

            Console.WriteLine("Reverse ordered int tests");
            Console.WriteLine();

            List<int> reversedInts = ListGenerator.GenerateReversedIntList();
            Console.WriteLine("Before sort: {0}", ListToString(reversedInts));
            stopwatch.Start();
            reversedInts = Sorters.SelectionSort(reversedInts);
            stopwatch.Stop();
            Console.WriteLine("After selection sort: {0}", ListToString(reversedInts));
            Console.WriteLine("Time - {0}", stopwatch.Elapsed);
            stopwatch.Reset();
            Console.WriteLine();

            reversedInts = ListGenerator.GenerateReversedIntList();
            Console.WriteLine("Before sort: {0}", ListToString(reversedInts));
            stopwatch.Start();
            reversedInts = Sorters.InsertionSort(reversedInts);
            stopwatch.Stop();
            Console.WriteLine("After insertion sort: {0}", ListToString(reversedInts));
            Console.WriteLine("Time - {0}", stopwatch.Elapsed);
            stopwatch.Reset();
            Console.WriteLine();

            reversedInts = ListGenerator.GenerateReversedIntList();
            Console.WriteLine("Before sort: {0}", ListToString(reversedInts));
            stopwatch.Start();
            reversedInts = Sorters.QuickSort(reversedInts);
            stopwatch.Stop();
            Console.WriteLine("After quick sort: {0}", ListToString(reversedInts));
            Console.WriteLine("Time - {0}", stopwatch.Elapsed);
            stopwatch.Reset();
            Console.WriteLine();

            #endregion

            #region Reverse Ordered Doubles

            Console.WriteLine("Reverse ordered double tests");
            Console.WriteLine();

            List<double> reversedDoubles = ListGenerator.GenerateReversedDoubleList();
            Console.WriteLine("Before sort: {0}", ListToString(reversedDoubles));
            stopwatch.Start();
            reversedDoubles = Sorters.SelectionSort(reversedDoubles);
            stopwatch.Stop();
            Console.WriteLine("After selection sort: {0}", ListToString(reversedDoubles));
            Console.WriteLine("Time - {0}", stopwatch.Elapsed);
            stopwatch.Reset();
            Console.WriteLine();

            reversedDoubles = ListGenerator.GenerateReversedDoubleList();
            Console.WriteLine("Before sort: {0}", ListToString(reversedDoubles));
            stopwatch.Start();
            reversedDoubles = Sorters.InsertionSort(reversedDoubles);
            stopwatch.Stop();
            Console.WriteLine("After insertion sort: {0}", ListToString(reversedDoubles));
            Console.WriteLine("Time - {0}", stopwatch.Elapsed);
            stopwatch.Reset();
            Console.WriteLine();

            reversedDoubles = ListGenerator.GenerateReversedDoubleList();
            Console.WriteLine("Before sort: {0}", ListToString(reversedDoubles));
            stopwatch.Start();
            reversedDoubles = Sorters.QuickSort(reversedDoubles);
            stopwatch.Stop();
            Console.WriteLine("After quick sort: {0}", ListToString(reversedDoubles));
            Console.WriteLine("Time - {0}", stopwatch.Elapsed);
            stopwatch.Reset();
            Console.WriteLine();

            #endregion

            #region Reverse Ordered Strings

            Console.WriteLine("Reverse ordered string tests");
            Console.WriteLine();

            List<string> reversedStrings = ListGenerator.GenerateReversedStringList();
            Console.WriteLine("Before sort: {0}", ListToString(reversedStrings));
            stopwatch.Start();
            reversedStrings = Sorters.SelectionSort(reversedStrings);
            stopwatch.Stop();
            Console.WriteLine("After selection sort: {0}", ListToString(reversedStrings));
            Console.WriteLine("Time - {0}", stopwatch.Elapsed);
            stopwatch.Reset();
            Console.WriteLine();

            reversedStrings = ListGenerator.GenerateReversedStringList();
            Console.WriteLine("Before sort: {0}", ListToString(reversedStrings));
            stopwatch.Start();
            reversedStrings = Sorters.InsertionSort(reversedStrings);
            stopwatch.Stop();
            Console.WriteLine("After insertion sort: {0}", ListToString(reversedStrings));
            Console.WriteLine("Time - {0}", stopwatch.Elapsed);
            stopwatch.Reset();
            Console.WriteLine();

            reversedStrings = ListGenerator.GenerateReversedStringList();
            Console.WriteLine("Before sort: {0}", ListToString(reversedStrings));
            stopwatch.Start();
            reversedStrings = Sorters.QuickSort(reversedStrings);
            stopwatch.Stop();
            Console.WriteLine("After quick sort: {0}", ListToString(reversedStrings));
            Console.WriteLine("Time - {0}", stopwatch.Elapsed);
            stopwatch.Reset();
            Console.WriteLine();

            #endregion

            #region Random Ints

            Console.WriteLine("Random int tests");
            Console.WriteLine();

            List<int> randomInts = ListGenerator.GenerateRandomIntList();
            Console.WriteLine("Before sort: {0}", ListToString(randomInts));
            stopwatch.Start();
            randomInts = Sorters.SelectionSort(randomInts);
            stopwatch.Stop();
            Console.WriteLine("After selection sort: {0}", ListToString(randomInts));
            Console.WriteLine("Time - {0}", stopwatch.Elapsed);
            stopwatch.Reset();
            Console.WriteLine();

            randomInts = ListGenerator.GenerateRandomIntList();
            Console.WriteLine("Before sort: {0}", ListToString(randomInts));
            stopwatch.Start();
            randomInts = Sorters.InsertionSort(randomInts);
            stopwatch.Stop();
            Console.WriteLine("After insertion sort: {0}", ListToString(randomInts));
            Console.WriteLine("Time - {0}", stopwatch.Elapsed);
            stopwatch.Reset();
            Console.WriteLine();

            randomInts = ListGenerator.GenerateRandomIntList();
            Console.WriteLine("Before sort: {0}", ListToString(randomInts));
            stopwatch.Start();
            randomInts = Sorters.QuickSort(randomInts);
            stopwatch.Stop();
            Console.WriteLine("After quick sort: {0}", ListToString(randomInts));
            Console.WriteLine("Time - {0}", stopwatch.Elapsed);
            stopwatch.Reset();
            Console.WriteLine();

            #endregion

            #region Random Doubles

            Console.WriteLine("Random double tests");
            Console.WriteLine();

            List<double> randomDoubles = ListGenerator.GenerateRandomDoubleList();
            Console.WriteLine("Before sort: {0}", ListToString(randomDoubles));
            stopwatch.Start();
            randomDoubles = Sorters.SelectionSort(randomDoubles);
            stopwatch.Stop();
            Console.WriteLine("After selection sort: {0}", ListToString(randomDoubles));
            Console.WriteLine("Time - {0}", stopwatch.Elapsed);
            stopwatch.Reset();
            Console.WriteLine();

            randomDoubles = ListGenerator.GenerateRandomDoubleList();
            Console.WriteLine("Before sort: {0}", ListToString(randomDoubles));
            stopwatch.Start();
            randomDoubles = Sorters.InsertionSort(randomDoubles);
            stopwatch.Stop();
            Console.WriteLine("After insertion sort: {0}", ListToString(randomDoubles));
            Console.WriteLine("Time - {0}", stopwatch.Elapsed);
            stopwatch.Reset();
            Console.WriteLine();

            randomDoubles = ListGenerator.GenerateRandomDoubleList();
            Console.WriteLine("Before sort: {0}", ListToString(randomDoubles));
            stopwatch.Start();
            randomDoubles = Sorters.QuickSort(randomDoubles);
            stopwatch.Stop();
            Console.WriteLine("After quick sort: {0}", ListToString(randomDoubles));
            Console.WriteLine("Time - {0}", stopwatch.Elapsed);
            stopwatch.Reset();
            Console.WriteLine();

            #endregion

            #region Random Strings

            Console.WriteLine("Random string tests");
            Console.WriteLine();

            List<string> randomStrings = ListGenerator.GenerateRandomStringList();
            Console.WriteLine("Before sort: {0}", ListToString(randomStrings));
            stopwatch.Start();
            randomStrings = Sorters.SelectionSort(randomStrings);
            stopwatch.Stop();
            Console.WriteLine("After selection sort: {0}", ListToString(randomStrings));
            Console.WriteLine("Time - {0}", stopwatch.Elapsed);
            stopwatch.Reset();
            Console.WriteLine();

            randomStrings = ListGenerator.GenerateRandomStringList();
            Console.WriteLine("Before sort: {0}", ListToString(randomStrings));
            stopwatch.Start();
            randomStrings = Sorters.InsertionSort(randomStrings);
            stopwatch.Stop();
            Console.WriteLine("After insertion sort: {0}", ListToString(randomStrings));
            Console.WriteLine("Time - {0}", stopwatch.Elapsed);
            stopwatch.Reset();
            Console.WriteLine();

            randomStrings = ListGenerator.GenerateRandomStringList();
            Console.WriteLine("Before sort: {0}", ListToString(randomStrings));
            stopwatch.Start();
            randomStrings = Sorters.QuickSort(randomStrings);
            stopwatch.Stop();
            Console.WriteLine("After quick sort: {0}", ListToString(randomStrings));
            Console.WriteLine("Time - {0}", stopwatch.Elapsed);
            stopwatch.Reset();
            Console.WriteLine();

            #endregion
        }

        public static string ListToString(List<int> list)
        {
            StringBuilder result = new StringBuilder();

            foreach (int num in list)
            {
                result.AppendFormat("{0} ", num);
            }

            return result.ToString();
        }

        public static string ListToString(List<double> list)
        {
            StringBuilder result = new StringBuilder();

            foreach (double num in list)
            {
                result.AppendFormat("{0:F2} ", num);
            }

            return result.ToString();
        }

        public static string ListToString(List<string> list)
        {
            StringBuilder result = new StringBuilder();

            foreach (string text in list)
            {
                result.AppendFormat("{0} ", text);
            }

            return result.ToString();
        }
    }
}
