namespace Kruskal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class KruskalMain
    {
        public static void Main()
        {
            //var numberOfVertices = 9;
            //var graphEdges = new List<Edge>
            //{
            //    new Edge(0, 3, 9),
            //    new Edge(0, 5, 4),
            //    new Edge(0, 8, 5),
            //    new Edge(1, 4, 8),
            //    new Edge(1, 7, 7),
            //    new Edge(2, 6, 12),
            //    new Edge(3, 5, 2),
            //    new Edge(3, 6, 8),
            //    new Edge(3, 8, 20),
            //    new Edge(4, 7, 10),
            //    new Edge(6, 8, 7)
            //};

            var numberOfVertices = int.Parse(Console.ReadLine().Split(' ').Last());
            var graphEdges = ReadEdges();
            var minimumSpanningForest = KruskalAlgorithm.Kruskal(numberOfVertices, graphEdges);
            Console.WriteLine();
            Console.WriteLine("Minimum spanning forest weight: {0}", minimumSpanningForest.Sum(e => e.Weight));
            foreach (var edge in minimumSpanningForest)
            {
                Console.WriteLine(edge);
            }
        }

        private static List<Edge> ReadEdges()
        {
            var edgesCount = int.Parse(Console.ReadLine().Split(' ').Last());
            var edges = new List<Edge>(edgesCount);
            for (var i = 0; i < edgesCount; i++)
            {
                var input = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
                edges.Add(new Edge(input[0], input[1], input[2]));
            }

            return edges;
        }
    }
}
