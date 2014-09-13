using System;

class Smetalnik
{
    static void Main()
    {
        byte width = byte.Parse(Console.ReadLine());
        byte[,] matrix = new byte[8, width];
        for (byte row = 0; row < 8; row++)
        {
            int input = int.Parse(Console.ReadLine());
            string binary = Convert.ToString(input, 2).PadLeft(width, '0');
            for (byte col = 0; col < width; col++)
            {
                matrix[row, col] = (byte)(binary[col] - '0');
            }
        }
        while (true)
        {
            string command = Console.ReadLine();
            if (command == "stop")
            {
                long result = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    string binary = "";
                    for (int j = 0; j < matrix.GetLength(1); j++)
			            {
                            binary += matrix[i, j];
			            }
                    result += Convert.ToInt64(binary, 2);
                }
                int emptyCols = 0;
                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    bool empty = true;
                    for (int j = 0; j < matrix.GetLength(0); j++)
                    {
                        if (matrix[j, i] == 1)
                        {
                            empty = false; break;
                        }
                    }
                    if(empty)
                    {
                        emptyCols++;
                    }
                }
                result *= emptyCols;
                Console.WriteLine(result);
                break;
            }
            else if (command == "reset")
            {
                for (int row = 0; row < 8; row++)
                {
                    MoveTopchenca(matrix, row, matrix.GetLength(1) - 1, "left");
                }
            }
            else 
            {
                int row = int.Parse(Console.ReadLine());                
                int col = int.Parse(Console.ReadLine());
                if (col < 0)
                {
                    col = 0;
                }
                else if (col >= matrix.GetLength(1))
                {
                    col = matrix.GetLength(1) - 1;
                }
                MoveTopchenca(matrix, row, col, command);
            }
        }
    }
    static int HowManyTopchenca(byte[,] matrix, int row, int position, string direction)
    {
        int result = 0;
        if (direction == "left")
        {
            for (int i = 0; i <= position; i++)
            {
                if (matrix[row,i] == 1)
                {
                    result++;
                }
            }
        }
        else if (direction == "right")
        {
            for (int i = position; i < matrix.GetLength(1); i++)
            {
                if (matrix[row, i] == 1)
                {
                    result++;
                }
            }
        }
        return result;
    }
    static void MoveTopchenca(byte[,] matrix, int row, int position, string direction)
    {
        if(direction == "left")
        {
            int topcheta = HowManyTopchenca(matrix, row, position, direction);
            for (int col = 0; col <= position; col++)
            {
                if (topcheta > 0)
                {
                    matrix[row, col] = 1;
                    topcheta--;
                }
                else
                {
                    matrix[row, col] = 0;
                }
            }
        }
        else if (direction == "right")
        {
            int topcheta = HowManyTopchenca(matrix, row, position, direction);
            for (int col = matrix.GetLength(1) - 1; col >= position; col--)
            {
                if (topcheta > 0)
                {
                    matrix[row, col] = 1;
                    topcheta--;
                }
                else
                {
                    matrix[row, col] = 0;
                }
            }
        }
    }
    //static void PrintMatrix(byte[,] matrix)
    //{
    //    for (int row = 0; row < matrix.GetLength(0); row++)
    //    {
    //        for (int col = 0; col < matrix.GetLength(1); col++)
    //        {
    //            Console.Write(matrix[row, col]);
    //        }
    //        Console.WriteLine();
    //    }
    //}
}

