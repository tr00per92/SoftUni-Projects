namespace ShortestPath
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ShortestPath
    {
        public static void Main()
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            var graph = new Dictionary<Node, List<Edge>>();
            var matrix = new int[rows, cols];
            var nodes = ReadInput(rows, cols, matrix, graph);

            var source = nodes.First();
            var destination = nodes.Last();
            Dijkstra(graph, source);
            var path = FindPath(destination);

            Console.WriteLine("Length: " + (destination.Distance + matrix[destination.Row, destination.Col]));
            Console.WriteLine("Path: " + string.Join(" ", path.Select(x => matrix[x.Row, x.Col])));
        }

        private static IList<Node> ReadInput(int rows, int cols, int[,] matrix, IDictionary<Node, List<Edge>> graph)
        {
            var nodes = new List<Node>();
            for (var row = 0; row < rows; row++)
            {
                var input = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
                for (var col = 0; col < cols; col++)
                {
                    matrix[row, col] = input[col];
                    nodes.Add(new Node(row, col));
                }
            }

            foreach (var node in nodes)
            {
                graph[node] = new List<Edge>();
                if (node.Row > 0)
                {
                    graph[node].Add(new Edge(nodes.First(n => n.Row == node.Row - 1 && n.Col == node.Col), matrix[node.Row, node.Col]));
                }

                if (node.Row < rows - 1)
                {
                    graph[node].Add(new Edge(nodes.First(n => n.Row == node.Row + 1 && n.Col == node.Col), matrix[node.Row, node.Col]));
                }

                if (node.Col > 0)
                {
                    graph[node].Add(new Edge(nodes.First(n => n.Row == node.Row && n.Col == node.Col - 1), matrix[node.Row, node.Col]));
                }

                if (node.Col < cols - 1)
                {
                    graph[node].Add(new Edge(nodes.First(n => n.Row == node.Row && n.Col == node.Col + 1), matrix[node.Row, node.Col]));
                }
            }

            return nodes;
        }

        private static void Dijkstra(IDictionary<Node, List<Edge>> graph, Node sourceNode)
        {
            var queue = new PriorityQueue<Node>();

            foreach (var node in graph)
            {
                node.Key.Distance = int.MaxValue;
            }

            sourceNode.Distance = 0;
            queue.Enqueue(sourceNode);

            while (queue.Count != 0)
            {
                var currentNode = queue.Dequeue();

                if (currentNode.Distance == int.MaxValue)
                {
                    break;
                }

                foreach (var childEdge in graph[currentNode])
                {
                    var newDistance = currentNode.Distance + childEdge.Distance;
                    if (newDistance < childEdge.Node.Distance)
                    {
                        childEdge.Node.Distance = newDistance;
                        childEdge.Node.PreviousNode = currentNode;
                        queue.Enqueue(childEdge.Node);
                    }
                }
            }
        }

        private static IEnumerable<Node> FindPath(Node node)
        {
            var path = new List<Node>();
            while (node != null)
            {
                path.Add(node);
                node = node.PreviousNode;
            }

            path.Reverse();
            return path;
        }
    }
}
