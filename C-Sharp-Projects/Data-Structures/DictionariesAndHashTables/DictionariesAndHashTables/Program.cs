namespace DictionariesAndHashTables
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            // SymbolsCount();
            // Phonebook();
        }

        private static void SymbolsCount()
        {
            var symbolsCount = CountSymbols(Console.ReadLine() ?? string.Empty);
            foreach (var pair in symbolsCount.OrderBy(x => x.Key))
            {
                Console.WriteLine("{0}: {1} time{2}", pair.Key, pair.Value, pair.Value > 1 ? "s" : string.Empty);
            }
        }

        private static HashTable<char, int> CountSymbols(string text)
        {
            var occurences = new HashTable<char, int>(); ;
            foreach (var value in text)
            {
                if (!occurences.ContainsKey(value))
                {
                    occurences.Add(value, 0);
                }

                occurences[value]++;
            }

            return occurences;
        }

        private static void Phonebook()
        {
            var phonebook = new HashTable<string, string>();
            var input = Console.ReadLine();
            while (!string.IsNullOrWhiteSpace(input) && input != "search")
            {
                var currentCouple = input.Split('-').ToList();
                phonebook.Add(currentCouple[0], currentCouple[1]);
                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            while (!string.IsNullOrWhiteSpace(input))
            {
                try
                {
                    Console.WriteLine("{0} -> {1}", input, phonebook[input]);
                }
                catch (KeyNotFoundException)
                {
                    Console.WriteLine("Contact {0} does not exist.", input);
                }
                finally
                {
                    input = Console.ReadLine();
                }
            }
        }
    }
}
