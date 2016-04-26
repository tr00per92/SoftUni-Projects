namespace CoinSum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CoinSum
    {
        public static void Main()
        {
            while (true)
            {
                Console.Write("S = ");
                var sum = int.Parse(Console.ReadLine());
                Console.Write("Coins = ");
                var coins = Console.ReadLine().Trim('{').Trim('}').Split(',').Select(int.Parse).ToList();
                Console.WriteLine("Combinations with unlimited coins: " + GetUnlimitedCombinationsCount(coins, sum));
                Console.WriteLine("Combinations with limited coins: " + GetLimitedCombinationsCount(coins, sum));
            }
        } 

        private static int GetUnlimitedCombinationsCount(IEnumerable<int> coins, int sum)
        {
            var combinationsCount = new int[sum + 1];
            combinationsCount[0] = 1;
            foreach (var coin in coins)
            {
                for (var i = coin; i <= sum; i++)
                {
                    combinationsCount[i] += combinationsCount[i - coin];
                }
            }

            return combinationsCount[sum];
        }

        private static int GetLimitedCombinationsCount(IEnumerable<int> coins, int sum)
        {
            var combinationsCount = 0;
            var possibleSums = new HashSet<int> { 0 };
            foreach (var coin in coins)
            {
                var newSums = new HashSet<int>();
                foreach (var possibleSum in possibleSums)
                {
                    var newSum = possibleSum + coin;
                    newSums.Add(newSum);
                    if (newSum == sum)
                    {
                        combinationsCount++;
                    }
                }

                possibleSums.UnionWith(newSums);
            }

            return combinationsCount;
        }
    }
}