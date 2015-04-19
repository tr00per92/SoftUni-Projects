namespace BlogSystem.Services.Models
{
    using System;
    using System.Linq.Expressions;
    using BlogSystem.Models;

    public class CommentDataModel
    {
        public static Expression<Func<Comment, CommentDataModel>> FromComment
        {
            get
            {
                return comment => new CommentDataModel
                {
                    Id = comment.Id,
                    Content = comment.Content,
                    AuthorId = comment.UserId,
                };
            }
        }

        public static Comment ToComment(CommentDataModel commentDataModel)
        {
            return new Comment
            {
                Content = commentDataModel.Content,
                UserId = commentDataModel.AuthorId.Value
            };
        }

        public int? Id { get; set; }

        public string Content { get; set; }

        public int? AuthorId { get; set; }
    }
}