using System;

namespace _03_SoftUniLearningSystem
{
    class Student : Person
    {
        private string studentNumber;
        private decimal averageGrade;

        public Student(string firstName, string lastName, int age,
            string studentNumber, decimal averageGrade)
            : base(firstName, lastName, age) 
        {
            this.StudentNumber = studentNumber;
            this.AverageGrade = averageGrade;            
        }

        public string StudentNumber
        {
            get { return this.studentNumber; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid student number!");
                }
                this.studentNumber = value;
            }
        }
        public decimal AverageGrade
        {
            get { return this.averageGrade; }
            set
            {
                if (value < 2m || value > 6m)
                {
                    throw new ArgumentException("Invalid grade!");
                }
                this.averageGrade = value;
            }
        }

        public void PrintInfo()
        {
            Console.WriteLine("Name: {0} {1}", this.FirstName, this.LastName);
            Console.WriteLine("Age: {0}", this.Age);
            Console.WriteLine("Student Number: {0}", this.StudentNumber);
            Console.WriteLine("Average Grade: {0:F2}", this.AverageGrade);
            Console.WriteLine();
        }
    }
}
