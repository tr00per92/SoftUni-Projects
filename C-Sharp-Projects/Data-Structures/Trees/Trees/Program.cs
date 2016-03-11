namespace Trees
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            // PlayWithTrees();
            // var folder = SaveDirectory("C:\\Windows");
            // Console.WriteLine(folder.TotalSize);

            Console.ReadKey();
        }

        private static Folder SaveDirectory(string path)
        {
            try
            {
                var folder = new Folder(Path.GetFileName(path));
                foreach (var file in Directory.GetFiles(path))
                {
                    var fileInfo = new FileInfo(file);
                    folder.Files.Add(new File(fileInfo.Name, fileInfo.Length));
                }

                foreach (var dir in Directory.GetDirectories(path))
                {
                    var childFolder = SaveDirectory(dir);
                    if (childFolder != null)
                    {
                        folder.ChildFolders.Add(childFolder);
                    }
                }

                return folder;
            }
            catch (UnauthorizedAccessException)
            {
            }

            return null;
        }

        private static void PlayWithTrees()
        {
            var tree = ReadTree();
            var root = tree.First(x => x.Parent == null).Value;
            Console.WriteLine("Root node: {0}", root);

            var leafs = tree.Where(x => !x.Children.Any()).OrderBy(x => x.Value).Select(x => x.Value);
            Console.WriteLine("Leaf nodes: {0}", string.Join(", ", leafs));

            var middleNodes = tree.Where(x => x.Parent != null && x.Children.Any()).OrderBy(x => x.Value).Select(x => x.Value);
            Console.WriteLine("Middle nodes: {0}", string.Join(", ", middleNodes));

            var longestPath = FindLongestPath(tree);
            Console.WriteLine("Longest path: {0} (length = {1})", string.Join(" -> ", longestPath), longestPath.Count);

            Console.WriteLine();
            var sum = 27;
            Console.WriteLine("Paths of sum {0}: ", sum);
            foreach (var path in FindPathsWithsSum(sum, tree))
            {
                Console.WriteLine(string.Join(" -> ", path));
            }

            Console.WriteLine();
            sum = 43;
            Console.WriteLine("Subtrees of sum {0}: ", sum);
            foreach (var subTree in FindSubtreesOfSum(sum, tree))
            {
                Console.WriteLine(string.Join(" + ", subTree));
            }
        }

        private static IEnumerable<IEnumerable<int>> FindSubtreesOfSum(int sum, IEnumerable<Node> tree)
        {
            var result = new List<IEnumerable<int>>();
            var stack = new Stack<Node>();
            foreach (var node in tree)
            {
                stack.Push(node);
                var currentSubtree = new List<int>();
                var currentSum = 0;
                while (stack.Any())
                {
                    var currentNode = stack.Pop();
                    currentSum += currentNode.Value;
                    currentSubtree.Add(currentNode.Value);
                    foreach (var child in currentNode.Children)
                    {
                        stack.Push(child);
                    }
                }

                if (currentSum == sum)
                {
                    result.Add(new List<int>(currentSubtree));
                }
            }

            return result;
        }

        private static IEnumerable<IEnumerable<int>> FindPathsWithsSum(int sum, IEnumerable<Node> tree)
        {
            var result = new List<IEnumerable<int>>();
            var stack = new Stack<Node>();
            foreach (var node in tree)
            {
                stack.Push(node);
                var currentNodes = new List<int>();
                var currentSum = 0;
                while (stack.Any())
                {
                    var currentNode = stack.Pop();
                    if (!stack.Any() && currentNode.Children.Any())
                    {
                        if (currentNode != node)
                        {
                            currentSum = node.Value + currentNode.Value;
                            currentNodes.RemoveAt(currentNodes.Count - 1);
                        }
                        else
                        {
                            currentSum = node.Value;
                        }
                    }
                    else
                    {
                        currentSum = currentNode.Value + currentSum;
                    }

                    currentNodes.Add(currentNode.Value);
                    if (currentNode.Children.Any())
                    {
                        foreach (var childNode in currentNode.Children)
                        {
                            stack.Push(childNode);
                        }
                    }
                    else
                    {
                        if (currentSum == sum)
                        {
                            result.Add(new List<int>(currentNodes));
                        }

                        currentSum -= currentNode.Value;
                        currentNodes.RemoveAt(currentNodes.Count - 1);
                    }
                }
            }

            return result;
        }

        private static ICollection<int> FindLongestPath(IEnumerable<Node> tree)
        {
            var longestPath = new Stack<int>();
            foreach (var leaf in tree.Where(x => !x.Children.Any()))
            {
                var currentPath = new Stack<int>(new[] { leaf.Value });
                var parent = leaf.Parent;
                while (parent != null)
                {
                    currentPath.Push(parent.Value);
                    parent = parent.Parent;
                }

                if (currentPath.Count > longestPath.Count)
                {
                    longestPath = currentPath;
                }
            }

            return longestPath.ToList();
        } 

        private static ICollection<Node> ReadTree()
        {
            var tree = new HashSet<Node>();
            var nodesCount = int.Parse(Console.ReadLine() ?? "1") - 1;
            for (var i = 0; i < nodesCount; i++)
            {
                var currentCouple = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
                var firstNode = tree.FirstOrDefault(x => x.Value == currentCouple[0]);
                if (firstNode == null)
                {
                    firstNode = new Node(currentCouple[0]);
                    tree.Add(firstNode);
                }

                if (firstNode.Children.All(x => x.Value != currentCouple[1]))
                {
                    var child = new Node(currentCouple[1], firstNode);
                    firstNode.Children.Add(child);
                    tree.Add(child);
                }
            }

            return tree;
        }
    }
}