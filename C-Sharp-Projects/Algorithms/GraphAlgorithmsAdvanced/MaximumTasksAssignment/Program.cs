namespace MaximumTasksAssignment
{
    using System;

    public static class Program
    {
        private const int sourceNode = 0;
        private static int destinationNode;

        private static int peopleCount;
        private static int tasksCount;
        private static string[] nodesMapping;

        private static int size;
        private static sbyte[,] graph;
        private static sbyte[,] flow;
        private static int[] path;
        private static bool[] visited;
        private static bool pathFound;

        public static void Main()
        {
            ReadGraph();
            do
            {
                visited = new bool[size];
                pathFound = false;
                visited[sourceNode] = true;
                path[0] = sourceNode;
                FindAugmentingPath(sourceNode, 1);
            }
            while (pathFound);

            var maxFlowSize = 0;
            for (var i = 0; i < size; i++)
            {
                maxFlowSize += flow[i, destinationNode];
            }

            for (var row = 1; row < size - 1; row++)
            {
                for (var col = 1; col < size - 1; col++)
                {
                    if (flow[row, col] != 0)
                    {
                        Console.WriteLine(nodesMapping[row] + " - " + nodesMapping[col]);
                    }
                }
            }
        }

        private static void ReadGraph()
        {
            peopleCount = int.Parse(Console.ReadLine().Split(' ')[1]);
            tasksCount = int.Parse(Console.ReadLine().Split(' ')[1]);

            // initialize arrays
            size = peopleCount + tasksCount + 2;
            destinationNode = size - 1;
            graph = new sbyte[size, size];
            flow = new sbyte[size, size];
            path = new int[size];
            nodesMapping = new string[size - 1];

            // read matrix
            for (var i = 0; i < tasksCount; i++)
            {
                var input = Console.ReadLine();
                for (var j = 0; j < input.Length; j++)
                {
                    if (input[j] == 'Y')
                    {
                        var personIndex = j + 1;
                        var taskIndex = i + 1 + peopleCount;
                        graph[personIndex, taskIndex] = 1;
                        graph[taskIndex, personIndex] = 1;
                    }
                }
            }

            // fill start and end nodes
            // and initialize mappings
            for (var i = 1; i < size - 1; i++)
            {
                if (i <= peopleCount)
                {
                    graph[size - 1, i] = 1;
                    graph[i + peopleCount, 0] = 1;

                    nodesMapping[i] = i.ToString();
                }
                else
                {
                    graph[0, i] = 1;
                    graph[i - peopleCount, size - 1] = 1;

                    nodesMapping[i] = ((char)(i - peopleCount + 64)).ToString();
                }
            }
        }

        private static void UpdateFlow(int pathLength)
        {
            var flowIncrementSize = sbyte.MaxValue;
            for (var i = 0; i < pathLength; i++)
            {
                var node = path[i];
                var nextNode = path[i + 1];
                if (graph[node, nextNode] < flowIncrementSize)
                {
                    flowIncrementSize = graph[node, nextNode];
                }
            }

            for (var i = 0; i < pathLength; i++)
            {
                var node = path[i];
                var nextNode = path[i + 1];
                flow[node, nextNode] += flowIncrementSize;
                flow[nextNode, node] -= flowIncrementSize;
                graph[node, nextNode] -= flowIncrementSize;
                graph[nextNode, node] += flowIncrementSize;
            }
        }

        private static void FindAugmentingPath(int node, int level)
        {
            if (pathFound)
            {
                return;
            }

            if (node == destinationNode)
            {
                pathFound = true;
                UpdateFlow(level - 1);
            }
            else
            {
                for (var nextNode = 0; nextNode < size; nextNode++)
                {
                    if (!visited[nextNode] && graph[node, nextNode] > 0)
                    {
                        visited[nextNode] = true;
                        path[level] = nextNode;
                        FindAugmentingPath(nextNode, level + 1);
                        if (pathFound)
                        {
                            return;
                        }
                    }
                }
            }
        }
    }
}
