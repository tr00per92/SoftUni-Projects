using System.Collections.Generic;

namespace _01_School
{
    public class School
    {
        public School()
        {
            this.Classes = new List<SchoolClass>();
        }

        public IList<SchoolClass> Classes { get; private set; }

        public void AddClass(SchoolClass currentClass)
        {
            this.Classes.Add(currentClass);
        }
    }
}
