using System;
using System.Collections.Generic;
using System.Text;

namespace _04_CompanyHierarchy
{
    public class Developer : Employee, IDeveloper
    {
        private ICollection<Project> projects;

        public Developer(int id, string firstName, string lastName,
            Department department, decimal salary)
            : base(id, firstName, lastName, department, salary)
        {
            this.projects = new List<Project>();
        }

        public void AddProject(Project project)
        {
            this.projects.Add(project);
        }

        public void RemoveProject(Project project)
        {
            this.projects.Remove(project);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(base.ToString());
            result.AppendLine("Developer projects: ");
            result.Append(string.Join("\n", this.projects));

            return result.ToString();
        }
    }
}
