namespace LongestPathInTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LongestPathInTree
    {
        private static readonly IDictionary<int, IList<int>> nodesToChildren = new Dictionary<int, IList<int>>();
        private static readonly IDictionary<int, int> nodesToParents = new Dictionary<int, int>();

        public static void Main()
        {
            ReadInput();
            FindLongesPath();
        }

        private static void ReadInput()
        {
            var nodesCount = int.Parse(Console.ReadLine() ?? "0");
            var edgesCount = int.Parse(Console.ReadLine() ?? "0");
            for (var i = 0; i < edgesCount; i++)
            {
                var currentCouple = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
                if (!nodesToChildren.ContainsKey(currentCouple[0]))
                {
                    nodesToChildren.Add(currentCouple[0], new List<int>());
                }

                nodesToChildren[currentCouple[0]].Add(currentCouple[1]);
                nodesToParents.Add(currentCouple[1], currentCouple[0]);
            }
        }

        private static void FindLongesPath()
        {
            var leafToRootSums = new Dictionary<int, List<int>>();
            var leafs = nodesToParents.Keys.Where(node => !nodesToChildren.ContainsKey(node));
            foreach (var leaf in leafs)
            {
                var sum = leaf;
                var currentNode = leaf;
                var allNodes = new List<int> { leaf };
                while (nodesToParents.ContainsKey(currentNode))
                {
                    currentNode = nodesToParents[currentNode];
                    sum += currentNode;
                    allNodes.Add(currentNode);
                }

                leafToRootSums.Add(sum, allNodes);
            }

            var maxSums = new List<int>();
            var root = nodesToChildren.Keys.First(node => !nodesToParents.ContainsKey(node));
            foreach (var node in nodesToChildren[root])
            {
                var sumsContainingNode = leafToRootSums.Where(x => x.Value.Contains(node));
                maxSums.Add(sumsContainingNode.Max(x => x.Key));
            }

            var maxSum = FindMaxSumOfTwoNumbers(maxSums) - root;
            Console.WriteLine("Largest path sum: " + maxSum);
        }

        private static int FindMaxSumOfTwoNumbers(IList<int> numbers)
        {
            var maxSum = 0;
            for (var i = 0; i < numbers.Count; i++)
            {
                var currentMax = 0;
                for (var j = 0; j < numbers.Count; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    var sum = numbers[i] + numbers[j];
                    currentMax = Math.Max(currentMax, sum);
                }

                maxSum = Math.Max(currentMax, maxSum);
            }

            return maxSum;
        }
    }
}
