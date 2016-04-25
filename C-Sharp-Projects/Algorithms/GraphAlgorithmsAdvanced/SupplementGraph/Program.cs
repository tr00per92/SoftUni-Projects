namespace SupplementGraph
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Program
    {
        private static int currentDepth;
        private static int nodesCount;
        private static IList<int>[] graph;
        private static bool[] visited;
        private static int[] lowpoint;

        private static readonly Stack<int> stack = new Stack<int>();
        private static readonly ISet<int> usedNodes = new HashSet<int>();
        private static readonly ICollection<IList<int>> stronglyConnectedComponents = new List<IList<int>>();

        public static void Main()
        {
            ReadGraph();
            for (var node = 0; node < nodesCount; node++)
            {
                if (!visited[node])
                {
                    FindStronglyConnectedComponents(node);
                }
            }

            var dag = BuildDirectedAcyclicGraph();
            var noInDegreeCount = dag.Keys.Count(x => !dag.Values.Any(v => v.Contains(x)));
            var noOutDegreeCount = dag.Count(x => !x.Value.Any());

            var minNewEdges = Math.Max(noInDegreeCount, noOutDegreeCount);
            Console.WriteLine(minNewEdges);
        }

        private static IDictionary<IList<int>, IList<IList<int>>> BuildDirectedAcyclicGraph()
        {
            var dag = new Dictionary<IList<int>, IList<IList<int>>>();
            foreach (var component1 in stronglyConnectedComponents)
            {
                dag[component1] = new List<IList<int>>();
                foreach (var component2 in stronglyConnectedComponents)
                {
                    if (component1 == component2)
                    {
                        continue;
                    }

                    if (component2.Any(c2 => component1.Any(c1 => graph[c1].Contains(c2))))
                    {
                        dag[component1].Add(component2);
                    }
                }
            }

            return dag;
        } 

        private static void FindStronglyConnectedComponents(int node)
        {
            lowpoint[node] = currentDepth;
            currentDepth++;
            visited[node] = true;
            stack.Push(node);

            var min = lowpoint[node];
            foreach (var childNode in graph[node])
            {
                if (usedNodes.Contains(childNode))
                {
                    continue;
                }

                if (!visited[childNode])
                {
                    FindStronglyConnectedComponents(childNode);
                }

                if (lowpoint[childNode] < min)
                {
                    min = lowpoint[childNode];
                }
            }

            if (min >= lowpoint[node])
            {
                var component = new List<int>();
                int currentNode;
                do
                {
                    currentNode = stack.Pop();
                    component.Add(currentNode);
                    lowpoint[currentNode] = node;
                } 
                while (currentNode != node);

                stronglyConnectedComponents.Add(component);
                usedNodes.UnionWith(component);
            }
            else
            {
                lowpoint[node] = min;
            }
        }

        private static void ReadGraph()
        {
            nodesCount = int.Parse(Console.ReadLine().Split(' ')[1]);
            visited = new bool[nodesCount];
            lowpoint = new int[nodesCount];
            graph = new IList<int>[nodesCount];
            for (var i = 0; i < nodesCount; i++)
            {
                graph[i] = new List<int>();
            }

            var edgesCount = int.Parse(Console.ReadLine().Split(' ')[1]);
            for (var i = 0; i < edgesCount; i++)
            {
                var nodes = Console.ReadLine().Split(new[] { " -> " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                graph[nodes[0]].Add(nodes[1]);
            }
        }
    }
}
