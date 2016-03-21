namespace ExitLabyrinth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ExitLabyrinth
    {
        private static char[,] labyrinth;

        public static void Main()
        {
            ReadLabyrinth();

            var path = FindShortestPath();
            if (path == null)
            {
                Console.WriteLine("No exit!");
            }
            else if (path == string.Empty)
            {
                Console.WriteLine("Start is at the exit.");
            }
            else
            {
                Console.WriteLine("Shortest exit: " + path);
            }
        }

        private static void ReadLabyrinth()
        {
            var width = int.Parse(Console.ReadLine() ?? "0");
            var height = int.Parse(Console.ReadLine() ?? "0");
            labyrinth = new char[height, width];
            for (var row = 0; row < height; row++)
            {
                var input = Console.ReadLine();
                for (var col = 0; col < width; col++)
                {
                    labyrinth[row, col] = input[col];
                }
            }
        }

        private static string FindShortestPath()
        {
            var queue = new Queue<Cell>();
            var startPosition = FindStartPosition();
            if (startPosition != null)
            {
                queue.Enqueue(startPosition);
                while (queue.Any())
                {
                    var currentCell = queue.Dequeue();
                    if (IsExit(currentCell))
                    {
                        return TraceBackPath(currentCell);
                    }

                    TryDirection(queue, currentCell, 'U', -1, 0);
                    TryDirection(queue, currentCell, 'R', 0, 1);
                    TryDirection(queue, currentCell, 'D', 1, 0);
                    TryDirection(queue, currentCell, 'L', 0, -1);
                }
            }

            return null;
        }

        private static Cell FindStartPosition()
        {
            for (var row = 0; row < labyrinth.GetLength(0); row++)
            {
                for (var col = 0; col < labyrinth.GetLength(1); col++)
                {
                    if (labyrinth[row, col] == 's')
                    {
                        return new Cell { X = row, Y = col };
                    }
                }
            }

            return null;
        }

        private static bool IsExit(Cell cell)
        {
            return cell.X == 0 || cell.Y == 0 || cell.X == labyrinth.GetLength(0) - 1 || cell.Y == labyrinth.GetLength(1) - 1;
        }

        private static void TryDirection(Queue<Cell> queue, Cell currentCell, char direction, int dX, int dY)
        {
            var newX = currentCell.X + dX;
            var newY = currentCell.Y + dY;
            if (newX >= 0 && newX < labyrinth.GetLength(0) && newY >= 0 && newY < labyrinth.GetLength(1) && labyrinth[newX, newY] == '-')
            {
                var nextCell = new Cell
                {
                    X = newX,
                    Y = newY,
                    Direction = direction,
                    PreviousCell = currentCell
                };

                queue.Enqueue(nextCell);
                labyrinth[newX, newY] = 's';
            }
        }

        private static string TraceBackPath(Cell cell)
        {
            var cells = new StringBuilder();
            while (cell.PreviousCell != null)
            {
                cells.Append(cell.Direction);
                cell = cell.PreviousCell;
            }

            var path = cells.ToString().ToCharArray();
            Array.Reverse(path);

            return new string(path);
        }
    }
}