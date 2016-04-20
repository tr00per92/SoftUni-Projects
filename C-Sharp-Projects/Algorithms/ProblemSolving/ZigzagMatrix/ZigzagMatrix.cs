namespace ZigzagMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ZigzagMatrix
    {
        public static void Main()
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());
            var matrix = ReadMatrix(rows, cols);
            var maxPaths = InitializeMaxPaths(rows, cols, matrix);
            var previousRows = new int[rows, cols];
            FillMaxPaths(rows, cols, matrix, maxPaths, previousRows);

            var lastRow = GetLastRowOfPath(maxPaths, rows, cols);
            var maxPath = RecoverMaxPath(cols, matrix, lastRow, previousRows);
            Console.WriteLine($"{maxPath.Sum()} = {string.Join(" + ", maxPath)}");
        }

        private static void FillMaxPaths(int rows, int cols, int[,] matrix, int[,] maxPaths, int[,] previousRows)
        {
            for (var col = 1; col < cols; col++)
            {
                for (var row = 0; row < rows; row++)
                {
                    var previousMax = 0;

                    if (col % 2 != 0)
                    {
                        for (var i = row + 1; i < rows; i++)
                        {
                            if (maxPaths[i, col - 1] > previousMax)
                            {
                                previousMax = maxPaths[i, col - 1];
                                previousRows[row, col] = i;
                            }
                        }
                    }
                    else
                    {
                        for (var i = 0; i <= row - 1; i++)
                        {
                            if (maxPaths[i, col - 1] > previousMax)
                            {
                                previousMax = maxPaths[i, col - 1];
                                previousRows[row, col] = i;
                            }
                        }
                    }

                    maxPaths[row, col] = previousMax + matrix[row, col];
                }
            }
        }

        private static int[,] InitializeMaxPaths(int rows, int cols, int[,] matrix)
        {
            var maxPaths = new int[rows, cols];
            for (var row = 1; row < rows; row++)
            {
                maxPaths[row, 0] = matrix[row, 0];
            }

            return maxPaths;
        }

        private static int[,] ReadMatrix(int rows, int cols)
        {
            var matrix = new int[rows, cols];
            for (var row = 0; row < rows; row++)
            {
                var input = Console.ReadLine().Split(',').Select(int.Parse).ToList();
                for (var col = 0; col < cols; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            return matrix;
        }

        private static int GetLastRowOfPath(int[,] maxPaths, int rows, int cols)
        {
            var currentRow = -1;
            var globalMax = 0;
            for (var row = 0; row < rows; row++)
            {
                if (maxPaths[row, cols - 1] > globalMax)
                {
                    globalMax = maxPaths[row, cols - 1];
                    currentRow = row;
                }
            }

            return currentRow;
        }

        private static ICollection<int> RecoverMaxPath(int cols, int[,] matrix, int lastRow, int[,] previousRows)
        {
            var path = new List<int>();
            var col = cols - 1;
            while (col >= 0)
            {
                path.Add(matrix[lastRow, col]);
                lastRow = previousRows[lastRow, col];
                col--;
            }

            path.Reverse();
            return path;
        }
    }
}