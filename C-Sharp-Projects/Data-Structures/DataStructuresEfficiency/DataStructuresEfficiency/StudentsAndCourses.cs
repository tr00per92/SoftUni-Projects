namespace DataStructuresEfficiency
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class StudentsAndCourses
    {
        public static void Main()
        {
            var courses = new SortedDictionary<string, SortedSet<Student>>();
            var lines = File.ReadLines("..\\..\\students.txt").Select(x => x.Split('|').Select(y => y.Trim()).ToList());
            foreach (var line in lines)
            {
                var course = line[2];
                if (!courses.ContainsKey(course))
                {
                    courses[course] = new SortedSet<Student>();
                }

                courses[course].Add(new Student(line[0], line[1]));
            }

            foreach (var course in courses)
            {
                Console.WriteLine("{0}: {1}", course.Key, string.Join(", ", course.Value));
            }
        }
    }
}
