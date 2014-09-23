using System;

namespace _03_SoftUniLearningSystem
{
    class Trainer : Person
    {
        public Trainer(string firstName, string lastName, int age) 
            : base(firstName, lastName, age) { }

        public void CreateCourse(string courseName)
        {
            Console.WriteLine("Created cource: {0}", courseName);
        }
    }
}
