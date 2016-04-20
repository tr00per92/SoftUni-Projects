namespace NonCrossingBridges
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static int[] numbers;
        private static int[] bridgesCount;
        private static int maxCount;

        public static void Main()
        {
            numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            bridgesCount = CalcBridgesCount(numbers);
            maxCount = bridgesCount.Max();

            if (maxCount == 0)
            {
                Console.WriteLine("No bridges found");
            }
            else if (maxCount == 1)
            {
                Console.WriteLine("1 bridge found");
            }
            else
            {
                Console.WriteLine(maxCount + " bridges found");
            }

            Console.WriteLine(string.Join(" ", GetBridges()));
        }

        private static string[] GetBridges()
        {
            var bridgeIndexes = new List<int>();
            var lastCount = 0;
            foreach (var bridgeCount in bridgesCount)
            {
                if (bridgeCount > lastCount)
                {
                    var bridgeIndex = Array.IndexOf(bridgesCount, bridgeCount);
                    bridgeIndexes.Add(bridgeIndex);

                    var currentStop = numbers[bridgeIndex];
                    for (var i = bridgeIndex - 1; i >= 0; i--)
                    {
                        if (numbers[i] == currentStop)
                        {
                            bridgeIndexes.Add(i);
                            break;
                        }
                    }

                    lastCount = bridgeCount;
                }
            }

            var bridges = Enumerable.Repeat("X", numbers.Length).ToArray();
            foreach (var index in bridgeIndexes)
            {
                bridges[index] = numbers[index].ToString();
            }

            return bridges;
        }

        private static int[] CalcBridgesCount(int[] seq)
        {
            var bridgeCounts = new int[seq.Length];

            for (var index = 1; index < seq.Length; index++)
            {
                bridgeCounts[index] = bridgeCounts[index - 1];
                for (var prevIndex = index - 1; prevIndex >= 0; prevIndex--)
                {
                    if (seq[index] == seq[prevIndex] && bridgeCounts[prevIndex] + 1 >= bridgeCounts[index])
                    {
                        bridgeCounts[index] = bridgeCounts[prevIndex] + 1;
                        break;
                    }
                }
            }

            return bridgeCounts;
        }
    }
}
