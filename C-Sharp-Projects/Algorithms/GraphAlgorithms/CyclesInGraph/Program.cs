namespace CyclesInGraph
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static IDictionary<string, List<string>> graph;
        private static ISet<string> visitedNodes;
        private static ISet<string> cycleNodes;

        public static void Main()
        {
            ReadGraph();
            var acyclic = graph.Keys.All(NodeDontHaveCycle);
            Console.WriteLine("Acyclic: {0}", acyclic ? "Yes" : "No");
        }

        private static bool NodeDontHaveCycle(string node)
        {
            if (cycleNodes.Contains(node))
            {
                return false;
            }

            if (!visitedNodes.Contains(node))
            {
                visitedNodes.Add(node);
                cycleNodes.Add(node);

                if (graph.ContainsKey(node))
                {
                    foreach (var child in graph[node])
                    {
                        graph[child].Remove(node);
                        if (!NodeDontHaveCycle(child))
                        {
                            return false;
                        }
                    }
                }

                cycleNodes.Remove(node);
            }

            return true;
        }

        private static void ReadGraph()
        {
            graph = new Dictionary<string, List<string>>();
            visitedNodes = new HashSet<string>();
            cycleNodes = new HashSet<string>();
            var input = Console.ReadLine();
            while (!string.IsNullOrWhiteSpace(input))
            {
                var nodes = input.Split(new[] { " - " }, StringSplitOptions.RemoveEmptyEntries);
                if (!graph.ContainsKey(nodes[0]))
                {
                    graph[nodes[0]] = new List<string>();
                }

                if (!graph.ContainsKey(nodes[1]))
                {
                    graph[nodes[1]] = new List<string>();
                }

                graph[nodes[0]].Add(nodes[1]);
                graph[nodes[1]].Add(nodes[0]);
                input = Console.ReadLine();
            }
        }
    }
}
