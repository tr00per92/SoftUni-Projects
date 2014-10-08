using System;
using System.Collections.Generic;

namespace _03_LINQ_Practice
{
    public class Student
    {
        public Student(string fName, string lName, int age, string facultyNum,
            string phone, string email, int groupNum, IList<decimal> marks)
        {
            this.FirstName = fName;
            this.LastName = lName;
            this.Age = age;
            this.FacultyNumber = facultyNum;
            this.Phone = phone;
            this.Email = email;
            this.GroupNumber = groupNum;
            this.Marks = marks;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string FacultyNumber { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int GroupNumber { get; set; }
        public IList<decimal> Marks { get; set; }

        public override string ToString()
        {
            return string.Format("Name: {0} {1}; Age: {2}; FacultyNumber: {3}; Phone: {4}; Email: {5}; Group: {6}; Marks: {7}",
                this.FirstName, this.LastName, this.Age, this.FacultyNumber, this.Phone, this.Email, this.GroupNumber, string.Join(", ", this.Marks));
        }
    }
}
