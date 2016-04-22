namespace KnightTour
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static int boardSize;
        private static int[,] board;

        public static void Main()
        {
            boardSize = int.Parse(Console.ReadLine());
            board = new int[boardSize, boardSize];
            var totalSteps = boardSize * boardSize;

            var currentCell = new Cell(0, 0);
            var stepsCount = 0;
            while (stepsCount < totalSteps)
            {
                stepsCount++;
                board[currentCell.Row, currentCell.Col] = stepsCount;
                currentCell = FindMinValidMovesCell(currentCell);
            }

            PrintBoard();
        }

        private static Cell FindMinValidMovesCell(Cell cell)
        {
            var minMoves = int.MaxValue;
            var minCell = new Cell();
            foreach (var validCell in FindValidHorseMoves(cell))
            {
                var movesCount = FindValidHorseMoves(validCell).Count();
                if (movesCount < minMoves)
                {
                    minMoves = movesCount;
                    minCell = validCell;
                }
            }

            return minCell;
        }

        private static IEnumerable<Cell> FindValidHorseMoves(Cell cell)
        {
            return FindHorseMoves(cell).Where(c => IsInRange(c) && board[c.Row, c.Col] == 0);
        } 

        private static IEnumerable<Cell> FindHorseMoves(Cell cell)
        {
            yield return new Cell(cell.Row + 2, cell.Col + 1);
            yield return new Cell(cell.Row + 2, cell.Col - 1);
            yield return new Cell(cell.Row + 1, cell.Col + 2);
            yield return new Cell(cell.Row + 1, cell.Col - 2);
            yield return new Cell(cell.Row - 2, cell.Col - 1);
            yield return new Cell(cell.Row - 2, cell.Col + 1);
            yield return new Cell(cell.Row - 1, cell.Col - 2);
            yield return new Cell(cell.Row - 1, cell.Col + 2);
        }

        private static bool IsInRange(Cell cell)
        {
            return cell.Row >= 0 && cell.Col >= 0 && cell.Row < boardSize && cell.Col < boardSize;
        }

        private static void PrintBoard()
        {
            for (var row = 0; row < boardSize; row++)
            {
                for (var col = 0; col < boardSize; col++)
                {
                    Console.Write($"{board[row, col], 4}");
                }

                Console.WriteLine();
            }
        }
    }
}
