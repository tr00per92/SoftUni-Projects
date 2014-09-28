using System;

namespace _01_SquareRoot
{
    class SquareRoot
    {
        static void Main()
        {
            try
            {
                int num = int.Parse(Console.ReadLine());
                if (num < 0)
                {
                    throw new ArgumentOutOfRangeException
                        ("num", "Sqrt for negative numbers is undefined.");
                }
                Console.WriteLine(Math.Sqrt(num));
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Error.WriteLine("Error: " + e.Message);
            }
            catch (FormatException e)
            {
                Console.Error.WriteLine("Error: " + e.Message);
                Console.Error.WriteLine("You must enter an integer.");
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Error: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Good bye!");
            }
        }
    }
}
