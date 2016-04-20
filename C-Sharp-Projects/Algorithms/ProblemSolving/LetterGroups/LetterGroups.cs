namespace LetterGroups
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class LetterGroups
    {
        public static void Main()
        {
            var letters = Console.ReadLine().ToCharArray().GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            foreach (var permutation in GetPermutations(letters.Keys.ToArray()))
            {
                var result = new StringBuilder();
                foreach (var c in permutation)
                {
                    for (var i = 0; i < letters[c]; i++)
                    {
                        result.Append(c);
                    }
                }

                Console.WriteLine(result);
            }
        }

        private static IEnumerable<IEnumerable<char>> GetPermutations(char[] items, int startIndex = 0)
        {
            if (startIndex >= items.Length)
            {
                yield return items;
            }
            else
            {
                for (var i = startIndex; i < items.Length; i++)
                {
                    Swap(ref items[startIndex], ref items[i]);

                    foreach (var permutation in GetPermutations(items, startIndex + 1))
                    {
                        yield return permutation;
                    }

                    Swap(ref items[startIndex], ref items[i]);
                }
            }
        }

        private static void Swap(ref char first, ref char second)
        {
            if (first == second)
            {
                return;
            }

            first ^= second;
            second ^= first;
            first ^= second;
        }
    }
}
