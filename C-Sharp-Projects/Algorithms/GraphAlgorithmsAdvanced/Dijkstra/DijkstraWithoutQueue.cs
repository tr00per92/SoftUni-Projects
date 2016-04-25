namespace Dijkstra
{
    using System.Collections.Generic;

    public static class DijkstraWithoutQueue
    {
        public static List<int> DijkstraAlgorithm(int[,] graph, int sourceNode, int destinationNode)
        {
            var length = graph.GetLength(0);
            var distances = new int[length];
            var previous = new int[length];
            for (var i = 0; i < length; i++)
            {
                distances[i] = int.MaxValue;
                previous[i] = int.MinValue;
            }

            distances[sourceNode] = 0;
            FindDistances(graph, length, distances, previous);
            if (distances[destinationNode] == int.MaxValue)
            {
                return null;
            }

            return GetPath(destinationNode, previous);
        }

        private static List<int> GetPath(int destinationNode, IList<int> previous)
        {
            var path = new List<int>();
            var currentNode = destinationNode;
            while (currentNode != int.MinValue)
            {
                path.Add(currentNode);
                currentNode = previous[currentNode];
            }

            path.Reverse();
            return path;
        }

        private static void FindDistances(int[,] graph, int length, IList<int> distances, IList<int> previous)
        {
            var used = new bool[length];
            while (true)
            {
                var minDistance = int.MaxValue;
                var minNode = 0;
                for (var node = 0; node < length; node++)
                {
                    if (!used[node] && distances[node] < minDistance)
                    {
                        minDistance = distances[node];
                        minNode = node;
                    }
                }

                used[minNode] = true;
                if (minDistance == int.MaxValue)
                {
                    return;
                }

                for (var i = 0; i < length; i++)
                {
                    if (graph[minNode, i] > 0)
                    {
                        var newDistance = distances[minNode] + graph[minNode, i];
                        if (newDistance < distances[i])
                        {
                            distances[i] = newDistance;
                            previous[i] = minNode;
                        }
                    }
                }
            }
        }
    }
}
