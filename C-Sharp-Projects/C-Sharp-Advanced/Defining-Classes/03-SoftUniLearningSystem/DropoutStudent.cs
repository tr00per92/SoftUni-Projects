using System;

namespace _03_SoftUniLearningSystem
{
    class DropoutStudent : Student
    {
        private string dropoutReason;

        public DropoutStudent(string firstName, string lastName, int age,
            string studentNumber, decimal averageGrade)
            : base(firstName, lastName, age, studentNumber, averageGrade) { }
        public DropoutStudent(string firstName, string lastName, int age,
            string studentNumber, decimal averageGrade, string dropoutReason)
            : base(firstName, lastName, age, studentNumber, averageGrade)
        {
            this.DropoutReason = dropoutReason;
        }

        public string DropoutReason
        {
            get { return this.dropoutReason; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid dropout reason!");
                }
                this.dropoutReason = value;
            }
        }

        public void Reapply()
        {
            Console.WriteLine("Name: {0} {1}", this.FirstName, this.LastName);
            Console.WriteLine("Age: {0}", this.Age);
            Console.WriteLine("Student Number: {0}", this.StudentNumber);
            Console.WriteLine("Average Grade: {0}", this.AverageGrade);
            Console.WriteLine("Dropout Reason: {0}", this.DropoutReason);
        }
    }
}
