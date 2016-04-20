namespace GraphCycles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GraphCycles
    {
        private static readonly IDictionary<int, SortedSet<int>> graph = new SortedDictionary<int, SortedSet<int>>(); 

        public static void Main()
        {
            ReadGraph();

            var noCycles = true;
            foreach (var edge in graph.Keys)
            {
                foreach (var child in graph[edge])
                {
                    if (edge >= child)
                    {
                        continue;
                    }

                    foreach (var grandChild in graph[child])
                    {
                        if (edge >= grandChild || child == grandChild)
                        {
                            continue;
                        }

                        if (graph[grandChild].Contains(edge))
                        {
                            Console.WriteLine($"{{{edge} -> {child} -> {grandChild}}}");
                            noCycles = false;
                        }
                    }
                }
            }

            if (noCycles)
            {
                Console.WriteLine("No cycles found");
            }
        }

        private static void ReadGraph()
        {
            var count = int.Parse(Console.ReadLine());
            for (var i = 0; i < count; i++)
            {
                var input = Console.ReadLine().Split(' ');
                graph[int.Parse(input[0])] = new SortedSet<int>(input.Skip(2).Select(int.Parse));
            }
        }
    }
}
