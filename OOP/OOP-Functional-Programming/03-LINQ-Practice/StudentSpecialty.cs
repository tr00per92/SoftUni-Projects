using System;

namespace _03_LINQ_Practice
{
    public class StudentSpecialty
    {
        public StudentSpecialty(string facNumber)
        {
            this.FacultyNumber = facNumber;
            this.Specialy = this.GetSpecialty();
        }

        public string FacultyNumber { get; set; }
        public string Specialy { get; private set; }

        public override string ToString()
        {
            return string.Format("Faculty Number: {0}, Specialty: {1}", this.FacultyNumber, this.Specialy);
        }

        private string GetSpecialty()
        {
            switch (this.FacultyNumber[0])
            {
                case '0': return "Biology";
                case '1': return "Chemistry";
                case '2': return "Physics";
                case '3': return "Maths";
                case '4': return "Engineering";
                case '5': return "History";
                case '6': return "Phychology";
                case '7': return "Literature";
                case '8': return "Geography";
                case '9': return "Economics";
                default: throw new FormatException("Cannot get specialty");
            }
        }
    }
}
