namespace Combinatorics
{
    using System.Collections.Generic;
    using System.Linq;

    public static class Combinatorics
    {
        public static IEnumerable<IEnumerable<int>> GenerateVariationsWithRepetitions(int itemsCount, int setCount)
        {
            return GetVariationsWithRepetitions(new int[itemsCount], setCount);
        }

        public static IEnumerable<IEnumerable<int>> GenerateVariationsWithoutRepetitions(int itemsCount, int setCount)
        {
            return GetVariationsWithoutRepetitions(new int[itemsCount], setCount, new bool[setCount + 1]);
        }

        public static IEnumerable<IEnumerable<int>> GenerateCombinationsWithRepetitions(int itemsCount, int setCount)
        {
            return GetCombinations(new int[itemsCount], setCount, true);
        }

        public static IEnumerable<IEnumerable<int>> GenerateCombinationsWithoutRepetitions(int itemsCount, int setCount)
        {
            return GetCombinations(new int[itemsCount], setCount, false);
        }

        public static IEnumerable<IEnumerable<int>> GeneratePermutationsWithRepetitions(int[] items)
        {
            return GetPermutationsWithRepetitions(items, 0, items.Length - 1);
        }

        public static IEnumerable<IEnumerable<int>> GeneratePermutationsWithoutRepetitions(int itemsCount)
        {
            return GetPermutationsWithoutRepetitions(Enumerable.Range(1, itemsCount).ToArray());
        }

        private static IEnumerable<IEnumerable<int>> GetVariationsWithRepetitions(IList<int> items, int setCount, int index = 0)
        {
            if (index >= items.Count)
            {
                yield return items;
            }
            else
            {
                for (var i = 1; i <= setCount; i++)
                {
                    items[index] = i;

                    foreach (var variation in GetVariationsWithRepetitions(items, setCount, index + 1))
                    {
                        yield return variation;
                    }
                }
            }
        }

        private static IEnumerable<IEnumerable<int>> GetVariationsWithoutRepetitions(IList<int> items, int setCount, IList<bool> usedItems, int index = 0)
        {
            if (index >= items.Count)
            {
                yield return items;
            }
            else
            {
                for (var i = 1; i <= setCount; i++)
                {
                    if (usedItems[i])
                    {
                        continue;
                    }

                    usedItems[i] = true;
                    items[index] = i;

                    foreach (var variation in GetVariationsWithoutRepetitions(items, setCount, usedItems, index + 1))
                    {
                        yield return variation;
                    }

                    usedItems[i] = false;
                }
            }
        }

        private static IEnumerable<IEnumerable<int>> GetCombinations(IList<int> items, int setCount, bool withRepetitions, int index = 0, int start = 1)
        {
            if (index >= items.Count)
            {
                yield return items;
            }
            else
            {
                for (var i = start; i <= setCount; i++)
                {
                    items[index] = i;

                    var combinations = GetCombinations(items, setCount, withRepetitions, index + 1, withRepetitions ? i : i + 1);
                    foreach (var combination in combinations)
                    {
                        yield return combination;
                    }
                }
            }
        }

        private static IEnumerable<IEnumerable<int>> GetPermutationsWithRepetitions(int[] items, int start, int end)
        {
            yield return items;
            for (var left = end - 1; left >= start; left--)
            {
                for (var right = left + 1; right <= end; right++)
                {
                    if (items[left] == items[right])
                    {
                        continue;
                    }

                    Swap(ref items[left], ref items[right]);

                    foreach (var permutation in GetPermutationsWithRepetitions(items, left + 1, end))
                    {
                        yield return permutation;
                    }
                }

                var firstElement = items[left];
                for (var i = left; i <= end - 1; i++)
                {
                    items[i] = items[i + 1];
                }

                items[end] = firstElement;
            }
        }

        private static IEnumerable<IEnumerable<int>> GetPermutationsWithoutRepetitions(int[] items, int startIndex = 0)
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

                    foreach (var permutation in GetPermutationsWithoutRepetitions(items, startIndex + 1))
                    {
                        yield return permutation;
                    }

                    Swap(ref items[startIndex], ref items[i]);
                }
            }
        }

        private static void Swap(ref int first, ref int second)
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