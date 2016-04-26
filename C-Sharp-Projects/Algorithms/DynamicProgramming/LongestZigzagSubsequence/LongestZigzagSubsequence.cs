namespace LongestZigzagSubsequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LongestZigzagSubsequence
    {
        public static void Main()
        {
            var sequence = Console.ReadLine().Split(',').Select(int.Parse).ToList();
            Console.WriteLine(string.Join(" ", FindLongestZigzagSubsequence(sequence)));
        }

        private static IEnumerable<int> FindLongestZigzagSubsequence(IList<int> sequence)
        {
            var increasingLengths = new int[sequence.Count];
            var decreasingLengths = new int[sequence.Count];
            var previous = new int[sequence.Count];
            var maxLength = 0;
            var lastIndex = -1;
            for (var i = 0; i < sequence.Count; i++)
            {
                increasingLengths[i] = 1;
                decreasingLengths[i] = 1;
                previous[i] = -1;
                for (var j = 0; j < i; j++)
                {
                    if (sequence[j] < sequence[i] && decreasingLengths[j] >= increasingLengths[i])
                    {
                        increasingLengths[i] = decreasingLengths[j] + 1;
                        previous[i] = j;
                    }
                    else if (sequence[j] > sequence[i] && increasingLengths[j] >= decreasingLengths[i])
                    {
                        decreasingLengths[i] = increasingLengths[j] + 1;
                        previous[i] = j;
                    }
                }

                var currentMax = Math.Max(increasingLengths[i], decreasingLengths[i]);
                if (currentMax > maxLength)
                {
                    maxLength = currentMax;
                    lastIndex = i;
                }
            }

            var longestSubsequence = GetLongestSubsequence(sequence, previous, lastIndex);
            return longestSubsequence;
        }

        private static IEnumerable<int> GetLongestSubsequence(IList<int> sequence, IList<int> previous, int lastIndex)
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