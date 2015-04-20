namespace BugTracker.RestServices.Models
{
    using System;
    using System.Linq.Expressions;
    using BugTracker.Data.Models;

    public class BugOutputModel
    {
        public static Expression<Func<Bug, BugOutputModel>> FromBug
        {
            get
            {
                return bug => new BugOutputModel
                {
                    Id = bug.Id,
                    Title = bug.Title,
                    Status = bug.Status.ToString(),
                    Author = bug.Author != null ? bug.Author.UserName : null,
                    DateCreated = bug.DateCreated
                };
            }
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Status { get; set; }

        public string Author { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
