using System;

public class Program
{
    public static void Main()
    {
        try
        {
            Console.WriteLine("Enter an integer between 1 and 100");
            int number = int.Parse(Console.ReadLine());
            var matrix = new MatrixWalk(number);
            Console.WriteLine(matrix);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (FormatException ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("You must enter an integer between 1 and 100.");
        }
    }
}
