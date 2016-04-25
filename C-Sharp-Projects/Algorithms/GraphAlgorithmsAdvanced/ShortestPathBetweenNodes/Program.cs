namespace ShortestPathBetweenNodes
{
    using System;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            var nodesCount = int.Parse(Console.ReadLine().Split(' ').Last());
            var distances = ReadDistances(nodesCount);
            FillDistances(nodesCount, distances);
            PrintResult(nodesCount, distances);
        }

        private static void PrintResult(int nodesCount, int[,] distances)
        {
            Console.WriteLine();
            Console.WriteLine("Shortest paths matrix:");
            foreach (var number in Enumerable.Range(0, nodesCount))
            {
                Console.Write("{0,3}", number);
            }

            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------");
            for (var row = 0; row < nodesCount; row++)
            {
                for (var col = 0; col < nodesCount; col++)
                {
                    Console.Write("{0,3}", distances[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static void FillDistances(int nodesCount, int[,] distances)
        {
            for (var k = 0; k < nodesCount; k++)
            {
                for (var i = 0; i < nodesCount; i++)
                {
                    for (var j = 0; j < nodesCount; j++)
                    {
                        if (distances[i, k] == int.MaxValue || distances[k, j] == int.MaxValue)
                        {
                            continue;
                        }

                        var newDistance = distances[i, k] + distances[k, j];
                        if (newDistance < distances[i, j])
                        {
                            distances[i, j] = newDistance;
                        }
                    }
                }
            }
        }

        private static int[,] ReadDistances(int nodesCount)
        {
            var graph = new int[nodesCount, nodesCount];
            for (var row = 0; row < nodesCount; row++)
            {
                for (var col = 0; col < nodesCount; col++)
                {
                    if (row != col)
                    {
                        graph[row, col] = int.MaxValue;
                    }
                }
            }

            var edgesCount = int.Parse(Console.ReadLine().Split(' ').Last());
            for (var i = 0; i < edgesCount; i++)
            {
                var tokens = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
                graph[tokens[0], tokens[1]] = tokens[2];
                graph[tokens[1], tokens[0]] = tokens[2];
            }

            return graph;
        }
    }
}
