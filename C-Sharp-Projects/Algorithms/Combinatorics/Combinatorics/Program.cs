namespace Combinatorics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            //var collections = Combinatorics.GenerateVariationsWithRepetitions(2, 3);
            //var collections = Combinatorics.GenerateVariationsWithoutRepetitions(2, 3);

            //var collections = Combinatorics.GenerateCombinationsWithRepetitions(2, 3);
            //var collections = Combinatorics.GenerateCombinationsWithoutRepetitions(2, 3);

            //var collections = Combinatorics.GeneratePermutationsWithRepetitions(new[] { 1, 3, 5, 5 });
            //var collections = Combinatorics.GeneratePermutationsWithoutRepetitions(3);

            //var collections = CombinatoricsIterative.GeneratePermutationsWithoutRepetitions(3);
            //var collections = CombinatoricsIterative.GenerateCombinationsWithoutRepetitions(3, 5);

            //foreach (var collection in collections)
            //{
            //    Console.WriteLine(string.Join(" ", collection));
            //}

            GenerateSubsetsOfStringArray(new[] { "test", "rock", "fun" }, 2);
        }

        private static void GenerateSubsetsOfStringArray(IList<string> strings, int itemsCount)
        {
            var combinations = Combinatorics.GenerateCombinationsWithoutRepetitions(itemsCount, strings.Count);
            foreach (var combination in combinations)
            {
                Console.WriteLine("({0})", string.Join(" ", combination.Select(x => strings[x - 1])));
            }
        }
    }
}