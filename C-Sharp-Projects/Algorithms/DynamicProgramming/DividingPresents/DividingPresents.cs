namespace DividingPresents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DividingPresents
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split(',').Select(int.Parse).ToList();
            var totalSum = numbers.Sum();
            var alanNumbers = GetAlanNumbers(numbers, (int)Math.Ceiling(totalSum / 2.0));
            var alanSum = alanNumbers.Sum();
            var bobSum = totalSum - alanSum;
            Console.WriteLine("Difference: {0}", bobSum - alanSum);
            Console.WriteLine("Alan: {0}  Bob: {1}", alanSum, bobSum);
            Console.WriteLine("Alan takes: {0}", string.Join(" ", alanNumbers));
            Console.WriteLine("Bob takes the rest.");
        }

        private static ICollection<int> GetAlanNumbers(IList<int> numbers, int capacity)
        {
            var maxSum = new int[numbers.Count, capacity + 1];
            var isNumberTaken = new bool[numbers.Count, capacity + 1];
            for (var i = 0; i <= capacity; i++)
            {
                if (numbers[0] <= i)
                {
                    maxSum[0, i] = numbers[0];
                    isNumberTaken[0, i] = true;
                }
            }

            for (var i = 1; i < numbers.Count; i++)
            {
                for (var j = 0; j <= capacity; j++)
                {
                    maxSum[i, j] = maxSum[i - 1, j];
                    var remainingCapacity = j - numbers[i];
                    if (remainingCapacity >= 0 &&
                        maxSum[i, j] < maxSum[i, remainingCapacity] + numbers[i])
                    {
                        maxSum[i, j] += numbers[i];
                        maxSum[i, remainingCapacity] += numbers[i];
                        isNumberTaken[i, j] = true;
                    }
                }
            }

            var numbersTaken = FindNumbersTaken(numbers, isNumberTaken, capacity);
            return numbersTaken;
        }

        private static ICollection<int> FindNumbersTaken(IList<int> numbers, bool[,] isNumberTaken, int capacity)
        {
            var numbersTaken = new List<int>();
            var currentIndex = numbers.Count - 1;
            while (currentIndex >= 0)
            {
                if (isNumberTaken[currentIndex, capacity])
                {
                    numbersTaken.Add(numbers[currentIndex]);
                    capacity -= numbers[currentIndex];
                }

                currentIndex--;
            }

            return numbersTaken;
        }
    }
}