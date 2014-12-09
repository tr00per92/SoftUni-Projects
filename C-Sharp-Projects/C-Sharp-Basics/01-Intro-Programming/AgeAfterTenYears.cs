using System;

class AgeAfterTenYears
{
    static void Main()
    {
        Console.WriteLine("Enter your birthday: ");
        DateTime born = DateTime.Parse(Console.ReadLine());
        int age = DateTime.Now.Year - born.Year;
        if (born.Month > DateTime.Now.Month || (born.Month == DateTime.Now.Month && born.Day > DateTime.Now.Day))
        {
            age -= 1;
        }       
        Console.WriteLine("You are {0} years old", age);
        Console.WriteLine("After 10 years you'll be {0} years old", age + 10);
    }
}
