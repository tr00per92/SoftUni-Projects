namespace Blocks
{
    using System;
    using System.Collections.Generic;

    public class Blocks
    {
        private static readonly HashSet<string> usedCombinations = new HashSet<string>();
        private static readonly HashSet<string> results = new HashSet<string>();

        public static void Main()
        {
            var lettersCount = int.Parse(Console.ReadLine());
            FindResults(lettersCount);
            PrintResults();
        }

        public static void FindResults(int lettersCount)
        {
            var letters = new char[lettersCount];
            FillLetters(lettersCount, letters);
            var used = new bool[lettersCount];
            var currentCombination = new char[4];
            GenerateVariations(letters, currentCombination, used);
        }

        private static void FillLetters(int lettersCount, IList<char> letters)
        {
            for (var i = 0; i < lettersCount; i++)
            {
                letters[i] = (char)('A' + i);
            }
        }

        private static void GenerateVariations(IList<char> letters, char[] currentCombination, IList<bool> used, int index = 0)
        {
            if (index >= currentCombination.Length)
            {
                AddResult(currentCombination);
            }
            else
            {
                for (var i = 0; i < letters.Count; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        currentCombination[index] = letters[i];
                        GenerateVariations(letters, currentCombination, used, index + 1);
                        used[i] = false;
                    }
                }
            }
        }

        private static void AddResult(char[] currentCombination)
        {
            var result = new string(currentCombination);
            if (!usedCombinations.Contains(result))
            {
                results.Add(result);

                usedCombinations.Add(result);
                usedCombinations.Add(new string(new[] { result[3], result[0], result[2], result[1] }));
                usedCombinations.Add(new string(new[] { result[2], result[3], result[1], result[0] }));
                usedCombinations.Add(new string(new[] { result[1], result[2], result[0], result[3] }));
            }
        }

        private static void PrintResults()
        {
            Console.WriteLine($"Number of blocks: {results.Count}");
            foreach (var combination in results)
            {
                Console.WriteLine(combination);
            }
        }
    }
}