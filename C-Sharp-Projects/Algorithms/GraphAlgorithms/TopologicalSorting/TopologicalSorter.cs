namespace TopologicalSorting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TopologicalSorter
    {
        private readonly IDictionary<string, List<string>> graph;

        public TopologicalSorter(IDictionary<string, List<string>> graph)
        {
            this.graph = graph;
        }

        public ICollection<string> SortTopological()
        {
            //return this.SortBySourceRemoval();
            return this.SortByDfs();
        }

        private ICollection<string> SortBySourceRemoval()
        {
            var predecessorsCount = this.FindPredecessorsCount();
            var removedNodes = new List<string>();
            var nodeToRemove = this.graph.Keys.FirstOrDefault(x => predecessorsCount[x] == 0);
            while (nodeToRemove != null)
            {
                foreach (var child in this.graph[nodeToRemove])
                {
                    predecessorsCount[child]--;
                }

                this.graph.Remove(nodeToRemove);
                removedNodes.Add(nodeToRemove);
                nodeToRemove = this.graph.Keys.FirstOrDefault(x => predecessorsCount[x] == 0);
            }

            if (this.graph.Any())
            {
                throw new InvalidOperationException();
            }

            return removedNodes;
        }

        private IDictionary<string, int> FindPredecessorsCount()
        {
            var result = new Dictionary<string, int>();
            foreach (var node in this.graph)
            {
                if (!result.ContainsKey(node.Key))
                {
                    result[node.Key] = 0;
                }

                foreach (var child in node.Value)
                {
                    if (!result.ContainsKey(child))
                    {
                        result[child] = 0;
                    }

                    result[child]++;
                }
            }

            return result;
        }

        private ICollection<string> SortByDfs()
        {
            var sortedNodes = new LinkedList<string>();
            var visitedNodes = new HashSet<string>();
            var cycleNodes = new HashSet<string>();
            foreach (var node in this.graph.Keys)
            {
                this.Dfs(node, sortedNodes, visitedNodes, cycleNodes);
            }

            return sortedNodes;
        }

        private void Dfs(string node, LinkedList<string> sortedNodes, ISet<string> visitedNodes, ISet<string> cycleNodes)
        {
            if (cycleNodes.Contains(node))
            {
                throw new InvalidOperationException();
            }

            if (!visitedNodes.Contains(node))
            {
                visitedNodes.Add(node);
                cycleNodes.Add(node);

                if (this.graph.ContainsKey(node))
                {
                    foreach (var child in this.graph[node])
                    {
                        this.Dfs(child, sortedNodes, visitedNodes, cycleNodes);
                    }
                }

                cycleNodes.Remove(node);
                sortedNodes.AddFirst(node);
            }
        }
    }
}