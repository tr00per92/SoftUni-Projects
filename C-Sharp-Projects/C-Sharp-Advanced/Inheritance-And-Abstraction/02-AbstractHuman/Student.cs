using System;

namespace _02_AbstractHuman
{
    public class Student : Human
    {
        private string facultyNumber;

        public Student(string firstName, string lastName, string facultyNumber)
            : base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        public string FacultyNumber
        {
            get { return this.facultyNumber; }

            set
            {
                if (value == null || value.Length < 5 || value.Length > 10)
                {
                    throw new ArgumentException("The faculty number must be between 5 and 10 symbols.");
                }

                this.facultyNumber = value;
            }
        }

        public override string ToString()
        {
            return this.FirstName + " " + this.LastName + " " + this.FacultyNumber;
        }
    }
}
