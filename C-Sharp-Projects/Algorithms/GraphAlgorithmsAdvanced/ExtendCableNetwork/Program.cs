namespace ExtendCableNetwork
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            var connectedNodes = new HashSet<int>();
            var disconnectedEdges = new List<Edge>();
            var budget = int.Parse(Console.ReadLine().Split(' ').Last());
            ReadGraph(connectedNodes, disconnectedEdges);
            disconnectedEdges.Sort();

            var newConnections = FindNewConnections(connectedNodes, disconnectedEdges, budget);
            Console.WriteLine();
            Console.WriteLine(string.Join(Environment.NewLine, newConnections));
            Console.WriteLine("Budget used: {0}", newConnections.Sum(e => e.Weight));
        }

        private static ICollection<Edge> FindNewConnections(ISet<int> connectedNodes, IEnumerable<Edge> disconnectedEdges, int budget)
        {
            var newConnections = new List<Edge>();
            foreach (var edge in disconnectedEdges)
            {
                if (connectedNodes.Contains(edge.StartNode) && connectedNodes.Contains(edge.EndNode))
                {
                    continue;
                }

                if (budget >= edge.Weight)
                {
                    connectedNodes.Add(edge.StartNode);
                    connectedNodes.Add(edge.EndNode);
                    newConnections.Add(edge);
                    budget -= edge.Weight;
                }
            }

            return newConnections;
        }

        private static void ReadGraph(ISet<int> connectedNodes, ICollection<Edge> disconnectedEdges)
        {
            var nodesCount = int.Parse(Console.ReadLine().Split(' ').Last());
            var edgesCount = int.Parse(Console.ReadLine().Split(' ').Last());
            for (var i = 0; i < edgesCount; i++)
            {
                var input = Console.ReadLine().Split(' ');
                var edge = new Edge(int.Parse(input[0]), int.Parse(input[1]), int.Parse(input[2]));
                if (input.Length > 3 && input[3] == "connected")
                {
                    connectedNodes.Add(edge.StartNode);
                    connectedNodes.Add(edge.EndNode);
                }
                else
                {
                    disconnectedEdges.Add(edge);
                }
            }
        }
    }
}
