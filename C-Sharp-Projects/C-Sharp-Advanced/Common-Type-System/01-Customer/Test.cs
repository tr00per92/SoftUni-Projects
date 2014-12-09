using System;
using System.Collections.Generic;

namespace _01_Customer
{
    public class Test
    {
        public static void Main()
        {
            Customer petko = new Customer("Petko", "Ivanov", "Petkov", "Sofia", "659497", "08886967", "pecata@gmail.com", CustomerType.Regular);
            Customer ivan = new Customer("Ivan", "Ivanov", "Ivanov", "Sofia", "865493", "088899635", "vanko@abc.bg", CustomerType.OneTime);
            Console.WriteLine(ivan == petko);
            Console.WriteLine(ivan != petko);
            Console.WriteLine();

            List<Customer> customers = new List<Customer> { petko, ivan, petko, ivan };
            customers.Sort();
            customers.ForEach(Console.WriteLine);
            Console.WriteLine();

            Customer petkoCloning = petko.Clone();
            petkoCloning.FirstName = "PetkoNumber2";
            petkoCloning.CustomerType = CustomerType.Golden;
            Console.WriteLine(petko);
            Console.WriteLine(petkoCloning);
        }
    }
}
