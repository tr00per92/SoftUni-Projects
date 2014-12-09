using System;

namespace _02_StringDisperser
{
    public class Test
    {
        public static void Main()
        {
            StringDisperser stringDisperser = new StringDisperser("gosho", "pesho", "tanio");
            Console.WriteLine(stringDisperser);
            foreach (var ch in stringDisperser)
            {
                Console.Write(ch + " ");
            }
            Console.WriteLine();

            StringDisperser otherDisperser = new StringDisperser("alabala", "portokala");
            Console.WriteLine(otherDisperser);
            Console.WriteLine(otherDisperser == stringDisperser);
            Console.WriteLine(otherDisperser.CompareTo(stringDisperser));

            StringDisperser clonedDisperser = stringDisperser.Clone();
            Console.WriteLine(clonedDisperser);
        }
    }
}
