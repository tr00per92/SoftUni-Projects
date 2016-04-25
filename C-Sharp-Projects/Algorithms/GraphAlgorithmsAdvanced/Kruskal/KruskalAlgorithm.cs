namespace Kruskal
{
    using System.Collections.Generic;

    public class KruskalAlgorithm
    {
        public static List<Edge> Kruskal(int numberOfVertices, List<Edge> edges)
        {
            var parents = new int[numberOfVertices];
            for (var i = 0; i < numberOfVertices; i++)
            {
                parents[i] = i;
            }

            var spannignTree = new List<Edge>();
            edges.Sort();
            foreach (var edge in edges)
            {
                var rootStart = FindRoot(edge.StartNode, parents);
                var rootEnd = FindRoot(edge.EndNode, parents);
                if (rootStart != rootEnd)
                {
                    spannignTree.Add(edge);
                    parents[rootEnd] = rootStart;
                }
            }

            return spannignTree;
        }

        public static int FindRoot(int node, IList<int> parents)
        {
            var root = node;
            while (parents[root] != root)
            {
                root = parents[root];
            }

            while (node != root)
            {
                var parent = parents[node];
                parents[node] = root;
                node = parent;
            }

            return root;
        }
    }
}
