namespace DistanceBetweenVertices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static IList<int> nodes;
        private static IList<int>[] graph;

        public static void Main()
        {
            Console.WriteLine("Graph: ");
            ReadGraph();
            Console.WriteLine("Distances to find: ");
            var distancesToFind = ReadDistances();
            foreach (var pair in distancesToFind)
            {
                var distance = FindDistance(nodes.IndexOf(pair[0]), nodes.IndexOf(pair[1]));
                Console.WriteLine("{{{0}, {1}}} -> {2}", pair[0], pair[1], distance);
            }
        }

        private static void ReadGraph()
        {
            nodes = new List<int>();
            var inputGraph = new List<IList<int>>();

            var input = Console.ReadLine();
            while (!string.IsNullOrWhiteSpace(input))
            {
                var tokens = input.Split(new[] { "->" }, StringSplitOptions.RemoveEmptyEntries);
                var currentNode = int.Parse(tokens[0]);
                nodes.Add(currentNode);
                if (tokens.Length > 1)
                {
                    var childNodes = tokens[1].Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    inputGraph.Add(childNodes.Select(int.Parse).ToList());
                }
                else
                {
                    inputGraph.Add(new List<int>());
                }

                input = Console.ReadLine();
            }

            graph = inputGraph.ToArray();
        }

        private static IEnumerable<IList<int>> ReadDistances()
        {
            var distances = new List<IList<int>>();
            var input = Console.ReadLine();
            while (!string.IsNullOrWhiteSpace(input))
            {
                distances.Add(input.Split('-').Select(int.Parse).ToList());
                input = Console.ReadLine();
            }

            return distances;
        }

        public static int FindDistance(int node, int target)
        {
            var queue = new Queue<int>();
            var visited = new bool[graph.Length];
            var previous = Enumerable.Repeat(-1, graph.Length).ToArray();

            visited[node] = true;
            queue.Enqueue(node);
            while (queue.Any())
            {
                var currentNode = queue.Dequeue();
                if (currentNode == target)
                {
                    var stepsCount = 0;
                    var prev = previous[currentNode];
                    while (prev != -1)
                    {
                        stepsCount++;
                        prev = previous[prev];
                    }

                    return stepsCount;
                }

                foreach (var childNode in graph[currentNode].Select(x => nodes.IndexOf(x)).Where(x => !visited[x]))
                {
                    queue.Enqueue(childNode);
                    visited[childNode] = true;
                    previous[childNode] = currentNode;
                }
            }

            return -1;
        }
    }
}
