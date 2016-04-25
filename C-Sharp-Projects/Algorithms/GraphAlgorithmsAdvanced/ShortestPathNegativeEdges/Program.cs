namespace ShortestPathNegativeEdges
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            var nodesCount = int.Parse(Console.ReadLine().Split(' ').Last());
            var targetNodes = Console.ReadLine().Split(' ');
            var edges = ReadEdges();
            var source = int.Parse(targetNodes[1]);
            var destination = int.Parse(targetNodes[3]);

            var distances = new int[nodesCount];
            var previous = new int[nodesCount];
            for (var i = 0; i < nodesCount; i++)
            {
                distances[i] = int.MaxValue;
                previous[i] = -1;
            }

            distances[source] = 0;
            FillDistances(nodesCount, edges, distances, previous);
            PrintResult(source, destination, edges, distances, previous);
        }

        private static void PrintResult(int source, int destination, IEnumerable<Edge> edges, IList<int> distances, IList<int> previous)
        {
            foreach (var edge in edges)
            {
                if (distances[edge.StartNode] + edge.Weight < distances[edge.EndNode])
                {
                    var cycle = GetCycle(edge.StartNode, previous);
                    Console.WriteLine("Negative cycle detected: {0}", string.Join(" -> ", cycle));
                    return;
                }
            }

            var path = GetPath(destination, previous);
            Console.WriteLine();
            Console.WriteLine("Distance [{0} -> {1}]: {2}", source, destination, distances[destination]);
            Console.WriteLine("Path: {0}", string.Join(" -> ", path));
        }

        private static IEnumerable<int> GetPath(int destination, IList<int> previous)
        {
            var path = new List<int>();
            var currentNode = destination;
            while (currentNode != -1)
            {
                path.Add(currentNode);
                currentNode = previous[currentNode];
            }

            path.Reverse();
            return path;
        }

        private static IEnumerable<int> GetCycle(int destination, IList<int> previous)
        {
            var path = new List<int>();
            var currentNode = destination;
            do
            {
                path.Add(currentNode);
                currentNode = previous[currentNode];
            }
            while (currentNode != destination && currentNode != -1);

            path.Reverse();
            return path;
        }

        private static void FillDistances(int nodesCount, ICollection<Edge> edges, IList<int> distances, IList<int> previous)
        {
            for (var i = 0; i < nodesCount; i++)
            {
                foreach (var edge in edges)
                {
                    if (distances[edge.StartNode] == int.MaxValue)
                    {
                        continue;
                    }

                    var newDistance = distances[edge.StartNode] + edge.Weight;
                    if (newDistance < distances[edge.EndNode])
                    {
                        distances[edge.EndNode] = newDistance;
                        previous[edge.EndNode] = edge.StartNode;
                    }
                }
            }
        }

        private static IList<Edge> ReadEdges()
        {
            var edges = new List<Edge>();
            var edgesCount = int.Parse(Console.ReadLine().Split(' ').Last());
            for (var i = 0; i < edgesCount; i++)
            {
                var tokens = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
                edges.Add(new Edge(tokens[0], tokens[1], tokens[2]));
            }

            return edges;
        }
    }
}
