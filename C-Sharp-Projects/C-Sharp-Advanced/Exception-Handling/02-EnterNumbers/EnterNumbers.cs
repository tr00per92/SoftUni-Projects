using System;

namespace _02_EnterNumbers
{
    class EnterNumbers
    {
        static void Main()
        {
            int[] numbers = new int[10];
            int min = 1;
            int max = 100;
            for (int i = 0; i < numbers.Length; i++)
            {
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Enter an integer between {0} and {1}:", min, max);
                        numbers[i] = ReadNumber(min, max);
                        min = numbers[i];
                        break;
                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine("Error: " + e.Message);
                        Console.Error.WriteLine("Please try again.");
                    }    
                }                            
            }
            Console.Write("The numbers you entered are: ");
            foreach (int num in numbers)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }

        static int ReadNumber(int start, int end)
        {
            int num = int.Parse(Console.ReadLine());
            if (num < start || num > end)
            {
                throw new ArgumentException
                    (string.Format("The value must be between: {0} and {1}.", start, end));
            }
            return num;
        }
    }
}
