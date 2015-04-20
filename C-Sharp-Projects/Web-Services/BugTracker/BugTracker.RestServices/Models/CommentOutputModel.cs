namespace BugTracker.RestServices.Models
{
    using System;
    using BugTracker.Data.Models;

    public class CommentOutputModel
    {
        public static Func<Comment, CommentOutputModel> FromComment
        {
            get
            {
                return comment => new CommentOutputModel
                {
                    Id = comment.Id,
                    Text = comment.Text,
                    Author = comment.Author != null ? comment.Author.UserName : null,
                    DateCreated = comment.DateCreated
                };
            }
        }

        public int Id { get; set; }

        public string Text { get; set; }

        public string Author { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
