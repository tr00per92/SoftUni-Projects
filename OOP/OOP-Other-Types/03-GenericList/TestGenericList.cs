using System;

namespace _03_GenericList
{
    class TestGenericList
    {
        public static void Main()
        {
            GenericList<int> test = new GenericList<int>(2);
            test.Add(1);
            test.Add(2);
            test.Add(10);
            test.Add(99);
            test.Add(22);
            test.Add(40);
            test.Add(121);
            test.Add(23);
            Console.WriteLine(test);
            Console.WriteLine(test[3]);
            Console.WriteLine(test.IndexOf(121));
            test.RemoveAt(3);
            Console.WriteLine(test);
            Console.WriteLine(test[3]);
            Console.WriteLine(test.IndexOf(121));
            test.InsertAt(4, 66);            
            Console.WriteLine(test);
            Console.WriteLine(test.Count);
            Console.WriteLine("Max: " + test.Max());
            Console.WriteLine("Min: " + test.Min());

            Console.WriteLine();
            var allAttributes = typeof(GenericList<>).GetCustomAttributes(typeof(VersionAttribute), false);
            Console.WriteLine("Version: " + allAttributes[0]);
        }
    }
}
