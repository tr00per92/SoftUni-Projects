using System.Collections.Generic;

namespace _01_School
{
    public class Teacher : Person
    {
        public Teacher(string name)
        {
            this.Name = name;
            this.Disciplines = new List<Discipline>();
            this.Comments = new List<string>();
        }

        public ICollection<Discipline> Disciplines { get; private set; }

        public void AddDiscipline(Discipline discipline)
        {
            this.Disciplines.Add(discipline);
        }
    }
}
