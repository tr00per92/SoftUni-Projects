namespace Bridges
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Bridges
    {
        private static int[,] maxBridgesCount;
        private static IList<int> northStops;
        private static IList<int> southStops;

        public static void Main()
        {
            northStops = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            southStops = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            maxBridgesCount = new int[northStops.Count, southStops.Count];
            for (var i = 0; i < northStops.Count; i++)
            {
                for (var j = 0; j < southStops.Count; j++)
                {
                    maxBridgesCount[i, j] = -1;
                }
            }

            var result = CalcMaxBridges(northStops.Count - 1, southStops.Count - 1);
            Console.WriteLine(result);
        }

        private static int CalcMaxBridges(int northStop, int southStop)
        {
            if (northStop < 0 || southStop < 0)
            {
                return 0;
            }

            if (maxBridgesCount[northStop, southStop] != -1)
            {
                return maxBridgesCount[northStop, southStop];
            }

            var northLeft = CalcMaxBridges(northStop - 1, southStop);
            var southLeft = CalcMaxBridges(northStop, southStop - 1);
            maxBridgesCount[northStop, southStop] = Math.Max(northLeft, southLeft);
            if (northStops[northStop] == southStops[southStop])
            {
                maxBridgesCount[northStop, southStop]++;
            }

            return maxBridgesCount[northStop, southStop];
        }
    }
}
