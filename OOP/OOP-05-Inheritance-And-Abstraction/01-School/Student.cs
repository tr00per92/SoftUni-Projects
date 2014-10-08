using System.Collections.Generic;

namespace _01_School
{
    public class Student : Person
    {
        public Student(string name, string id)
        {
            this.Name = name;
            this.Id = id;
            this.Comments = new List<string>();
        }

        public string Id { get; private set; }
    }
}
