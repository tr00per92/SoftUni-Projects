namespace RecursiveAlgorithms
{
    using System;

    public static class Combinations
    {
        private static int selectCount;
        private static int fromCount;
        private static int[] loops;

        public static void GenerateWithRepetitions(int elementsCount, int elementsToSelect)
        {
            Initialize(elementsCount, elementsToSelect);
            Generate(0, 1, true);
        }

        public static void GenerateWithoutRepetitions(int elementsCount, int elementsToSelect)
        {
            Initialize(elementsCount, elementsToSelect);
            Generate(0, 1, false);
        }

        private static void Initialize(int elementsCount, int elementsToSelect)
        {
            if (elementsCount < elementsToSelect)
            {
                throw new ArgumentException("The elements to select cannot be more than the total elements.");
            }

            fromCount = elementsCount;
            selectCount = elementsToSelect;
            loops = new int[selectCount];
        }

        private static void Generate(int currentLoop, int startFrom, bool repetitions)
        {
            if (currentLoop == selectCount)
            {
                Print();
            }
            else
            {
                for (var i = startFrom; i <= fromCount; i++)
                {
                    loops[currentLoop] = i;
                    Generate(currentLoop + 1, repetitions ? i : i + 1, repetitions);
                }
            }
        }

        private static void Print()
        {
            for (var i = 0; i < selectCount; i++)
            {
                Console.Write("{0} ", loops[i]);
            }

            Console.WriteLine();
        }
    }
}
