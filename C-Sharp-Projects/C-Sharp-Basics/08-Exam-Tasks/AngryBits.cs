using System;

class AngryBits
{
    static void Main()
    {
        int score = 0;
        //int[] nums = { 16920, 32785, 6, 4, 8194, 1041, 2112, 4548 };
        byte[,] matrix = new byte[8, 16];
        for (byte row = 0; row < 8; row++)
        {
            int input = int.Parse(Console.ReadLine());
            //string binary = Convert.ToString(nums[row], 2).PadLeft(16, '0');
            string binary = Convert.ToString(input, 2).PadLeft(16, '0');
            for (byte col = 0; col < 16; col++)
            {
                matrix[row, col] = byte.Parse(binary[col].ToString());
            }
        }

        //for (int row = 0; row < matrix.GetLength(0); row++)
        //{
        //    for (int col = 0; col < matrix.GetLength(1); col++)
        //    {
        //        Console.Write(matrix[row, col]);
        //    }
        //    Console.WriteLine();
        //}

        for (sbyte col = 7; col >= 0; col--)
        {            
            for (sbyte row = 0; row < 8; row++)
            {
                bool bird = false;

                if (matrix[row, col] == 1)
                {
                    bird = true;
                    matrix[row, col] = 0;
                }

                if(bird)
                {
                    byte flight = 0;
                    byte killed = 0;
                    sbyte birdrow = row;
                    sbyte birdcol = col;
                    bool up = true;
                    while (true)
                    {
                        if(birdrow < 8 && birdrow >= 0 && birdcol < 16 && matrix[birdrow,birdcol] == 1)
                        {
                            matrix[birdrow, birdcol] = 0;
                            killed++;

                            if (birdrow < 7 && matrix[birdrow + 1, birdcol] == 1)
                            {
                                matrix[birdrow + 1, birdcol] = 0;
                                killed++;
                            }
                            if (birdrow < 7 && matrix[birdrow + 1, birdcol - 1] == 1)
                            {
                                matrix[birdrow + 1, birdcol - 1] = 0;
                                killed++;
                            }
                            if (birdrow < 7 && birdcol < 15 && matrix[birdrow + 1, birdcol + 1] == 1)
                            {
                                matrix[birdrow + 1, birdcol + 1] = 0;
                                killed++;
                            }
                            if (birdrow > 0 && birdcol < 15 && matrix[birdrow - 1, birdcol + 1] == 1)
                            {
                                matrix[birdrow - 1, birdcol + 1] = 0;
                                killed++;
                            }
                            if (birdrow > 0 && matrix[birdrow - 1, birdcol] == 1)
                            {
                                matrix[birdrow - 1, birdcol] = 0;
                                killed++;
                            }
                            if (birdrow > 0 && matrix[birdrow - 1, birdcol - 1] == 1)
                            {
                                matrix[birdrow - 1, birdcol - 1] = 0;
                                killed++;
                            }
                            if (birdcol < 15 && matrix[birdrow, birdcol + 1] == 1)
                            {
                                matrix[birdrow, birdcol + 1] = 0;
                                killed++;
                            }
                            if (matrix[birdrow, birdcol - 1] == 1)
                            {
                                matrix[birdrow, birdcol - 1] = 0;
                                killed++;
                            }
                            break;
                        }
                        if (birdrow == 0)
                        {
                            up = false;
                        }
                        if (birdrow > 0 && up && birdcol < 16)
                        {
                            flight++;
                            birdrow--;
                            birdcol++;
                        }
                        else if (birdrow < 8 && !up && birdcol < 16)
                        {
                            flight++;
                            birdrow++;
                            birdcol++;
                        }
                        else
                        {                           
                            break;
                        }
                        
                    }
                    int roundScore = flight * killed;
                    score += roundScore;
                }
            }
        }
        bool win = true;
        for (byte row = 0; row < 8; row++)
        {
            for (byte col = 8; col < 16; col++)
            {
                if (matrix[row, col] == 1) 
                { 
                    win = false; 
                    break; 
                }
            }
        }

        Console.Write(score + " ");
        Console.WriteLine(win? "Yes" : "No");
    } 
}

