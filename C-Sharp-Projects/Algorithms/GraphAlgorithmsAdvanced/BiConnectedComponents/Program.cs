namespace BiConnectedComponents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Program
    {
        private static int nodesCount;
        private static int currentDepth;
        private static IList<int>[] graph;
        private static bool[] visited;
        private static int?[] parent;
        private static int[] depth;
        private static int[] lowpoint;

        private static readonly Stack<Tuple<int, int>> stack = new Stack<Tuple<int, int>>();
        private static readonly ICollection<ISet<int>> biConnectedComponents = new List<ISet<int>>();

        public static void Main()
        {
            ReadGraph();
            for (var i = 0; i < nodesCount; i++)
            {
                if (!visited[i])
                {
                    FindBiConnectedComponents(i);
                }
            }

            Console.WriteLine();
            Console.WriteLine("Bi-Connected Components: ");
            foreach (var biConnectedComponent in biConnectedComponents)
            {
                Console.WriteLine(string.Join(" ", biConnectedComponent));
            }
        }

        private static void FindBiConnectedComponents(int node)
        {
            visited[node] = true;
            currentDepth++;
            depth[node] = currentDepth;
            lowpoint[node] = currentDepth;

            foreach (var childNode in graph[node])
            {
                if (!visited[childNode])
                {
                    var currentEdge = Tuple.Create(node, childNode);
                    stack.Push(currentEdge);
                    parent[childNode] = node;
                    FindBiConnectedComponents(childNode);

                    if (lowpoint[childNode] >= depth[node])
                    {
                        var biConnectedComponent = new HashSet<int>();
                        Tuple<int, int> edge;
                        do
                        {
                            edge = stack.Pop();
                            biConnectedComponent.Add(edge.Item1);
                            biConnectedComponent.Add(edge.Item2);
                        }
                        while (!edge.Equals(currentEdge));

                        biConnectedComponents.Add(biConnectedComponent);
                    }

                    lowpoint[node] = Math.Min(lowpoint[node], lowpoint[childNode]);
                }
                else if (childNode != parent[node] && depth[childNode] < depth[node])
                {
                    stack.Push(Tuple.Create(node, childNode));
                    lowpoint[node] = Math.Min(lowpoint[node], depth[childNode]);
                }
            }
        }

        private static void ReadGraph()
        {
            nodesCount = int.Parse(Console.ReadLine().Split(' ')[1]);
            graph = new IList<int>[nodesCount];
            visited = new bool[nodesCount];
            parent = new int?[nodesCount];
            depth = new int[nodesCount];
            lowpoint = new int[nodesCount];

            var edgesCount = int.Parse(Console.ReadLine().Split(' ')[1]);
            for (var i = 0; i < edgesCount; i++)
            {
                var nodes = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
                if (graph[nodes[0]] == null)
                {
                    graph[nodes[0]] = new List<int>();
                }

                if (graph[nodes[1]] == null)
                {
                    graph[nodes[1]] = new List<int>();
                }

                graph[nodes[0]].Add(nodes[1]);
                graph[nodes[1]].Add(nodes[0]);
            }
        }
    }
}
