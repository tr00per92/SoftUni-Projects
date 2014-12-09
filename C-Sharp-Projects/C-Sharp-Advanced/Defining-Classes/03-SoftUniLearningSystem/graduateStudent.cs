using System;

namespace _03_SoftUniLearningSystem
{
    class GraduateStudent : Student
    {
        public GraduateStudent(string firstName, string lastName, int age,
            string studentNumber, decimal averageGrade)
            : base(firstName, lastName, age, studentNumber, averageGrade) { }
    }
}
