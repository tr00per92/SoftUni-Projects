using System;

namespace _03_SoftUniLearningSystem
{
    class CurrentStudent : Student
    {
        public CurrentStudent(string firstName, string lastName, int age,
            string studentNumber, decimal averageGrade)
            : base(firstName, lastName, age, studentNumber, averageGrade) { }
    }
}
