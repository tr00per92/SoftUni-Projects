using System;

class SpiralMatrix
{
    static void Main()
    {
        Console.Write("Enter n: ");
        int n = int.Parse(Console.ReadLine());
        int[,] spiralMatrix = new int[n, n];
        int currentNum = 1;
        string direction = "right";
        int limit = n;        
        int currentLoops = 0;
        int row = 0, col = 0;
        while (currentNum <= Math.Pow(n, 2))
        {
            currentLoops++; 
            spiralMatrix[row, col] = currentNum;
            currentNum++;
 
            switch (direction)
            {
                case "right":
                    if (currentLoops < limit)
                    {
                        col++;
                    }
                    else
                    {
                        row++;
                        limit--;
                        direction = "down";
                        currentLoops = 0;
                    }
                    break;
                case "down":
                    if (currentLoops < limit)
                    {
                        row++;
                    }
                    else
                    {
                        col--;
                        direction = "left";
                        currentLoops = 0;
                    }
                    break;
                case "left":
                    if (currentLoops < limit)
                    {
                        col--;
                    }
                    else
                    {
                        row--;
                        limit--;
                        direction = "up";
                        currentLoops = 0;
                    }
                    break;
                case "up":
                    if (currentLoops < limit)
                    {
                        row--;
                    }
                    else
                    {
                        col++;
                        direction = "right";
                        currentLoops = 0;
                    }
                    break;
            } 
        } 
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write("{0,4}", spiralMatrix[i,j]);
            }
            Console.WriteLine();
        }
    }
}

