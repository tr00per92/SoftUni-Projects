namespace RectangleIntersection
{
    using System;
    using System.Linq;

    public class RectangleIntersection
    {
        private const int Offset = 1000;
        private const int Size = 2001;

        public static void Main()
        {
            var matrix = new byte[Size, Size];
            var count = int.Parse(Console.ReadLine());
            for (var i = 0; i < count; i++)
            {
                var input = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
                for (var row = input[2]; row < input[3]; row++)
                {
                    for (var col = input[0]; col < input[1]; col++)
                    {
                        matrix[row + Offset, col + Offset]++;
                    }
                }
            }

            var result = 0;
            for (var row = 0; row < Size; row++)
            {
                for (var col = 0; col < Size; col++)
                {
                    if (matrix[row, col] > 1)
                    {
                        result++;
                    }
                }
            }

            Console.WriteLine(result);
        }
    }
}
