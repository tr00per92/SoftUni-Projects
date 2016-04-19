namespace RecursiveAlgorithms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class TowerOfHanoi
    {
        private static int stepsCount;

        public static void Solve(int disksCount)
        {
            var source = new Stack<int>(Enumerable.Range(1, disksCount).Reverse());
            var destination = new Stack<int>();
            var spare = new Stack<int>();
            MoveDisks(disksCount, source, destination, spare);

            Console.WriteLine("Expected steps count: " + (Math.Pow(2, disksCount) - 1));
            Console.WriteLine("Steps count: " + stepsCount);
        }

        private static void MoveDisks(int bottomDisk, Stack<int> source, Stack<int> destination, Stack<int> spare)
        {
            stepsCount++;
            if (bottomDisk == 1)
            {
                destination.Push(source.Pop());
            }
            else
            {
                MoveDisks(bottomDisk - 1, source, spare, destination);
                destination.Push(source.Pop());
                MoveDisks(bottomDisk - 1, spare, destination, source);
            }
        }
    }
}
