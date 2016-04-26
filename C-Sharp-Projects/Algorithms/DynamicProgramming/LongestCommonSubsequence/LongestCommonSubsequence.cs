namespace LongestCommonSubsequence
{
    using System;
    using System.Collections.Generic;

    public class LongestCommonSubsequence
    {
        public static void Main()
        {
            const string firstStr = "tree";
            const string secondStr = "team";

            var lcs = FindLongestCommonSubsequence(firstStr, secondStr);

            Console.WriteLine("Longest common subsequence:");
            Console.WriteLine("  first  = {0}", firstStr);
            Console.WriteLine("  second = {0}", secondStr);
            Console.WriteLine("  lcs    = {0}", lcs);
        }

        public static string FindLongestCommonSubsequence(string first, string second)
        {
            var firstLength = first.Length + 1;
            var secondLength = second.Length + 1;
            var matrix = new int[firstLength, secondLength];
            for (var i = 1; i < firstLength; i++)
            {
                for (var j = 1; j < secondLength; j++)
                {
                    if (first[i - 1] == second[j - 1])
                    {
                        matrix[i, j] = matrix[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        matrix[i, j] = Math.Max(matrix[i - 1, j], matrix[i, j - 1]);
                    }
                }
            }

            var lcs = RetrieveLcs(first, second, matrix);
            return lcs;
        }

        private static string RetrieveLcs(string first, string second, int[,] matrix)
        {
            var lcs = new List<char>();
            var row = first.Length;
            var col = second.Length;
            while (row > 0 && col > 0)
            {
                if (first[row - 1] == second[col - 1])
                {
                    lcs.Add(first[row - 1]);
                    row--;
                    col--;
                }
                else if (matrix[row, col] == matrix[row - 1, col])
                {
                    row--;
                }
                else
                {
                    col--;
                }
            }

            lcs.Reverse();
            return new string(lcs.ToArray());
        }
    }
}