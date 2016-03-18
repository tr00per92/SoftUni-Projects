namespace DataStructuresEfficiency
{
    using System;

    public class Student : IComparable<Student>
    {
        public Student(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int CompareTo(Student other)
        {
            if (other == null)
            {
                return 1;
            }

            var lastNameCompare = string.Compare(this.LastName, other.LastName, StringComparison.InvariantCultureIgnoreCase);
            if (lastNameCompare != 0)
            {
                return lastNameCompare;
            }

            return string.Compare(this.FirstName, other.FirstName, StringComparison.InvariantCultureIgnoreCase);
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", this.FirstName, this.LastName);
        }
    }
}
