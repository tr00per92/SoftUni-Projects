namespace BlogSystem.Services.Models
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using BlogSystem.Models;

    public class PostDataModel
    {
        public static Func<Post, PostDataModel> FromPost
        {
            get
            {
                return post => new PostDataModel
                {
                    Id = post.Id,
                    Title = post.Title,
                    Content = post.Content,
                    AuthorId = post.UserId,
                    Tags = string.Join(", ", post.Tags)
                };
            }
        }

        public static Post ToPost(PostDataModel postDataModel)
        {
            return new Post
            {
                Title = postDataModel.Title,
                Content = postDataModel.Content,
                UserId = postDataModel.AuthorId.Value
            };
        }

        public int? Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int? AuthorId { get; set; }

        public string Tags { get; set; }
    }
}