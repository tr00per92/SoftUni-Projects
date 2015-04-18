namespace News.Services.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using News.Data;
    using News.Services.Infrastructure;
    using News.Services.Models;

    [Authorize]
    public class NewsController : ApiController
    {
        public NewsController()
            : this(new NewsRepository(), new AspNetUserIdProvider())
        {
        }

        public NewsController(
            IRepository<News> newsRepository,
            IUserIdProvider userIdProvider = null)
        {
            this.NewsData = newsRepository ?? new NewsRepository();
            this.UserIdProvider = userIdProvider ?? new AspNetUserIdProvider();
        }

        private IRepository<News> NewsData { get; set; }

        private IUserIdProvider UserIdProvider { get; set; }

        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult GetAll()
        {
            return this.Ok(this.NewsData.All().ToList());
        }

        [HttpPost]
        public IHttpActionResult AddNews(NewsBindingModel newsModel)
        {
            if (newsModel == null || !this.ModelState.IsValid)
            {
                return this.BadRequest("The news title and content are required.");
            }

            var newsToAdd = new News
            {
                Title = newsModel.Title,
                Content = newsModel.Content,
                PublishDate = newsModel.PublishDate ?? DateTime.Now,
                UserId = this.UserIdProvider.GetUserId()
            };

            this.NewsData.Add(newsToAdd);
            this.NewsData.SaveChanges();

            return this.CreatedAtRoute("DefaultApi", new { id = newsToAdd.Id }, newsToAdd);
        }

        [HttpPut]
        public IHttpActionResult UpdateNews(int id, NewsBindingModel newsModel)
        {
            var newsToUpdate = this.NewsData.Find(id);
            if (newsToUpdate == null)
            {
                return this.BadRequest("There is no such news.");
            }

            if (newsToUpdate.UserId != this.UserIdProvider.GetUserId())
            {
                return this.Unauthorized();
            }

            if (newsModel == null || !this.ModelState.IsValid)
            {
                return this.BadRequest("The news title and content are required.");
            }

            newsToUpdate.Title = newsModel.Title;
            newsToUpdate.Content = newsModel.Content;
            if (newsModel.PublishDate != null)
            {
                newsToUpdate.PublishDate = newsModel.PublishDate.Value;
            }

            this.NewsData.Update(newsToUpdate);
            this.NewsData.SaveChanges();

            return this.Ok(newsToUpdate);
        }

        [HttpDelete]
        public IHttpActionResult DeleteNews(int id)
        {
            var newsToDelete = this.NewsData.Find(id);
            if (newsToDelete == null)
            {
                return this.BadRequest("There is no such news.");
            }

            if (newsToDelete.UserId != this.UserIdProvider.GetUserId())
            {
                return this.Unauthorized();
            }

            this.NewsData.Delete(newsToDelete.Id);
            this.NewsData.SaveChanges();

            return this.Ok("News deleted successfully.");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.NewsData.Dispose();
                this.NewsData = null;
            }

            base.Dispose(disposing);
        }
    }
}