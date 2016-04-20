namespace LineInverter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LineInverter
    {
        private static int size;
        private static bool[,] matrix;

        public static void Main()
        {
            ReadMatrix();
            for (var i = 0; i < 2 * size + 1; i++)
            {
                var whiteCellsInRow = Enumerable.Repeat(0, size).ToList();
                var whiteCellsInColumn = Enumerable.Repeat(0, size).ToList();
                FillWhiteCellsCount(whiteCellsInRow, whiteCellsInColumn);

                var maxRowWhiteCells = whiteCellsInRow.Max();
                var maxColWhiteCells = whiteCellsInColumn.Max();
                if (maxColWhiteCells == 0 && maxRowWhiteCells == 0)
                {
                    Console.WriteLine(i);
                    return;
                }

                if (maxRowWhiteCells >= maxColWhiteCells)
                {
                    var rowIndex = whiteCellsInRow.IndexOf(maxRowWhiteCells);
                    InvertRow(rowIndex);
                }
                else
                {
                    var colIndex = whiteCellsInColumn.IndexOf(maxColWhiteCells);
                    InvertColumn(colIndex);
                }
            }
            
            Console.WriteLine(-1);
        }

        private static void FillWhiteCellsCount(IList<int> whiteCellsInRow, IList<int> whiteCellsInColumn)
        {
            for (var row = 0; row < size; row++)
            {
                for (var col = 0; col < size; col++)
                {
                    if (matrix[row, col])
                    {
                        whiteCellsInRow[row]++;
                        whiteCellsInColumn[col]++;
                    }
                }
            }
        }

        private static void ReadMatrix()
        {
            size = int.Parse(Console.ReadLine());
            matrix = new bool[size, size];
            for (var row = 0; row < size; row++)
            {
                var line = Console.ReadLine();
                for (var col = 0; col < size; col++)
                {
                    matrix[row, col] = line[col] == 'W';
                }
            }
        }

        private static void InvertRow(int row)
        {
            for (var col = 0; col < size; col++)
            {
                matrix[row, col] = !matrix[row, col];
            }
        }

        private static void InvertColumn(int col)
        {
            for (var row = 0; row < size; row++)
            {
                matrix[row, col] = !matrix[row, col];
            }
        }
    }
}
