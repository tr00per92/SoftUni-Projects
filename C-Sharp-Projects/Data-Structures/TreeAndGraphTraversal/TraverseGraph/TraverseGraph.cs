namespace TraverseGraph
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TraverseGraph
    {
        private static bool[] visitedNodes;
        private static List<int>[] graph;

        public static void Main()
        {
            ReadGraph();
            FindConnectedComponents();
        }

        private static void ReadGraph()
        {
            var numberOfNodes = int.Parse(Console.ReadLine() ?? "0");
            graph = new List<int>[numberOfNodes];
            for (var i = 0; i < numberOfNodes; i++)
            {
                var input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    graph[i] = new List<int>();
                }
                else
                {
                    graph[i] = input.Split(' ').Select(int.Parse).ToList();
                }
            }
        }

        private static void DFS(int node)
        {
            if (!visitedNodes[node])
            {
                visitedNodes[node] = true;
                foreach (var child in graph[node])
                {
                    DFS(child);
                }

                Console.Write(" " + node);
            }
        }

        private static void FindConnectedComponents()
        {
            visitedNodes = new bool[graph.Length];
            for (var startNode = 0; startNode < graph.Length; startNode++)
            {
                if (!visitedNodes[startNode])
                {
                    Console.Write("Connected component:");
                    DFS(startNode);
                    Console.WriteLine();
                }
            }
        }
    }
}