using System.Collections;
using System.Linq;

namespace StacksAndQueues
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            // ReverseNumbers();
            // CalcSequence();
            // SequenceNm();

            Console.ReadKey();
        }

        private static void ReverseNumbers()
        {
            var input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                var numbers = new Stack<int>();
                foreach (var number in input.Split(' '))
                {
                    numbers.Push(int.Parse(number));
                }

                Console.WriteLine(string.Join(" ", numbers));
            }
        }

        private static void CalcSequence()
        {
            var sequence = new Queue<int>();
            var printedCount = 0;
            sequence.Enqueue(int.Parse(Console.ReadLine() ?? "2"));
            while (printedCount < 50)
            {
                var current = sequence.Dequeue();
                sequence.Enqueue(current + 1);
                sequence.Enqueue(2 * current + 1);
                sequence.Enqueue(current + 2);
                Console.WriteLine(current);
                printedCount++;
            }
        }

        private static void SequenceNm()
        {
            var input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                var numbers = input.Split(' ').Select(int.Parse).ToList();
                var queue = new Queue<HelperNode>();
                queue.Enqueue(new HelperNode(numbers[0]));
                while (queue.Any())
                {
                    var currentItem = queue.Dequeue();
                    if (currentItem.Value < numbers[1])
                    {
                        queue.Enqueue(new HelperNode(currentItem.Value + 1, currentItem));
                        queue.Enqueue(new HelperNode(currentItem.Value + 2, currentItem));
                        queue.Enqueue(new HelperNode(currentItem.Value * 2, currentItem)); ;
                    }
                    else if (currentItem.Value == numbers[1])
                    {
                        var result = new Stack<int>();
                        while (currentItem != null)
                        {
                            result.Push(currentItem.Value);
                            currentItem = currentItem.PreviousNode;
                        }

                        Console.WriteLine(string.Join(" -> ", result));
                        break;
                    }
                }
            }
        }

        private class HelperNode
        {
            public HelperNode(int value, HelperNode previous = null)
            {
                this.Value = value;
                this.PreviousNode = previous;
            }

            public int Value { get; private set; }

            public HelperNode PreviousNode { get; private set; }
        }
    }
}
