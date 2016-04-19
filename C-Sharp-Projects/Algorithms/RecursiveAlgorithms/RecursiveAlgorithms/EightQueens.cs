namespace RecursiveAlgorithms
{
    using System;
    using System.Collections.Generic;

    public static class EightQueens
    {
        private const int Size = 8;
        private static int solutionsCount;
        private static readonly bool[,] chessboard = new bool[Size, Size];
        private static readonly HashSet<int> attackedCols = new HashSet<int>();
        private static readonly HashSet<int> attackedLeftDiagonals = new HashSet<int>();
        private static readonly HashSet<int> attackedRightDiagonals = new HashSet<int>(); 

        public static void Solve()
        {
            PutQueens(0);
            Console.WriteLine("Solutions count: " + solutionsCount);
        }

        private static void PutQueens(int row)
        {
            if (row == Size)
            {
                solutionsCount++;
                PrintSolution();
            }
            else
            {
                for (var col = 0; col < Size; col++)
                {
                    if (CanPlaceQueen(row, col))
                    {
                        MarkAttackedPositions(row, col);
                        PutQueens(row + 1);
                        UnmarkAttackedPositions(row, col);
                    }
                }
            }
        }

        private static bool CanPlaceQueen(int row, int col)
        {
            var positionIsAttacked = attackedCols.Contains(col) ||
                attackedLeftDiagonals.Contains(col - row) ||
                attackedRightDiagonals.Contains(col + row);

            return !positionIsAttacked;
        }

        private static void MarkAttackedPositions(int row, int col)
        {
            attackedCols.Add(col);
            attackedLeftDiagonals.Add(col - row);
            attackedRightDiagonals.Add(col + row);
            chessboard[row, col] = true;
        }

        private static void UnmarkAttackedPositions(int row, int col)
        {
            attackedCols.Remove(col);
            attackedLeftDiagonals.Remove(col - row);
            attackedRightDiagonals.Remove(col + row);
            chessboard[row, col] = false;
        }

        private static void PrintSolution()
        {
            for (var row = 0; row < Size; row++)
            {
                for (var col = 0; col < Size; col++)
                {
                    Console.Write(chessboard[row, col] ? '*' : '-');
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
