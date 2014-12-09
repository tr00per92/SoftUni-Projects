using System;

class Warhead
{
    static void Main()
    {
        byte[,] matrix = new byte[18, 18];
        for (int i = 1; i < 17; i++)
        {
            string row = Console.ReadLine();
            for (int j = 1; j < 17; j++)
            {
                matrix[i, j] = (byte)(row[j - 1] - '0');
            }
        }
        while (true)
        {
            string command = Console.ReadLine();
            if (command == "cut")
            {
                string color = Console.ReadLine();
                if (color == "red")
                {
                    if (NumberOfCapacitors(matrix, "left") == 0)
                    {
                        Console.WriteLine(NumberOfCapacitors(matrix, "right"));
                        Console.WriteLine("disarmed");
                    }
                    else
                    {
                        Console.WriteLine(NumberOfCapacitors(matrix, "left"));
                        Console.WriteLine("BOOM");
                    }
                }
                else if (color == "blue")
                {
                    if (NumberOfCapacitors(matrix, "right") == 0)
                    {
                        Console.WriteLine(NumberOfCapacitors(matrix, "left"));
                        Console.WriteLine("disarmed");
                    }
                    else
                    {
                        Console.WriteLine(NumberOfCapacitors(matrix, "right"));
                        Console.WriteLine("BOOM");
                    }
                }
                break;
            }
            byte row = byte.Parse(Console.ReadLine()); row++;
            byte col = byte.Parse(Console.ReadLine()); col++;
            if (command == "hover")
            {
                if (matrix[row, col] == 1)
                {
                    Console.WriteLine("*");
                }
                else if (matrix[row, col] == 0)
                {
                    Console.WriteLine("-");
                }
            }
            else if (command == "operate")
            {
                if (matrix[row, col] == 1)
                {
                    Console.WriteLine("missed");
                    int total = NumberOfCapacitors(matrix, "right") + NumberOfCapacitors(matrix, "left");
                    Console.WriteLine(total);
                    Console.WriteLine("BOOM");
                    break;
                }
                else if (SurroundedByOnes(row, col, matrix))
                {
                    matrix = RemoveCapacitor(row, col, matrix);
                }
            }
        }
    }

    static bool SurroundedByOnes (byte row, byte col, byte[,] matrix)
    {
        if (matrix[row - 1, col - 1] != 1)
        {
            return false;
        }
        if(matrix[row - 1, col] != 1)
        {
            return false;
        }
        if(matrix[row - 1, col + 1] != 1)
        {
            return false;
        }
        if (matrix[row, col - 1] != 1)
        {
            return false;
        }
        if (matrix[row, col + 1] != 1)
        {
            return false;
        }
        if (matrix[row + 1, col + 1] != 1)
        {
            return false;
        }
        if (matrix[row + 1, col] != 1)
        {
            return false;
        }
        if (matrix[row + 1, col - 1] != 1)
        {
            return false;
        }
        return true;
    }

    static byte[,] RemoveCapacitor (byte row, byte col, byte[,] matrix)
    {
        matrix[row - 1, col - 1] = 0;
        matrix[row - 1, col] = 0;
        matrix[row - 1, col + 1] = 0;
        matrix[row, col - 1] = 0;
        matrix[row, col + 1] = 0;
        matrix[row + 1, col + 1] = 0;
        matrix[row + 1, col] = 0;
        matrix[row + 1, col - 1] = 0;
        return matrix;
    }

    static byte NumberOfCapacitors (byte[,] matrix, string side)
    {
        byte result = 0;
        if (side == "left")
        {
            for (byte row = 1; row < 17; row++)
            {
                for (byte col = 1; col < 9; col++)
                { 
                    if (SurroundedByOnes(row, col, matrix))
                    {
                        result++;
                    }
                }
            }
        }
        else if (side == "right")
        {
            for (byte row = 1; row < 17; row++)
            {
                for (byte col = 9; col < 17; col++)
                {
                    if (SurroundedByOnes(row, col, matrix))
                    {
                        result++;
                    }
                }
            }
        }
        return result;
    }
}

