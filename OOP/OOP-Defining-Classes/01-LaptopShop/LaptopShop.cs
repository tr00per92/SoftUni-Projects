using System;

namespace _01_LaptopShop
{
    class LaptopShop
    {
        static void Main()
        {
            Battery myBattery = new Battery("8-cell Original", 4.5);
            Laptop myNetbook = new Laptop("IdeaPad", "Lenovo", "Intel Core i7", "8GB DDR3", "Radeon", "256GB SSD", myBattery, "15.7\" LED", 1070.85m);
            Console.WriteLine(myNetbook);

            Console.WriteLine();

            Laptop myNetbook1 = new Laptop("ThinkPad", 1602.10m);
            Console.WriteLine(myNetbook1);
        }
    }    
}
