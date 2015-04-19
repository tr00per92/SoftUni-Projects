namespace BlogSystem.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using BlogSystem.Models;
    
    public class TagsController : BaseController
    {
        [HttpGet]
        public IHttpActionResult All()
        {
            return this.Ok(this.data.Tags.All().Select(t => t.Name).ToList());
        }

        [HttpPost]
        [Route("api/Tags/Add/{tag}")]
        public IHttpActionResult Add(string tag)
        {
            if (string.IsNullOrWhiteSpace(tag))
            {
                return this.BadRequest("You must provide a tag.");
            }

            if (this.data.Tags.Find(t => t.Name == tag).FirstOrDefault() != null)
            {
                return this.BadRequest("This tag already exists.");
            }

            this.data.Tags.Add(new Tag { Name = tag });
            this.data.SaveChanges();

            return this.Ok();
        }
    }
}