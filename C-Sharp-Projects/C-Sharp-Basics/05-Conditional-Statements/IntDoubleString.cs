using System;

class IntDoubleString
{
    static void Main()
    {
        Console.WriteLine(@"Please choose a type:
1 --> int
2 --> double
3 --> string");
        string type = Console.ReadLine();
        switch (type)
        {
            case "1":
                Console.Write("Please enter an integer: ");
                int a = int.Parse(Console.ReadLine());
                Console.WriteLine("Result: {0}", a + 1);
                break;
            case "2":
                Console.Write("Please enter a double: ");
                double b = double.Parse(Console.ReadLine());
                Console.WriteLine("Result: {0}", b + 1);
                break;
            case "3":
                Console.Write("Please enter a string: ");
                string c = Console.ReadLine();
                Console.WriteLine("Result: {0}*", c);
                break;
            default:
                Console.WriteLine("Wrong input"); break;
        }
    }
}

