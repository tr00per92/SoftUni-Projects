namespace StudentSystem.ConsoleClient
{
    using System;
    using StudentSystem.Data;
    using System.Data.Entity;
    using StudentSystem.Models;

    public class ConsoleClient
    {
        public static void Main()
        {
            using (var db = new StudentSystemEntities())
            {
                foreach (var student in db.Students.Include(s => s.Homeworks))
                {
                    Console.WriteLine(student.Name);
                    Console.WriteLine(new string('-', 20));
                    foreach (var homework in student.Homeworks)
                    {
                        Console.WriteLine("{0} - {1}", homework.TimeSent, homework.Content);
                    }

                    Console.WriteLine();
                }

                foreach (var course in db.Courses.Include(c => c.Resources))
                {
                    Console.WriteLine(course.Name);
                    Console.WriteLine(new string('-', 20));
                    foreach (var resource in course.Resources)
                    {
                        Console.WriteLine("{0} - {1}", resource.Name, resource.Type);
                    }

                    Console.WriteLine();
                }

                db.Courses.Add(new Course
                {
                    Name = "JS Advanced",
                    StartDate = DateTime.Parse("2015-03-15"),
                    Price = 100,
                    Resources = new[]
                    {
                        new Resource { Name = "First Lection", Type = ResourceType.Lecture }, 
                        new Resource { Name = "Homework", Type = ResourceType.Assignment }
                    }
                });

                db.Students.Add(new Student { Name = "Gecata", RegistrationDate = DateTime.Now });
                db.Resources.Add(new Resource { Name = "Second Presentation", CourseId = 1, Type = ResourceType.Presentation });

                db.SaveChanges();
            }
        }
    }
}
