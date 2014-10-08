using System.Collections.Generic;

namespace _01_School
{
    public class SchoolClass : ICommentable
    {
        public SchoolClass(string id)
        {
            this.Students = new List<Student>();
            this.Teachers = new List<Teacher>();
            this.Comments = new List<string>();
            this.Id = id;
        }

        public ICollection<Student> Students { get; private set; }

        public ICollection<Teacher> Teachers { get; private set; }

        public string Id { get; private set; }

        public IList<string> Comments { get; set; }

        public void AddStudent(Student student)
        {
            this.Students.Add(student);
        }

        public void AddTeacher(Teacher teacher)
        {
            this.Teachers.Add(teacher);
        }

        public void AddComment(string comment)
        {
            this.Comments.Add(comment);
        }
    }
}
