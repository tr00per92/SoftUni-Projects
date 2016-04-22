namespace SumOfCoins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SumOfCoins
    {
        public static void Main()
        {
            var availableCoins = new[] { 1, 2, 5, 10, 20, 50 };
            var targetSum = 923;
            var selectedCoins = ChooseCoins(availableCoins, targetSum);

            Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
            foreach (var selectedCoin in selectedCoins)
            {
                Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
            }
        }

        public static Dictionary<int, int> ChooseCoins(IEnumerable<int> coins, int targetSum)
        {
            var chosenCoins = new Dictionary<int, int>();
            var currentSum = 0;
            foreach (var coin in coins.OrderByDescending(c => c))
            {
                var coinsToTake = (targetSum - currentSum) / coin;
                if (coinsToTake > 0)
                {
                    chosenCoins[coin] = coinsToTake;
                    currentSum += coinsToTake * coin;
                }

                if (currentSum == targetSum)
                {
                    return chosenCoins;
                }
            }

            throw new InvalidOperationException("Cannot produce the desired sum.");
        }
    }
}