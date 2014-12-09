using System;

namespace _15_LINQtoExcel
{
    public class Student
    {
        public Student(int id, string fName, string lName, string email, string gender,
            string studType, int examResult, int homeworkSent, int homeworkEvaluated,
            decimal teamwork, int attendances, decimal bonus)
        {
            this.ID = id;
            this.FirstName = fName;
            this.LastName = lName;
            this.Email = email;
            this.Gender = gender;
            this.StudentType = studType;
            this.ExamResult = examResult;
            this.HomeworkSent = homeworkSent;
            this.HomeworkEvaluated = homeworkEvaluated;
            this.TeamworkScore = teamwork;
            this.AttendacesCount = attendances;
            this.Bonus = bonus;
        }

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string StudentType { get; set; }
        public int ExamResult { get; set; }
        public int HomeworkSent { get; set; }
        public int HomeworkEvaluated { get; set; }
        public decimal TeamworkScore { get; set; }
        public int AttendacesCount { get; set; }
        public decimal Bonus { get; set; }

        public decimal CalculateResult()
        {
            return (this.ExamResult + this.HomeworkSent + this.HomeworkEvaluated
                + this.TeamworkScore + this.AttendacesCount + this.Bonus) / 5.0m;
        }
    }
}
