using System.Collections.Generic;

namespace _01_School
{
    public class Discipline : ICommentable
    {
        public Discipline(string name, int numberOfLectures = 0)
        {
            this.Name = name;
            this.NumberOfLectures = numberOfLectures;
            this.Comments = new List<string>();
        }

        public string Name { get; private set; }

        public ICollection<Student> Students { get; set; }

        public int NumberOfLectures { get; private set; }

        public IList<string> Comments { get; set; }

        public void AddComment(string comment)
        {
            this.Comments.Add(comment);
        }
    }
}
