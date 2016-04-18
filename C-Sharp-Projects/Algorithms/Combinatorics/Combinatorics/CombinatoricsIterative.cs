namespace Combinatorics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class CombinatoricsIterative
    {
        public static IEnumerable<IEnumerable<int>> GenerateCombinationsWithoutRepetitions(int itemsCount, int setCount)
        {
            var result = new int[itemsCount];
            var stack = new Stack<int>();
            stack.Push(0);
            while (stack.Any())
            {
                var index = stack.Count - 1;
                var value = stack.Pop();
                while (value < setCount)
                {
                    result[index++] = ++value;
                    stack.Push(value);
                    if (index == itemsCount)
                    {
                        yield return result;
                        break;
                    }
                }
            }
        }

        public static IEnumerable<IEnumerable<int>> GeneratePermutationsWithoutRepetitions(int itemsCount)
        {
            var items = Enumerable.Range(1, itemsCount).ToArray();
            yield return items;
            var key = FindKey(items);
            while (key != -1)
            {
                SwapKey(items, key);
                Array.Sort(items, key + 1, itemsCount - key - 1);
                yield return items;
                key = FindKey(items);
            }
        }

        private static void SwapKey(IList<int> items, int key)
        {
            for (var i = items.Count - 1; i >= key; i--)
            {
                if (items[i] > items[key])
                {
                    items[key] ^= items[i];
                    items[i] ^= items[key];
                    items[key] ^= items[i];
                    return;
                }
            }
        }

        private static int FindKey(IList<int> items)
        {
            for (var i = items.Count - 2; i >= 0; i--)
            {
                if (items[i] < items[i + 1])
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
