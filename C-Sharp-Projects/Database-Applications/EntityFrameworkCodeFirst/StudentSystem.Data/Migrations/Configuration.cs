namespace StudentSystem.Data.Migrations
{
    using System;
    using System.Linq;
    using StudentSystem.Models;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<StudentSystemEntities>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(StudentSystemEntities db)
        {
            var gosho = new Student { Name = "Georgi Petrov", RegistrationDate = DateTime.Now };
            var pesho = new Student { Name = "Petur Ivanov", DateOfBirth = DateTime.Parse("1990-05-23") };
            var sashko = new Student { Name = "Sahko Toshev", PhoneNumber = "088888888" };
            var vanko = new Student { Name = "Vankata Genadiev", PhoneNumber = "0896565656" };
            
            if (!db.Students.Any())
            {
                db.Students.Add(gosho);
                db.Students.Add(pesho);
                db.Students.Add(sashko);
                db.Students.Add(vanko);
            }

            var efCourse = new Course { Name = "EntityFramework", StartDate = DateTime.Now, Price = 200, Students = new[] { gosho } };
            var programmingCourse = new Course
            {
                Name = "Programming",
                Description = "Introduction to programming with C#",
                StartDate = DateTime.Now,
                EndDate = DateTime.Parse("2015-04-01"),
                Price = 0,
                Students = new[] { pesho, sashko, gosho, vanko }
            };

            if (!db.Courses.Any())
            {
                db.Courses.Add(programmingCourse);
                db.Courses.Add(efCourse);
                db.Courses.Add(new Course { Name = "Databases", StartDate = DateTime.Parse("2015-03-30"), Price = 350, Students = new[] { pesho, sashko } });
            }

            if (!db.Homeworks.Any())
            {
                db.Homeworks.Add(new Homework { Content = "Moeto Doma6no", Student = pesho, Course = programmingCourse, TimeSent = DateTime.Now });
                db.Homeworks.Add(new Homework { Content = "Doma6nooo", Student = gosho, Course = programmingCourse, TimeSent = DateTime.Now });
            }

            if (!db.Resources.Any())
            {
                db.Resources.Add(new Resource { Name = "Intro C# Lection", Type = ResourceType.Lecture, Course = programmingCourse });
                db.Resources.Add(new Resource { Name = "DB Teamwork assignment", Type = ResourceType.Assignment, Url = "www.pesho.com", Course = efCourse });
            }
        }
    }
}
