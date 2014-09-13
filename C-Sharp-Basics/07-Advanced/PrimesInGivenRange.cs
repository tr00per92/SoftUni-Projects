using System;
using System.Collections.Generic;

class PrimesInGivenRange
{
    static void Main()
    {
        Console.Write("Start: ");
        int start = int.Parse(Console.ReadLine());
        Console.Write("End: ");
        int end = int.Parse(Console.ReadLine());
        Console.WriteLine("The prime numbers in the range are:");
        PrintList(FindPrimesInRange(start, end));
    }
    static void PrintList(List<int> list)
    {
        string output = "";
        foreach (int num in list)
        {
            output += num + ", ";
        }
        output = output.Trim(' ', ',');
        Console.WriteLine(output);     
    }
    static List<int> FindPrimesInRange(int startNum, int endNum)
    {
        List<int> primes = new List<int>();
        for (int i = startNum; i <= endNum; i++)
        {
            bool prime = true;
            if (i < 2)
            {
                prime = false;
            }
            else
            {
                for (int j = 2; j <= Math.Sqrt(i); j++)
                {
                    if (i % j == 0)
                    {
                        prime = false;
                        break;
                    }
                }
            }
            if (prime)
            {
                primes.Add(i);
            }
        }
        return primes;
    }
}

