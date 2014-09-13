using System;

class OddAndEvenProduct
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        long oddProduct = 1, evenProduct = 1;
        for (int i = 0; i < input.Length; i += 2)
        {
            oddProduct *= int.Parse(input[i]);
        }
        for (int i = 1; i < input.Length; i += 2)
        {
            evenProduct *= int.Parse(input[i]);
        }
        if (evenProduct == oddProduct)
        {
            Console.WriteLine("yes");
            Console.WriteLine("product = {0}", oddProduct);
        }
        else
        {
            Console.WriteLine("no");
            Console.WriteLine("odd_product = {0}", oddProduct);
            Console.WriteLine("even_product = {0}", evenProduct);
        }
    }
}

