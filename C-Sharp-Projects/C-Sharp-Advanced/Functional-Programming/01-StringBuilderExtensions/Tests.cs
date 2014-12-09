using System;
using System.Text;
using System.Collections.Generic;

namespace _01_StringBuilderExtensions
{
    public class Tests
    {
        public static void Main()
        {
            StringBuilder test = new StringBuilder("toMAtoes aRe cOol");
            Console.WriteLine(test.Substring(2, 4));

            test.RemoveText(" ArE");
            Console.WriteLine(test);

            test.Clear();
            string[] words = { "pesho", "gosho", "vanko", "kiro", "jojo" };
            test.AppendAll(words);
            Console.WriteLine(test);

            List<int> nums = new List<int>() { 1, 3, 15, 24, 99 };
            test.Append(" ");
            test.AppendAll(nums);
            Console.WriteLine(test);
        }
    }
}
