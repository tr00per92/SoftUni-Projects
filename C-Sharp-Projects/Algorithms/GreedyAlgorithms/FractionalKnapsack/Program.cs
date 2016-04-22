namespace FractionalKnapsack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var capacity = int.Parse(Console.ReadLine().Split(' ').Last());
            var items = ReadItems();
            var itemsTaken = GetItemsTaken(items, capacity);

            Console.WriteLine();
            foreach (var item in itemsTaken)
            {
                Console.WriteLine($"Take {item.Value:P} of item with price {item.Key.Price:F2} and weight {item.Key.Weight:F2}");
            }

            Console.WriteLine($"Total price: {itemsTaken.Sum(i => i.Value * i.Key.Price):F2}");
        }

        private static IDictionary<Item, decimal> GetItemsTaken(IEnumerable<Item> items, int capacity)
        {
            var itemsTaken = new Dictionary<Item, decimal>();
            foreach (var item in items)
            {
                if (item.Weight <= capacity)
                {
                    itemsTaken[item] = 1;
                    capacity -= item.Weight;
                }
                else
                {
                    itemsTaken[item] = (decimal)capacity / item.Weight;
                    capacity = 0;
                }

                if (capacity == 0)
                {
                    break;
                }
            }

            return itemsTaken;
        }

        private static IEnumerable<Item> ReadItems()
        {
            var items = new List<Item>();
            var itemsCount = int.Parse(Console.ReadLine().Split(' ').Last());
            for (var i = 0; i < itemsCount; i++)
            {
                var tokens = Console.ReadLine().Split(' ');
                items.Add(new Item(int.Parse(tokens[0]), int.Parse(tokens[2])));
            }

            return items.OrderByDescending(i => (decimal)i.Price / i.Weight);
        }
    }
}
