namespace Needles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            Console.ReadLine();
            var numbers = GetNumbers();
            var needles = Console.ReadLine().Split(' ').Select(int.Parse);
            foreach (var needle in needles)
            {
                var index = BinarySearch(needle, numbers);
                Console.Write(index + " ");
            }
        }

        private static IList<int> GetNumbers()
        {
            var numbers = Console.ReadLine().Split(' ');
            var numbersArr = new List<int>();
            var numbersToFill = 1;
            foreach (var num in numbers)
            {
                var number = int.Parse(num);
                if (number == 0)
                {
                    numbersToFill++;
                    continue;
                }

                for (var j = 0; j < numbersToFill; j++)
                {
                    numbersArr.Add(number);
                }

                numbersToFill = 1;
            }

            return numbersArr;
        }

        private static int BinarySearch(int item, IList<int> items)
        {
            var low = 0;
            var high = items.Count - 1;
            var firstOccurrence = int.MinValue;

            while (low <= high)
            {
                var middle = low + ((high - low) >> 1);
                if (items[middle] < item)
                {
                    low = middle + 1;
                }
                else
                {
                    if (items[middle] == item)
                    {
                        firstOccurrence = middle;
                    }

                    high = middle - 1;
                }
            }

            if (firstOccurrence != int.MinValue)
            {
                return firstOccurrence;
            }

            return low;
        }
    }
}