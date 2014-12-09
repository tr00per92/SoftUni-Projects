using System;

namespace _04_CompanyHierarchy
{
    public class Project : IProject
    {
        private string name;
        private bool isOpen;

        public Project(string name, DateTime startDate, string details = null)
        {
            this.Name = name;
            this.StartDate = startDate;
            this.Details = details;
            this.isOpen = true;
        }

        public DateTime StartDate { get; set; }

        public string Details { get; set; }

        public string Name
        {
            get { return this.name; }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Project name cannot be empty.");
                }

                this.name = value;
            }
        }

        public void CloseProject()
        {
            this.isOpen = false;
        }

        public override string ToString()
        {
            return string.Format("Project: {0}, Start Date: {1}, Details: {2}, Active: {3}",
                this.Name, this.StartDate.ToString("dd-MM-yy"), this.Details ?? "None", this.isOpen ? "Yes" : "No");
        }
    }
}
