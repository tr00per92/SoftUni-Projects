using System;

namespace _03_SoftUniLearningSystem
{
    class OnlineStudent : CurrentStudent
    {
        public OnlineStudent(string firstName, string lastName, int age,
            string studentNumber, decimal averageGrade)
            : base(firstName, lastName, age, studentNumber, averageGrade) { }
    }
}
