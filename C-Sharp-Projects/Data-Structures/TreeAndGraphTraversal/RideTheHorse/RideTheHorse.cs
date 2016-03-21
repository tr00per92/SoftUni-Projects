namespace RideTheHorse
{
    using System;

    public class RideTheHorse
    {
        private static int[,] matrix;

        public static void Main()
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());
            var startRow = int.Parse(Console.ReadLine());
            var startCol = int.Parse(Console.ReadLine());

            matrix = new int[rows, cols];
            RideFromPosition(startRow, startCol);
            PrintResult();
        }

        private static void RideFromPosition(int row, int col, int steps = 1)
        {
            if (!IsInside(row, col) || (matrix[row, col] != 0 && matrix[row, col] <= steps))
            {
                return;
            }

            matrix[row, col] = steps;

            RideFromPosition(row - 2, col + 1, steps + 1);
            RideFromPosition(row - 2, col - 1, steps + 1);
            RideFromPosition(row - 1, col + 2, steps + 1);
            RideFromPosition(row - 1, col - 2, steps + 1);
            RideFromPosition(row + 2, col + 1, steps + 1);
            RideFromPosition(row + 2, col - 1, steps + 1);
            RideFromPosition(row + 1, col + 2, steps + 1);
            RideFromPosition(row + 1, col - 2, steps + 1);
        }

        private static bool IsInside(int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }

        private static void PrintResult()
        {
            Console.WriteLine();
            var col = matrix.GetLength(1) / 2;
            for (var row = 0; row < matrix.GetLength(0); row++)
            {
                Console.WriteLine(matrix[row, col]);
            }
        }
    }
}
