namespace OtherStructures
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;
    using Wintellect.PowerCollections;

    public class Program
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            // EventsInRange();
            // ProductsInRange();
            // FindWordsInText();
            // StringEditor();

            Console.ReadLine();
        }

        private static void StringEditor()
        {
            var text = new BigList<char>();
            while (true)
            {
                var currentLine = Console.ReadLine().Split(' ');
                switch (currentLine[0])
                {
                    case "INSERT":
                    {
                        var position = int.Parse(currentLine[2]);
                        if (position < 0 || position > text.Count - 1)
                        {
                            Console.WriteLine("ERROR");
                        }
                        else
                        {
                            text.InsertRange(position, currentLine[1]);
                        }

                        break;
                    }
                    case "APPEND":
                    {
                        text.AddRange(currentLine[1]);
                        break;
                    }
                    case "DELETE":
                    {
                        var start = int.Parse(currentLine[1]);
                        var count = int.Parse(currentLine[2]);
                        if (count < 1 || start < 0 || start > text.Count - count)
                        {
                            Console.WriteLine("ERROR");
                        }
                        else
                        {
                            text.RemoveRange(start, count);
                        }

                        break;
                    }
                    case "REPLACE":
                    {
                        var start = int.Parse(currentLine[1]);
                        var count = int.Parse(currentLine[2]);
                        if (count < 1 || start < 0 || start > text.Count - count)
                        {
                            Console.WriteLine("ERROR");
                        }
                        else
                        {
                            text.RemoveRange(start, count);
                            text.InsertRange(start, currentLine[3]);
                        }

                        break;
                    }
                    case "PRINT":
                    {
                        Console.WriteLine(text.ToArray());
                        break;
                    }
                }
            }
        }

        private static void FindWordsInText()
        {
            var words = new Dictionary<string, int>();
            var linesCount = int.Parse(Console.ReadLine() ?? "0");
            for (var i = 0; i < linesCount; i++)
            {
                var line = Console.ReadLine().Split(new[] { ",", ".", "!", "?", " " }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var word in line)
                {
                    if (!words.ContainsKey(word))
                    {
                        words[word] = 0;
                    }

                    words[word]++;
                }
            }

            var wordsCount = int.Parse(Console.ReadLine() ?? "0");
            for (var i = 0; i < wordsCount; i++)
            {
                var word = Console.ReadLine() ?? string.Empty;
                Console.WriteLine("{0} -> {1}", word, words[word]);
            }
        }

        private static void ProductsInRange()
        {
            var productsCount = int.Parse(Console.ReadLine() ?? "0");
            var products = new OrderedBag<Product>();
            for (var i = 0; i < productsCount; i++)
            {
                var productTokens = Console.ReadLine().Split(new[] { " | " }, StringSplitOptions.RemoveEmptyEntries);
                products.Add(new Product { Name = productTokens[0], Price = int.Parse(productTokens[1])});
            }

            Console.WriteLine();
            var rangesCount = int.Parse(Console.ReadLine() ?? "0");
            for (var i = 0; i < rangesCount; i++)
            {
                var priceTokens = Console.ReadLine().Split(new[] { " | " }, StringSplitOptions.RemoveEmptyEntries);
                var product1 = new Product { Price = int.Parse(priceTokens[0]) };
                var product2 = new Product { Price = int.Parse(priceTokens[1]) };
                var productsInRange = products.Range(product1, true, product2, true);

                Console.WriteLine();
                Console.WriteLine(productsInRange.Count);
                foreach (var product in productsInRange)
                {
                    Console.WriteLine("{0} | {1}", product.Name, product.Price);
                }

                Console.WriteLine();
            }
        }

        private static void EventsInRange()
        {
            var eventsCount = int.Parse(Console.ReadLine() ?? "0");
            var events = new OrderedMultiDictionary<DateTime, string>(true);
            for (var i = 0; i < eventsCount; i++)
            {
                var eventTokens = Console.ReadLine().Split(new[] {" | "}, StringSplitOptions.RemoveEmptyEntries);
                events.Add(DateTime.Parse(eventTokens[1]), eventTokens[0]);
            }

            Console.WriteLine();
            var rangesCount = int.Parse(Console.ReadLine() ?? "0");
            for (var i = 0; i < rangesCount; i++)
            {
                var dateTokens = Console.ReadLine().Split(new[] { " | " }, StringSplitOptions.RemoveEmptyEntries);
                var eventsInRange = events.Range(DateTime.Parse(dateTokens[0]), true, DateTime.Parse(dateTokens[1]), true).KeyValuePairs;

                Console.WriteLine();
                Console.WriteLine(eventsInRange.Count);
                foreach (var eventInRange in eventsInRange)
                {
                    Console.WriteLine("{0} | {1}", eventInRange.Value, eventInRange.Key);
                }

                Console.WriteLine();
            }
        }
    }
}
