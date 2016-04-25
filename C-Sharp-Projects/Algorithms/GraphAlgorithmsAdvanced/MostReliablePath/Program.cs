namespace MostReliablePath
{
    using System;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            var nodesCount = int.Parse(Console.ReadLine().Split(' ').Last());
            var path = Console.ReadLine().Split(' ');
            var source = int.Parse(path[1]);
            var destination = int.Parse(path[3]);
            var graph = ReadGraph(nodesCount);
            PrintPath(graph, nodesCount, source, destination);
        }

        private static void PrintPath(decimal[,] graph, int nodesCount, int sourceNode, int destinationNode)
        {
            Console.WriteLine();
            var path = Dijkstra.FindPath(graph, nodesCount, sourceNode, destinationNode);
            if (path == null)
            {
                Console.WriteLine("No path found.");
            }
            else
            {
                var reliability = 1M;
                for (var i = 0; i < path.Count - 1; i++)
                {
                    reliability *= graph[path[i], path[i + 1]];
                }

                Console.WriteLine("Most reliable path reliability: {0:P}", reliability);
                Console.WriteLine(string.Join(" -> ", path));
            }
        }

        private static decimal[,] ReadGraph(int nodesCount)
        {
            var graph = new decimal[nodesCount, nodesCount];
            var edgesCount = int.Parse(Console.ReadLine().Split(' ').Last());
            for (var i = 0; i < edgesCount; i++)
            {
                var tokens = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
                graph[tokens[0], tokens[1]] = tokens[2] / 100M;
                graph[tokens[1], tokens[0]] = tokens[2] / 100M;
            }

            return graph;
        }
    }
}
