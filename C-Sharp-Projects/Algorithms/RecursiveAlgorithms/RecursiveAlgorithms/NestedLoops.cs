namespace RecursiveAlgorithms
{
    using System;

    public static class NestedLoops
    {
        private static int loopsCount;
        private static int[] loops;

        public static void Simulate(int count)
        {
            loopsCount = count;
            loops = new int[loopsCount];
            NestLoops(0);
        }

        private static void NestLoops(int currentLoop)
        {
            if (currentLoop == loopsCount)
            {
                PrintLoops();
            }
            else
            {
                for (var i = 1; i <= loopsCount; i++)
                {
                    loops[currentLoop] = i;
                    NestLoops(currentLoop + 1);
                }
            }
        }

        private static void PrintLoops()
        {
            for (var i = 0; i < loopsCount; i++)
            {
                Console.Write("{0} ", loops[i]);
            }

            Console.WriteLine();
        }
    }
}
