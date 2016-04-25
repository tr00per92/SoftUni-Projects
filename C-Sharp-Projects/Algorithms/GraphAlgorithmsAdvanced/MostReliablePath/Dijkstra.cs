namespace MostReliablePath
{
    using System.Collections.Generic;

    public static class Dijkstra
    {
        public static IList<int> FindPath(decimal[,] graph, int length, int sourceNode, int destinationNode)
        {
            var previous = new int[length];
            for (var i = 0; i < length; i++)
            {
                previous[i] = -1;
            }

            var reliabilities = new decimal[length];
            reliabilities[sourceNode] = 1;

            FindReliabilities(graph, length, reliabilities, previous);
            if (reliabilities[destinationNode] == 0)
            {
                return null;
            }

            return GetPath(destinationNode, previous);
        }

        private static IList<int> GetPath(int destinationNode, IList<int> previous)
        {
            var path = new List<int>();
            var currentNode = destinationNode;
            while (currentNode != -1)
            {
                path.Add(currentNode);
                currentNode = previous[currentNode];
            }

            path.Reverse();
            return path;
        }

        private static void FindReliabilities(decimal[,] graph, int length, IList<decimal> reliabilities, IList<int> previous)
        {
            var used = new bool[length];
            while (true)
            {
                var maxReliability = 0M;
                var maxNode = 0;
                for (var node = 0; node < length; node++)
                {
                    if (!used[node] && reliabilities[node] > maxReliability)
                    {
                        maxReliability = reliabilities[node];
                        maxNode = node;
                    }
                }

                used[maxNode] = true;
                if (maxReliability == 0M)
                {
                    return;
                }

                for (var i = 0; i < length; i++)
                {
                    if (graph[maxNode, i] > 0)
                    {
                        var newReliability = reliabilities[maxNode] * graph[maxNode, i];
                        if (newReliability > reliabilities[i])
                        {
                            reliabilities[i] = newReliability;
                            previous[i] = maxNode;
                        }
                    }
                }
            }
        }
    }
}
