namespace StudentSystem.Data
{
    using System.Data.Entity;
    using StudentSystem.Models;
    using StudentSystem.Data.Migrations;

    public class StudentSystemEntities : DbContext
    {
        public StudentSystemEntities()
            : base ("StudentSystemConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemEntities, Configuration>());
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Homework> Homeworks { get; set; }

        public DbSet<Resource> Resources { get; set; }
    }
}
