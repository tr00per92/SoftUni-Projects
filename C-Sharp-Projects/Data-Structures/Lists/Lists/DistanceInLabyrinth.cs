namespace LinearDataStructurestLists
{
    using System;

    public class DistanceInLabyrinth
    {
        private static readonly string[,] Labyrinth =
        {
            {"0", "0", "0", "X", "0", "X"},
            {"0", "X", "0", "X", "0", "X"},
            {"0", "*", "X", "0", "X", "0"},
            {"0", "X", "0", "0", "0", "0"},
            {"0", "0", "0", "X", "X", "0"},
            {"0", "0", "0", "X", "0", "X"}
        };

        public static void Calculate()
        {
            CheckPosition(GetStartPosition(), 0);
            MarkUnreachedPositions();
            PrintLabytinth();
        }

        private static void CheckPosition(Tuple<int, int> position, int stepsCount)
        {
            var x = position.Item1;
            var y = position.Item2;
            if (ShouldGoToPosition(Tuple.Create(x, y), stepsCount))
            {
                Labyrinth[x, y] = stepsCount.ToString();
            }

            stepsCount++;

            if (ShouldGoToPosition(Tuple.Create(x + 1, y), stepsCount))
            {
                CheckPosition(Tuple.Create(x + 1, y), stepsCount);
            }

            if (ShouldGoToPosition(Tuple.Create(x - 1, y), stepsCount))
            {
                CheckPosition(Tuple.Create(x - 1, y), stepsCount);
            }

            if (ShouldGoToPosition(Tuple.Create(x, y + 1), stepsCount))
            {
                CheckPosition(Tuple.Create(x, y + 1), stepsCount);
            }

            if (ShouldGoToPosition(Tuple.Create(x, y - 1), stepsCount))
            {
                CheckPosition(Tuple.Create(x, y - 1), stepsCount);
            }
        }


        private static bool IsInsideLabyrinth(Tuple<int, int> position)
        {
            var isInside = position.Item1 >= 0 &&
                position.Item1 < Labyrinth.GetLength(0) && 
                position.Item2 >= 0 &&
                position.Item2 < Labyrinth.GetLength(1);

            return isInside;
        }

        private static bool ShouldGoToPosition(Tuple<int, int> position, int stepsCount)
        {
            var shouldGo = IsInsideLabyrinth(position) &&
                Labyrinth[position.Item1, position.Item2] != "*" && 
                Labyrinth[position.Item1, position.Item2] != "X" &&
                (Labyrinth[position.Item1, position.Item2] == "0" || 
                int.Parse(Labyrinth[position.Item1, position.Item2]) > stepsCount);

            return shouldGo;
        }

        private static Tuple<int, int> GetStartPosition()
        {
            for (var row = 0; row < Labyrinth.GetLength(0); row++)
            {
                for (var col = 0; col < Labyrinth.GetLength(1); col++)
                {
                    if (Labyrinth[row, col] == "*")
                    {
                        return Tuple.Create(row, col);
                    }
                }
            }

            throw new ArgumentException("Invalid labyrinth.");
        }

        private static void MarkUnreachedPositions()
        {
            for (var row = 0; row < Labyrinth.GetLongLength(0); row++)
            {
                for (var col = 0; col < Labyrinth.GetLongLength(1); col++)
                {
                    if (Labyrinth[row, col] == "0")
                    {
                        Labyrinth[row, col] = "U";
                    }
                }
            }
        }

        private static void PrintLabytinth()
        {
            for (var row = 0; row < Labyrinth.GetLength(0); row++)
            {
                for (var col = 0; col < Labyrinth.GetLength(1); col++)
                {
                    Console.Write("{0, -5}", Labyrinth[row, col]);
                }

                Console.WriteLine(Environment.NewLine);
            }
        }
    }
}
