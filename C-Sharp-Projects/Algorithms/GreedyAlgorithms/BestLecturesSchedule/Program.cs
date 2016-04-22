namespace BestLecturesSchedule
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var selectedLectures = new List<Lecture>();
            var allLectures = ReadLectures();
            while (allLectures.Any())
            {
                var selectedLecture = allLectures.First();
                selectedLectures.Add(selectedLecture);
                allLectures.RemoveAll(l => l.Start < selectedLecture.End);
            }

            Console.WriteLine();
            Console.WriteLine($"Lectures ({selectedLectures.Count}):");
            selectedLectures.ForEach(Console.WriteLine);
        }

        private static List<Lecture> ReadLectures()
        {
            var count = int.Parse(Console.ReadLine().Split(' ').Last());
            var lectures = new List<Lecture>(count);
            for (var i = 0; i < count; i++)
            {
                var tokens = Console.ReadLine().Split(new[] { ":", "-", " " }, StringSplitOptions.RemoveEmptyEntries);
                lectures.Add(new Lecture(tokens[0], int.Parse(tokens[1]), int.Parse(tokens[2])));
            }

            lectures.Sort();
            return lectures;
        }
    }
}
