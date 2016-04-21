namespace BreakCycles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static readonly IDictionary<string, IList<string>> graph = new SortedDictionary<string, IList<string>>();
        private static readonly ISet<string> visitedNodes = new HashSet<string>();

        public static void Main()
        {
            ReadGraph();
            var removedEdges = new List<Tuple<string, string>>();
            foreach (var source in graph.Keys)
            {
                foreach (var target in graph[source].OrderBy(x => x))
                {
                    graph[source].Remove(target);
                    graph[target].Remove(source);
                    
                    if (HasPath(source, target))
                    {
                        removedEdges.Add(Tuple.Create(source, target));
                    }
                    else
                    {
                        graph[source].Add(target);
                        graph[target].Add(source);
                    }

                    visitedNodes.Clear();
                }
            }

            Console.WriteLine("Edges to remove: " + removedEdges.Count);
            Console.WriteLine(string.Join(Environment.NewLine, removedEdges));
        }

        private static void ReadGraph()
        {
            var input = Console.ReadLine();
            while (!string.IsNullOrWhiteSpace(input))
            {
                var tokens = input.Split(new[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                if (tokens.Length > 1)
                {
                    graph[tokens[0]] = new List<string>(tokens[1].Split(new[] { ",", " " }, StringSplitOptions.RemoveEmptyEntries));
                }
                else
                {
                    graph[tokens[0]] = new List<string>();
                }

                input = Console.ReadLine();
            }
        }

        private static bool HasPath(string source, string target)
        {
            if (source == target)
            {
                return true;
            }

            if (!visitedNodes.Contains(source))
            {
                visitedNodes.Add(source);
                foreach (var child in graph[source])
                {
                    if (HasPath(child, target))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
