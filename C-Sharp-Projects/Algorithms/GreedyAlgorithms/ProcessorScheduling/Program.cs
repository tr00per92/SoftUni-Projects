namespace ProcessorScheduling
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var selectedTasks = new List<Task>();
            var tasks = ReadTasks();
            foreach (var task in tasks)
            {
                selectedTasks.Add(task);
                if (selectedTasks.Max(t => t.Deadline) < selectedTasks.Count)
                {
                    selectedTasks.Remove(task);
                }
            }

            Console.WriteLine();
            var tasksToPrint = selectedTasks.OrderBy(t => t.Deadline).ThenByDescending(t => t.Value);
            Console.WriteLine($"Optimal schedule: {string.Join(" -> ", tasksToPrint)}");
            Console.WriteLine($"Total value: {selectedTasks.Sum(t => t.Value)}");
        }

        private static IEnumerable<Task> ReadTasks()
        {
            var tasksCount = int.Parse(Console.ReadLine().Split(' ').Last());
            var tasks = new List<Task>(tasksCount);
            for (var i = 1; i <= tasksCount; i++)
            {
                var tokens = Console.ReadLine().Split(' ');
                tasks.Add(new Task(int.Parse(tokens[0]), int.Parse(tokens[2]), i));
            }

            return tasks.OrderByDescending(t => t.Value);
        }
    }
}
