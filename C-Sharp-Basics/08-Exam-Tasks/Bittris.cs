using System;

class Bittris
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine()) / 4;
        byte[] grid = new byte[4];
        int totalScore = 0;
        for (int k = 0; k < n; k++)
        {
            int num = int.Parse(Console.ReadLine());
            byte piece = (byte)(num & 255);
            byte ones = 0;
            for (byte i = 0; i < 32; i++)
            {
                int mask = 1 << i;
                if ((num & mask) != 0)
                {
                    ones++;
                }
            }

            string[] commands = new string[3];
            commands[0] = Console.ReadLine();
            commands[1] = Console.ReadLine();
            commands[2] = Console.ReadLine();

            for (int i = 0; i < 3; i++)
            {
                switch (commands[i])
                {
                    case "L":
                        if ((piece & 128) == 0)
                        {
                            piece = (byte)(piece << 1);
                        }
                        break;
                    case "R":
                        if ((piece & 1) == 0)
                        {
                            piece = (byte)(piece >> 1);
                        }
                        break;
                    default: break;
                }

                if ((grid[i + 1] & piece) != 0)
                {
                    grid[i] |= piece;
                    if (grid[i] != 255)
                    {
                        totalScore += ones;
                    }
                    else
                    {
                        totalScore += ones * 10;
                        for (int j = i; j > 0; j--)
                        {
                            grid[j] = grid[j - 1];
                        }
                        grid[0] = 0;
                    }
                    break;
                }

                else
                {
                    if (i == 2)
                    {
                        grid[i + 1] |= piece;
                        if (grid[i + 1] != 255)
                        {
                            totalScore += ones;
                        }
                        else
                        {
                            totalScore += ones * 10;
                            for (int j = 3; j > 0; j--)
                            {
                                grid[j] = grid[j - 1];
                            }
                            grid[0] = 0;
                        }
                    }
                }
            }
            if ((grid[0] & 255) != 0)
            {
                break;
            }
        }
        Console.WriteLine(totalScore);
    }
}