using System;

namespace _01_School
{
    public class Test
    {
        public static void Main()
        {
            SchoolClass physics = new SchoolClass("physics");

            Teacher pesho = new Teacher("Pesho");
            physics.AddTeacher(pesho);

            Teacher gosho = new Teacher("Gosho");
            physics.AddTeacher(gosho);

            Teacher tosho = new Teacher("Tosho");
            physics.AddTeacher(tosho);
            tosho.AddComment("I am a comment");

            Student ivan = new Student("Vanko", "009");
            physics.Students.Add(ivan);

            Student petko = new Student("Pecata", "003");
            physics.Students.Add(petko);

            School mySchool = new School();
            mySchool.Classes.Add(physics);

            foreach (var teacher in mySchool.Classes[0].Teachers)
            {
                Console.WriteLine(teacher.Name);
                Console.WriteLine(string.Join(", ", teacher.Comments));
            }

            foreach (var student in mySchool.Classes[0].Students)
            {
                Console.WriteLine(student.Name);
                Console.WriteLine(string.Join(", ", student.Comments));
            }
        }
    }
}
