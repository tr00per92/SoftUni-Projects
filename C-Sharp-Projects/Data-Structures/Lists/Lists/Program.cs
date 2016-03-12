using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearDataStructurestLists
{
    public class Program
    {
        public static void Main()
        {
            // SumAndAverage();
            // SortWords();
            // LongestSubSequence();
            // RemoveOddOccurences();
            // CountOfOccurences();
            // DistanceInLabyrinth.Calculate();

            Console.ReadKey();
        }

        private static void SumAndAverage()
        {
            var input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                var numbers = input.Split(' ').Select(int.Parse).ToList();
                Console.WriteLine("Sum = {0}; Average = {1}", numbers.Sum(), numbers.Average());
            }
            else
            {
                Console.WriteLine("Sum = 0; Average = 0");
            }
        }

        private static void SortWords()
        {
            var input = Console.ReadLine().Split(' ').ToList();
            input.Sort();
            Console.WriteLine(string.Join(" ", input));
        }

        private static void LongestSubSequence()
        {
            var input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                var numbers = input.Split(' ').Select(int.Parse).ToList();
                var currentNumber = numbers[0];
                var resultNumber = currentNumber;
                var currentCount = 1;
                var resultCount = currentCount;
                for (var i = 1; i < numbers.Count; i++)
                {
                    if (numbers[i] == currentNumber)
                    {
                        currentCount++;
                        if (currentCount > resultCount)
                        {
                            resultCount = currentCount;
                            resultNumber = currentNumber;
                        }
                    }
                    else
                    {
                        currentCount = 1;
                        currentNumber = numbers[i];
                    }
                }

                for (var i = 0; i < resultCount; i++)
                {
                    Console.Write(resultNumber + " ");
                }

                Console.WriteLine();
            }
        }

        private static void RemoveOddOccurences()
        {
            var input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                var items = input.Split(' ').ToList();
                var occurencies = MapOccurencies(items);
                foreach (var pair in occurencies)
                {
                    if (pair.Value % 2 != 0)
                    {
                        items.RemoveAll(p => p == pair.Key);
                    }
                }

                Console.WriteLine(string.Join(" ", items));
            }
        }

        private static void CountOfOccurences()
        {
            var input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                var items = input.Split(' ').ToList();
                items.Sort();
                var occurencies = MapOccurencies(items);
                foreach (var pair in occurencies)
                {
                    Console.WriteLine("{0} -> {1} times", pair.Key, pair.Value);
                }
            }
        }

        private static IDictionary<T, int> MapOccurencies<T>(IEnumerable<T> items)
        {
            var result = new Dictionary<T, int>();
            foreach (var item in items)
            {
                if (!result.ContainsKey(item))
                {
                    result.Add(item, 0);
                }

                result[item]++;
            }

            return result;
        }
    }
}
