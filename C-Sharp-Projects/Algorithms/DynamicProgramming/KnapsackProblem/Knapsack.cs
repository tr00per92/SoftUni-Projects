namespace KnapsackProblem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Knapsack
    {
        public static void Main()
        {
            var items = new[]
            {
                new Item { Weight = 5, Price = 30 },
                new Item { Weight = 8, Price = 120 },
                new Item { Weight = 7, Price = 10 },
                new Item { Weight = 0, Price = 20 },
                new Item { Weight = 4, Price = 50 },
                new Item { Weight = 5, Price = 80 },
                new Item { Weight = 2, Price = 10 }
            };

            const int knapsackCapacity = 20;

            var itemsTaken = FillKnapsack(items, knapsackCapacity);

            Console.WriteLine("Knapsack weight capacity: {0}", knapsackCapacity);
            Console.WriteLine("Take the following items in the knapsack:");
            foreach (var item in itemsTaken)
            {
                Console.WriteLine("  (weight: {0}, price: {1})", item.Weight, item.Price);
            }

            Console.WriteLine("Total weight: {0}", itemsTaken.Sum(i => i.Weight));
            Console.WriteLine("Total price: {0}", itemsTaken.Sum(i => i.Price));
        }

        public static ICollection<Item> FillKnapsack(IList<Item> items, int capacity)
        {
            var maxPrice = new int[items.Count, capacity + 1];
            var isItemTaken = new bool[items.Count, capacity + 1];
            for (var i = 0; i <= capacity; i++)
            {
                if (items[0].Weight <= i)
                {
                    maxPrice[0, i] = items[0].Price;
                    isItemTaken[0, i] = true;
                }
            }

            for (var i = 1; i < items.Count; i++)
            {
                for (var j = 0; j <= capacity; j++)
                {
                    maxPrice[i, j] = maxPrice[i - 1, j];
                    var remainingCapacity = j - items[i].Weight;
                    if (remainingCapacity >= 0 &&
                        maxPrice[i, j] < maxPrice[i, remainingCapacity] + items[i].Price)
                    {
                        maxPrice[i, j] += items[i].Price;
                        maxPrice[i, remainingCapacity] += items[i].Price;
                        isItemTaken[i, j] = true;
                    }
                }
            }

            var itemsTaken = FindItemsTaken(items, isItemTaken, capacity);
            return itemsTaken;
        }

        private static ICollection<Item> FindItemsTaken(IList<Item> items, bool[,] isItemTaken, int capacity)
        {
            var itemsTaken = new List<Item>();
            var currentIndex = items.Count - 1;
            while (currentIndex >= 0)
            {
                if (isItemTaken[currentIndex, capacity])
                {
                    itemsTaken.Add(items[currentIndex]);
                    capacity -= items[currentIndex].Weight;
                }

                currentIndex--;
            }

            itemsTaken.Reverse();
            return itemsTaken;
        }
    }
}