using System;
using System.Text;
using System.Collections.Generic;

namespace _01_StringBuilderExtensions
{
    public static class StringBuilderExtensions
    {
        public static string Substring(this StringBuilder sb, int startIndex, int length)
        {
            return sb.ToString().Substring(startIndex, length);
        }

        public static void RemoveText(this StringBuilder sb, string text)
        {
            string sbToString = sb.ToString();
            sb.Clear();
            int previousIndex = 0;
            int index = sbToString.IndexOf(text, StringComparison.InvariantCultureIgnoreCase);
            while (index != -1)
            {
                sb.Append(sbToString.Substring(previousIndex, index - previousIndex));
                index += text.Length;
                previousIndex = index;
                index = sbToString.IndexOf(text, index, StringComparison.InvariantCultureIgnoreCase);
            }
            sb.Append(sbToString.Substring(previousIndex));
        }

        public static void AppendAll<T>(this StringBuilder sb, IEnumerable<T> items)
        {
            sb.Append(string.Join(" ", items));
        }
    }
}
