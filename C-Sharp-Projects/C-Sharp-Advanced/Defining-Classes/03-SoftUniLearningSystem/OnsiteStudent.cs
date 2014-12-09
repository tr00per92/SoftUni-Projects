using System;

namespace _03_SoftUniLearningSystem
{
    class OnsiteStudent : CurrentStudent
    {
        private int numberOfVisits;

        public OnsiteStudent(string firstName, string lastName, int age,
            string studentNumber, decimal averageGrade)
            : base(firstName, lastName, age, studentNumber, averageGrade) { }
        public OnsiteStudent(string firstName, string lastName, int age,
            string studentNumber, decimal averageGrade, int numberOfVisits)
            : base(firstName, lastName, age, studentNumber, averageGrade) 
        {
            this.NumberOfVisits = numberOfVisits;
        }

        public int NumberOfVisits
        {
            get { return this.numberOfVisits; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid number of visits!");
                }
                this.numberOfVisits = value;
            }
        }
    }
}
