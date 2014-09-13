using System;

class Lines
{
    static void Main()
    {
        byte[] nums = new byte[8];
        for (int i = 0; i < 8; i++)
        {
            nums[i] = byte.Parse(Console.ReadLine());
        }
        byte maxLength = 1;
        byte maxLines = 0;       
        for (byte i = 0; i < 8; i++)
        {
            byte mask = (byte)(1 << i);
            byte currentLength = 0;
            for (byte j = 0; j < 8; j++)
            {
                if ((nums[j] & mask) != 0)
                {
                    currentLength++;
                    if(currentLength > maxLength)
                    {
                        maxLines = 1;
                        maxLength = currentLength;
                    }
                    else if (currentLength == maxLength)
                    {
                        maxLines++;
                    }
                }
                else
                {
                    currentLength = 0;
                }
            }
        }
        for (byte j = 0; j < 8; j++)
        {
            byte currentLength = 0;
            for (byte i = 0; i < 8; i++)
            {
                byte mask = (byte)(1 << i);
                if ((nums[j] & mask) != 0)
                {
                    currentLength++;
                    if (currentLength > maxLength)
                    {
                        maxLines = 1;
                        maxLength = currentLength;
                    }
                    else if (currentLength == maxLength)
                    {
                        maxLines++;
                    }
                }
                else
                {
                    currentLength = 0;
                }
            }
        }
        if (maxLength == 1)
        {
            maxLines /= 2;
        }
        Console.WriteLine(maxLength);
        Console.WriteLine(maxLines);
    }
}

