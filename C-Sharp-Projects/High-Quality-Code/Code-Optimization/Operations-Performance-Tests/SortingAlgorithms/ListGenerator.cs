namespace SortingAlgorithms
{
    using System;
    using System.Collections.Generic;

    public static class ListGenerator
    {
        private static readonly Random RandomGenerator = new Random();

        public static List<int> GenerateOrderedIntList()
        {
            List<int> result = new List<int>();

            for (int i = 0; i <= 100; i++)
            {
                result.Add(i);
            }

            return result;
        }

        public static List<double> GenerateOrderedDoubleList()
        {
            List<double> result = new List<double>();

            for (int i = 0; i <= 100; i++)
            {
                result.Add(i + 0.5);
            }

            return result;
        }

        public static List<string> GenerateOrderedStringList()
        {
            List<string> result = new List<string>();

            for (int i = 0; i <= 25; i++)
            {
                result.Add(((char)('a' + i)).ToString());
            }

            return result;
        }

        public static List<int> GenerateReversedIntList()
        {
            List<int> result = new List<int>();

            for (int i = 100; i >= 0; i--)
            {
                result.Add(i);
            }

            return result;
        }

        public static List<double> GenerateReversedDoubleList()
        {
            List<double> result = new List<double>();

            for (int i = 100; i >= 0; i--)
            {
                result.Add(i + 0.5);
            }

            return result;
        }

        public static List<string> GenerateReversedStringList()
        {
            List<string> result = new List<string>();

            for (int i = 25; i >= 0; i--)
            {
                result.Add(((char)('a' + i)).ToString());
            }

            return result;
        }

        public static List<int> GenerateRandomIntList()
        {
            List<int> result = new List<int>();

            for (int i = 0; i <= 100; i++)
            {
                result.Add(RandomGenerator.Next(0, 100));
            }

            return result;
        }

        public static List<double> GenerateRandomDoubleList()
        {
            List<double> result = new List<double>();

            for (int i = 0; i <= 100; i++)
            {
                result.Add(RandomGenerator.NextDouble() * 100);
            }

            return result;
        }

        public static List<string> GenerateRandomStringList()
        {
            List<string> result = new List<string>();

            for (int i = 0; i <= 25; i++)
            {
                result.Add(((char)('a' + RandomGenerator.Next(0, 25))).ToString());
            }

            return result;
        }
    }
}
