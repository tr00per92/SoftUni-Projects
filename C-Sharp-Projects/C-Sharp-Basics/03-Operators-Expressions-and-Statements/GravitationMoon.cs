using System;

class GravitationMoon
{
    static void Main()
    {
        Console.Write("Enter your weight: ");
        double weight = double.Parse(Console.ReadLine());
        double weightOnTheMoon = weight * 0.17;
        Console.WriteLine("Your weight on the moon is: " + weightOnTheMoon);
    }
}

