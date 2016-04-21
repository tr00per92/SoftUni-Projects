namespace AreasInMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static int rows;
        private static int cols;
        private static char[,] matrix;
        private static bool[,] visited;

        public static void Main()
        {
            ReadMatrix();
            var areas = new SortedDictionary<char, int>();
            var startCell = FindUnvisitedCell();
            while (startCell != null)
            {
                var currentChar = matrix[startCell.Item1, startCell.Item2];
                if (!areas.ContainsKey(currentChar))
                {
                    areas[currentChar] = 0;
                }

                areas[currentChar]++;
                TraverseArea(startCell.Item1, startCell.Item2, currentChar);
                startCell = FindUnvisitedCell();
            }

            Console.WriteLine("Areas: " + areas.Sum(a => a.Value));
            foreach (var area in areas)
            {
                Console.WriteLine("Letter '{0}' -> {1}", area.Key, area.Value);
            }
        }

        private static void ReadMatrix()
        {
            rows = int.Parse(Console.ReadLine().Split(' ').Last());
            for (var i = 0; i < rows; i++)
            {
                var row = Console.ReadLine();
                if (i == 0)
                {
                    cols = row.Length;
                    matrix = new char[rows, cols];
                    visited = new bool[rows, cols];
                }

                for (var j = 0; j < cols; j++)
                {
                    matrix[i, j] = row[j];
                }
            }
        }

        private static void TraverseArea(int row, int col, char currentChar)
        {
            if (!IsInRange(row, col) || visited[row, col] || matrix[row, col] != currentChar)
            {
                return;
            }

            visited[row, col] = true;
            TraverseArea(row + 1, col, currentChar);
            TraverseArea(row - 1, col, currentChar);
            TraverseArea(row, col + 1, currentChar);
            TraverseArea(row, col - 1, currentChar);
        }

        private static bool IsInRange(int row, int col)
        {
            return row >= 0 && col >= 0 && row < rows && col < cols;
        }

        private static Tuple<int, int> FindUnvisitedCell()
        {
            for (var row = 0; row < rows; row++)
            {
                for (var col = 0; col < cols; col++)
                {
                    if (!visited[row, col])
                    {
                        return Tuple.Create(row, col);
                    }
                } 
            }

            return null;
        }
    }
}
