namespace Sorting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SortSequence
    {
        public static void Main()
        {
            var count = int.Parse(Console.ReadLine());
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var k = int.Parse(Console.ReadLine());
            Console.WriteLine("The smallest number of operations is: " + FindOperationsCount(numbers, k));
        }

        private static bool IsSorted(ICollection<int> numbers)
        {
            return numbers.SequenceEqual(numbers.OrderBy(x => x));
        }

        private static int FindOperationsCount(IList<int> numbers, int k)
        {
            var uniqueSequences = new HashSet<string> { string.Join(string.Empty, numbers) };
            var sequences = new Queue<KeyValuePair<int, IList<int>>>();
            sequences.Enqueue(new KeyValuePair<int, IList<int>>(0, numbers));

            while (sequences.Any())
            {
                var currentPair = sequences.Dequeue();
                var currentCount = currentPair.Key;
                var currentSequence = currentPair.Value;
                if (IsSorted(currentSequence))
                {
                    return currentCount;
                }
                
                for (var i = 0; i < currentSequence.Count; i++)
                {
                    var toReverce = currentSequence.Skip(i).Take(k).ToList();
                    if (toReverce.Count == k)
                    {
                        var newSequence = new List<int>();
                        toReverce.Reverse();
                        newSequence.AddRange(currentSequence.Take(i));
                        newSequence.AddRange(toReverce);
                        newSequence.AddRange(currentSequence.Skip(i + k));

                        var newSequenceString = string.Join(string.Empty, newSequence);
                        if (!uniqueSequences.Contains(newSequenceString))
                        {
                            uniqueSequences.Add(newSequenceString);
                            sequences.Enqueue(new KeyValuePair<int, IList<int>>(currentCount + 1, newSequence));
                        }
                    }
                }
            }

            return -1;
        }
    }
}
