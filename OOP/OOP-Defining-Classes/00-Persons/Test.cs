using System;

namespace _00_Persons
{
    class Test
    {
        static void Main()
        {
            Person ivan = new Person("Ivan", 27, "vankata@abc.com");
            Console.WriteLine(ivan);
            Person gosho = new Person("Gosho", 22);
            Console.WriteLine(gosho);
        }
    }
}
