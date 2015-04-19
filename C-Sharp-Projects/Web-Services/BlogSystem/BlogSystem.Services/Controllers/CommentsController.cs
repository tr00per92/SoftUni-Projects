namespace BlogSystem.Services.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Http;
    using BlogSystem.Models;
    using BlogSystem.Services.Models;

    public class CommentsController : BaseController
    {
        [HttpGet]
        public IHttpActionResult All()
        {
            return this.Ok(this.data.Comments.All().Select(CommentDataModel.FromComment).ToList());
        }

        [HttpPost]
        public IHttpActionResult Add(CommentDataModel commentData)
        {
            if (commentData == null || commentData.AuthorId == null || string.IsNullOrWhiteSpace(commentData.Content))
            {
                return this.BadRequest("You must provide comment content and author.");
            }

            var newComment = CommentDataModel.ToComment(commentData);
            this.data.Comments.Add(newComment);
            this.data.SaveChanges();

            return this.Ok(newComment.Id);
        }

        [HttpPut]
        public IHttpActionResult Update(CommentDataModel commentData)
        {
            if (commentData == null || commentData.Id == null || string.IsNullOrWhiteSpace(commentData.Content))
            {
                return this.BadRequest("You must provide a valid comment id and a new content.");
            }

            var comment = this.data.Comments.GetById(commentData.Id);
            if (comment == null)
            {
                return this.BadRequest("Invalid comment id.");
            }

            comment.Content = commentData.Content;
            this.data.SaveChanges();

            return this.Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var comment = this.data.Comments.GetById(id);
            if (comment == null)
            {
                return this.BadRequest("A comment with the provided ID do not exist.");
            }

            this.data.Comments.Delete(comment);
            this.data.SaveChanges();

            return this.Ok();
        }
    }
}