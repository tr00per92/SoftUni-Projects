namespace RoundDance
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RoundDance
    {
        private static readonly IDictionary<int, IList<int>> Friends = new Dictionary<int, IList<int>>();
        private static readonly IDictionary<int, bool> VisitedFriends = new Dictionary<int, bool>();
        private static int maxCount;

        public static void Main()
        {
            var numberOfCouples = int.Parse(Console.ReadLine());
            var leader = int.Parse(Console.ReadLine());
            for (var i = 0; i < numberOfCouples; i++)
            {
                var currentCouple = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
                if (!Friends.ContainsKey(currentCouple[0]))
                {
                    Friends.Add(currentCouple[0], new List<int>());
                    VisitedFriends.Add(currentCouple[0], false);
                }

                if (!Friends.ContainsKey(currentCouple[1]))
                {
                    Friends.Add(currentCouple[1], new List<int>());
                    VisitedFriends.Add(currentCouple[1], false);
                }

                Friends[currentCouple[0]].Add(currentCouple[1]);
                Friends[currentCouple[1]].Add(currentCouple[0]);
            }

            Console.WriteLine();
            DFS(leader);
            Console.WriteLine("Longest dance count: " + maxCount);
        }

        private static void DFS(int node, int count = 1)
        {
            if (!VisitedFriends[node])
            {
                VisitedFriends[node] = true;
                foreach (var friend in Friends[node])
                {
                    DFS(friend, count + 1);
                }

                maxCount = Math.Max(maxCount, count);
            }
        }
    }
}
