namespace LongestIncreasingSubsequence
{
    using System;
    using System.Collections.Generic;

    public class LongestIncreasingSubsequence
    {
        public static void Main()
        {
            var sequence = new[] { 3, 14, 5, 12, 15, 7, 8, 9, 11, 10, 1 };
            var longestSeq = FindLongestIncreasingSubsequence(sequence);
            Console.WriteLine("Longest increasing subsequence (LIS)");
            Console.WriteLine("  Length: {0}", longestSeq.Count);
            Console.WriteLine("  Sequence: [{0}]", string.Join(", ", longestSeq));
        }

        public static ICollection<int> FindLongestIncreasingSubsequence(IList<int> sequence)
        {
            var lengths = new int[sequence.Count];
            var previous = new int[sequence.Count];
            var maxLength = 0;
            var lastIndex = -1;
            for (var i = 0; i < sequence.Count; i++)
            {
                lengths[i] = 1;
                previous[i] = -1;
                for (var j = 0; j < i; j++)
                {
                    if (sequence[j] < sequence[i] && lengths[j] >= lengths[i])
                    {
                        lengths[i]++;
                        previous[i] = j;
                    }
                }

                if (lengths[i] > maxLength)
                {
                    maxLength = lengths[i];
                    lastIndex = i;
                }
            }

            var longestSubsequence = GetLongestSubsequence(sequence, previous, lastIndex);
            return longestSubsequence;
        }

        private static ICollection<int> GetLongestSubsequence(IList<int> sequence, IList<int> previous, int lastIndex)
        {
            var longestSubsequence = new List<int>();
            while (lastIndex != -1)
            {
                longestSubsequence.Add(sequence[lastIndex]);
                lastIndex = previous[lastIndex];
            }

            longestSubsequence.Reverse();
            return longestSubsequence;
        }
    }
}