namespace FindTheRoot
{
    using System;
    using System.Linq;

    public class FindTheRoot
    {
        public static void Main()
        {
            var nodesCount = int.Parse(Console.ReadLine() ?? "0");
            var nodeExists = new bool[nodesCount + 1];
            var hasParent = new bool[nodesCount + 1];
            for (var i = 0; i < nodesCount; i++)
            {
                var couple = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
                nodeExists[couple[0]] = true;
                nodeExists[couple[1]] = true;
                hasParent[couple[1]] = true;
            }

            var roots = hasParent
                .Select((value, index) => new { value, index })
                .Where(node => !node.value && nodeExists[node.index])
                .Select(node => node.index)
                .ToList();

            if (!roots.Any())
            {
                Console.WriteLine("No root!");
            }
            else if (roots.Count > 1)
            {
                Console.WriteLine("Forest is not a tree!");
            }
            else
            {
                Console.WriteLine("Root: " + roots[0]);
            }
        }
    }
}
