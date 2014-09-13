using System;

class MatrixOfPalindromes
{
    static void Main()
    {
        Console.Write("Enter the number of rows: ");
        int rows = int.Parse(Console.ReadLine());
        Console.Write("Enter the number of columns: ");
        int cols = int.Parse(Console.ReadLine());
        string[,] matrix = new string[rows, cols];
        for (int row = 0; row < rows; row++)
        {
            char letter = (char)('a' + row);
            for (int col = 0; col < cols; col++)
            {
                matrix[row, col] = letter.ToString() + ((char)(letter + col)).ToString() + letter.ToString();
                Console.Write(matrix[row, col] + " ");
            }
            Console.WriteLine();
        }
    }
}

