namespace RecursiveAlgorithms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Matrix
    {
        private static IList<char> path;
        private static char[,] matrix;
        private static int counter;

        public static void FindPathsToExit(char[,] inputMatrix)
        {
            matrix = inputMatrix;
            counter = 0;
            path = new List<char>();

            var start = FindStart();
            matrix[start.Item1, start.Item2] = ' ';
            FindPathToExit(start.Item1, start.Item2, 'S');

            Console.WriteLine("Total paths found: " + counter);
        }

        public static void FindTotalAreas(char[,] inputMatrix)
        {
            matrix = inputMatrix;
            var areas = new List<MatrixArea>();
            var start = FindEmptyCell();
            while (start != null)
            {
                counter = 0;
                FindMatrixArea(start.Item1, start.Item2);
                areas.Add(new MatrixArea { X = start.Item1, Y = start.Item2, Size = counter });
                start = FindEmptyCell();
            }

            Console.WriteLine("Total areas found: " + areas.Count);
            var count = 1;
            foreach (var area in areas.OrderByDescending(area => area.Size))
            {
                Console.WriteLine("Area #{0} at ({1}, {2}), size: {3}", count++, area.X, area.Y, area.Size);
            }
        }

        private static void FindMatrixArea(int row, int col)
        {
            if (!IsInRange(row, col))
            {
                return;
            }

            if (matrix[row, col] == ' ')
            {
                matrix[row, col] = 's';
                counter++;

                // Recursively explore all possible directions
                FindMatrixArea(row, col - 1);
                FindMatrixArea(row - 1, col);
                FindMatrixArea(row, col + 1);
                FindMatrixArea(row + 1, col);
            }
        }

        private static void FindPathToExit(int row, int col, char direction)
        {
            if (!IsInRange(row, col))
            {
                return;
            }

            path.Add(direction);

            if (matrix[row, col] == 'e')
            {
                counter++;
                Console.WriteLine(string.Join(" ", path).Remove(0, 2));
            }

            if (matrix[row, col] == ' ')
            {
                // Temporary mark the current cell as visited
                matrix[row, col] = 's';

                // Recursively explore all possible directions
                FindPathToExit(row, col - 1, 'L');
                FindPathToExit(row - 1, col, 'U');
                FindPathToExit(row, col + 1, 'R');
                FindPathToExit(row + 1, col, 'D');

                // Mark back the current cell as free
                matrix[row, col] = ' ';
            }

            // Remove the last direction from the path
            path.RemoveAt(path.Count - 1);
        }

        private static bool IsInRange(int row, int col)
        {
            var rowInRange = row >= 0 && row < matrix.GetLength(0);
            var colInRange = col >= 0 && col < matrix.GetLength(1);
            return rowInRange && colInRange;
        }

        private static Tuple<int, int> FindStart()
        {
            for (var row = 0; row < matrix.GetLength(0); row++)
            {
                for (var col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 's')
                    {
                        return Tuple.Create(row, col);
                    }
                }
            }

            throw new ArgumentException("There is no start field.");
        }

        private static Tuple<int, int> FindEmptyCell()
        {
            for (var row = 0; row < matrix.GetLength(0); row++)
            {
                for (var col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == ' ')
                    {
                        return Tuple.Create(row, col);
                    }
                }
            }

            return null;
        }

        private struct MatrixArea
        {
            public int X { get; set; }

            public int Y { get; set; }

            public int Size { get; set; }
        }
    }
}
