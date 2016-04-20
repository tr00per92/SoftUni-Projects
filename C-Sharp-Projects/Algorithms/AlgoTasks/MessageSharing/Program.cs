namespace MessageSharing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static IList<int>[] graph;
        private static IList<string> nodes; 
        private static bool[] visited;
        private static IList<int> startNodes;
        private static int steps = -1;

        public static void Main()
        {
            ReadGraph();

            var lastVisited = startNodes.ToArray();
            while (startNodes.Any())
            {
                steps++;

                foreach (var startNode in startNodes)
                {
                    visited[startNode] = true;
                }

                lastVisited = startNodes.ToArray();
                startNodes = startNodes.SelectMany(x => graph[x]).Where(x => !visited[x]).ToList();
            }

            if (visited.Any(x => !x))
            {
                var notVisited = new List<string>();
                for (int i = 0; i < visited.Length; i++)
                {
                    if (!visited[i])
                    {
                        notVisited.Add(nodes[i]);
                    }
                }

                Console.WriteLine("Cannot reach: {0}", string.Join(", ", new SortedSet<string>(notVisited)));
            }
            else
            {
                Console.WriteLine("All people reached in {0} steps", steps);
                Console.WriteLine("People at last step: {0}", string.Join(", ", new SortedSet<string>(lastVisited.Select(x => nodes[x]))));
            }
        }

        private static void ReadGraph()
        {
            nodes = Console.ReadLine()
                .Split(new []{": "}, StringSplitOptions.RemoveEmptyEntries)[1]
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            
            graph = new IList<int>[nodes.Count];
            for (var i = 0; i < graph.Length; i++)
            {
                graph[i] = new List<int>();
            }

            var connections = Console.ReadLine()
                .Split(new[] { ": " }, StringSplitOptions.RemoveEmptyEntries)[1]
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var connection in connections.Select(x => x.Split(new []{" - "}, StringSplitOptions.RemoveEmptyEntries)))
            {
                graph[nodes.IndexOf(connection[0])].Add(nodes.IndexOf(connection[1]));
                graph[nodes.IndexOf(connection[1])].Add(nodes.IndexOf(connection[0]));
            }

            visited = new bool[graph.Length];

            var start = Console.ReadLine()
                .Split(new[] { ": " }, StringSplitOptions.RemoveEmptyEntries)[1]
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

            startNodes = start.Select(x => nodes.IndexOf(x)).ToList();
        }
    }
}
