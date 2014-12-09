using System;

class Carpets
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        char[,] matrix = new char[n, n];

        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                matrix[row, col] = '.';
            }
        }

        for (int row = 0; row < n / 2; row++)
        {
            int first = n / 2 - 1 - row;
            int last = n / 2 - 1;
            bool space = false;
            for (int col = first; col <= last; col++)
            {
                if (!space)
                {
                    matrix[row, col] = '/';
                    matrix[row, n - 1 - col] = '\\';
                    matrix[n - 1 - row, col] = '\\';
                    matrix[n - 1 - row, n - 1 - col] = '/';
                }
                else
                {
                    matrix[row, col] = ' ';
                    matrix[row, n - 1 - col] = ' ';
                    matrix[n - 1 - row, col] = ' ';
                    matrix[n - 1 - row, n - 1 - col] = ' ';
                }
                space = !space;
            }
        }

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(matrix[row, col]);
            }
            Console.WriteLine();
        }
    }
}