using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace _03_LINQ_Practice
{
    public class WorkingWithLINQ
    {
        // each task can be tested by uncommenting the foreach line
        public static void Main()
        {
            List<Student> students = GetInput();
            //Console.WriteLine(students.Count);
            //students.ForEach(student => Console.WriteLine(student + "\n"));            

            // all students from group two sorted by first name
            var studentsFromGroupFour = from student in students
                                        where student.GroupNumber == 2
                                        select student;
            //studentsFromGroupFour.ToList().ForEach(student => Console.WriteLine(student + "\n"));

            // first name is before last name alphabetically
            var lastNameBeforeFirst = from student in students
                                      where student.FirstName.CompareTo(student.LastName) < 0
                                      select student;
            //lastNameBeforeFirst.ToList().ForEach(student => Console.WriteLine(student + "\n"));

            // names of student with age between 18 and 24
            var studentsAged18to24 = from student in students
                                     where student.Age >= 18 && student.Age <= 24
                                     select student.FirstName + " " + student.LastName;
            //studentsAged18to24.ToList().ForEach(studentName => Console.WriteLine(studentName));

            // sorting by first and last name
            var sortedStudents = from student in students
                                 orderby student.FirstName[0] descending, student.LastName descending
                                 select student;
            // same as the above with lambda
            sortedStudents = students.OrderByDescending(student => student.FirstName[0])
                .ThenByDescending(student => student.LastName);
            //sortedStudents.ToList().ForEach(student => Console.WriteLine(student + "\n"));

            // students with mails in abv.bg
            var studentsWithAbvMails = students.Where(student => student.Email.Split('@')[1] == "abv.bg");
            //studentsWithAbvMails.ToList().ForEach(student => Console.WriteLine(student + "\n"));

            // student with phones from sofia
            var studentWithSofiaPhones = students.Where(student => student.Phone.StartsWith("02")
                || student.Phone.StartsWith("+3592") || student.Phone.StartsWith("+359 2"));
            //studentWithSofiaPhones.ToList().ForEach(student => Console.WriteLine(student + "\n"));

            // excellent students
            var excellentStudents = students.Where(student => student.Marks.Contains(6))
                .Select(student => new { FullName = student.FirstName + " " + student.LastName,
                    Marks = string.Join(", ", student.Marks) });
            //excellentStudents.ToList().ForEach(student => Console.WriteLine(student + "\n"));

            // weak students
            var weakStudents = students
                .Where(student => student.Marks
                    .Where(mark => mark == 2)
                    .GroupBy(mark => mark).Any(mark => mark.Count() == 2))
                .Select(student => new
                {
                    FullName = student.FirstName + " " + student.LastName,
                    Marks = string.Join(", ", student.Marks)
                });
            //weakStudents.ToList().ForEach(student => Console.WriteLine(student + "\n"));

            // student enrolled in 2014
            var studentsFrom2014 = 
                students.Where(student => student.FacultyNumber.Substring(4, 2) == "14");
            //studentsFrom2014.ToList().ForEach(student => Console.WriteLine(student + "\n"));

            // students by group number
            var studentsByGroup = from student in students
                                  orderby student.GroupNumber
                                  group student by student.GroupNumber into groups
                                  select new { Group = groups.Key,
                                      Students = string.Join(", ", groups.Select(stud => stud.FirstName + " " + stud.LastName)) };
            //studentsByGroup.ToList().ForEach(student => Console.WriteLine(student + "\n"));

            // list of specialties
            var specialties = from student in students
                              select new StudentSpecialty(student.FacultyNumber);
            //specialties.ToList().ForEach(specialty => Console.WriteLine(specialty + "\n"));

            // all students with their specialty and faculty number
            var studentsAndSpecialties = students.Join(specialties,
                stud => stud.FacultyNumber, spec => spec.FacultyNumber,
                (stud, spec) => 
                    new { FullName = stud.FirstName + " " + stud.LastName, spec.FacultyNumber, spec.Specialy });
            //studentsAndSpecialties.ToList().ForEach(student => Console.WriteLine(student + "\n"));
        }

        // this method is reading input from a text file for testing purposes
        private static List<Student> GetInput()
        {
            List<Student> students = new List<Student>();

            string pathToFile = "../../testData/testData.csv";
            StreamReader reader = new StreamReader(pathToFile);
            using (reader)
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    string[] properties = line.Split('|');
                    int age = int.Parse(properties[2]);
                    int group = int.Parse(properties[6]);
                    decimal mark1 = Math.Round(decimal.Parse(properties[7]), 2);
                    decimal mark2 = Math.Round(decimal.Parse(properties[8]), 2);
                    decimal mark3 = Math.Round(decimal.Parse(properties[9]), 2);
                    decimal mark4 = Math.Round(decimal.Parse(properties[10]), 2);
                    List<decimal> marks = new List<decimal>() { mark1, mark2, mark3, mark4 };
                    
                    students.Add(new Student(properties[0], properties[1], age,
                        properties[3], properties[4], properties[5], group, marks));

                    line = reader.ReadLine();
                }
            }

            return students;
        }
    }
}
