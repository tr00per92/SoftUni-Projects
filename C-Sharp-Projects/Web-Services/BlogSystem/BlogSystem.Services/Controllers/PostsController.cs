namespace BlogSystem.Services.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using BlogSystem.Models;
    using BlogSystem.Services.Models;

    public class PostsController : BaseController
    {
        [HttpGet]
        public IHttpActionResult All()
        {
            return this.Ok(this.data.Posts.All().ToList().Select(PostDataModel.FromPost));
        }

        [HttpPost]
        public IHttpActionResult Add(PostDataModel postData)
        {
            if (postData == null || postData.AuthorId == null || string.IsNullOrWhiteSpace(postData.Content))
            {
                return this.BadRequest("You must provide post content and author.");
            }

            var newPost = PostDataModel.ToPost(postData);
            if (!string.IsNullOrWhiteSpace(postData.Tags))
            {
                var tags = this.GetTagsFromDataModel(postData);
                newPost.Tags = tags;
            }
            
            this.data.Posts.Add(newPost);
            this.data.SaveChanges();

            return this.Ok();
        }

        [HttpPut]
        public IHttpActionResult Update(PostDataModel postData)
        {
            if (postData == null || postData.Id == null)
            {
                return this.BadRequest("You must provide a valid post id and a new content.");
            }

            var post = this.data.Posts.GetById(postData.Id);
            if (post == null)
            {
                return this.BadRequest("Invalid post id.");
            }

            if (!string.IsNullOrWhiteSpace(postData.Content))
            {
                post.Content = postData.Content;
            }

            if (!string.IsNullOrWhiteSpace(postData.Tags))
            {
                var newTags = this.GetTagsFromDataModel(postData);
                post.Tags = newTags;
            }
            
            this.data.SaveChanges();

            return this.Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var post = this.data.Posts.GetById(id);
            if (post == null)
            {
                return this.BadRequest("A post with the provided ID do not exist.");
            }

            this.data.Posts.Delete(post);
            this.data.SaveChanges();

            return this.Ok();
        }

        private ICollection<Tag> GetTagsFromDataModel(PostDataModel postData)
        {
            // get the tags from the string
            var tags = new List<Tag>();
            if (!string.IsNullOrWhiteSpace(postData.Tags))
            {
                tags = postData.Tags.Split(',').Select(t => new Tag { Name = t.Trim() }).ToList();
            }

            // add the new tags to the database
            for (var i = 0; i < tags.Count; i++)
            {
                var currentTag = tags[i];
                var existingTag = this.data.Tags.Find(t => t.Name == currentTag.Name).FirstOrDefault();
                if (existingTag != null)
                {
                    tags[i] = existingTag;
                }
                else
                {
                    this.data.Tags.Add(tags[i]);
                }
            }

            return tags;
        }
    }
}