namespace News.Services.IntegrationTests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using News.Data;
    using EntityFramework.Extensions;
    using Microsoft.Owin.Testing;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Owin;

    [TestClass]
    public class NewsControllerTests
    {
        private TestServer httpTestServer;
        private HttpClient httpClient;

        [TestInitialize]
        public void TestInit()
        {
            this.httpTestServer = TestServer.Create(appBuilder =>
            {
                var config = new HttpConfiguration();
                config.MessageHandlers.Add(new PresharedKeyAuthorizer());
                WebApiConfig.Register(config);
                appBuilder.UseWebApi(config);
            });

            this.httpClient = this.httpTestServer.HttpClient;
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.httpClient.Dispose();
            this.httpTestServer.Dispose();
        }

        [TestMethod]
        public void TestListAll()
        {
            ClearNews();
            var news = new[]
            {
                new News { Title = "Zaglavie", Content = "dadadada" },
                new News { Title = "Asdjoqwe", Content = "asodojk" }
            };

            using (var dbContext = new NewsDbContext())
            {
                dbContext.News.AddRange(news);
                dbContext.SaveChanges();
            }

            var httpResponse = this.httpClient.GetAsync("/api/news").Result;
            var returnedNews = httpResponse.Content.ReadAsAsync<List<News>>().Result;

            Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);
            Assert.AreEqual(httpResponse.Content.Headers.ContentType.MediaType, "application/json");
            Assert.AreEqual(2, returnedNews.Count);
            for (var i = 0; i < returnedNews.Count; i++)
            {
                Assert.AreEqual(returnedNews[i].Content, news[i].Content);
                Assert.AreEqual(returnedNews[i].Title, news[i].Title);
                Assert.AreEqual(returnedNews[i].PublishDate.ToString(), news[i].PublishDate.ToString());
                Assert.AreEqual(returnedNews[i].UserId, news[i].UserId);
            }
        }

        [TestMethod]
        public void TestAddValidNews()
        {
            ClearNews();
            var news = new News { Title = "Zaglavie", Content = "tralala123" };
            var postContent = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("title", news.Title),
                new KeyValuePair<string, string>("content", news.Content)
            });

            var httpResponse = this.httpClient.PostAsync("/api/news", postContent).Result;
            Assert.AreEqual(HttpStatusCode.Created, httpResponse.StatusCode);
            Assert.IsNotNull(httpResponse.Headers.Location);

            var returnedNews = httpResponse.Content.ReadAsAsync<News>().Result;
            Assert.IsTrue(returnedNews.Id != 0);
            Assert.AreEqual(news.Title, returnedNews.Title);
            Assert.AreEqual(news.Content, returnedNews.Content);
            Assert.AreEqual(news.PublishDate.ToString(), returnedNews.PublishDate.ToString());

            using (var dbContext = new NewsDbContext())
            {
                var newsFromDb = dbContext.News.FirstOrDefault();
                Assert.IsNotNull(newsFromDb);
                Assert.AreEqual(returnedNews.Id, newsFromDb.Id);
                Assert.AreEqual(returnedNews.Title, newsFromDb.Title);
                Assert.AreEqual(returnedNews.PublishDate.ToString(), newsFromDb.PublishDate.ToString());
                Assert.AreEqual(returnedNews.Content, newsFromDb.Content);
            }
        }

        [TestMethod]
        public void TestAddInvalidNews()
        {
            ClearNews();
            var postContent = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("title", "No Content")
            });

            var httpResponse = this.httpClient.PostAsync("/api/news", postContent).Result;
            Assert.AreEqual(HttpStatusCode.BadRequest, httpResponse.StatusCode);
            Assert.IsNull(httpResponse.Headers.Location);

            using (var dbContext = new NewsDbContext())
            {
                var newsFromDb = dbContext.News.FirstOrDefault();
                Assert.IsNull(newsFromDb);
            }
        }

        [TestMethod]
        public void TestModifyValidNews()
        {
            ClearNews();
            var news = new News { Title = "Zaglavie", Content = "tralala123" };
            using (var dbContext = new NewsDbContext())
            {
                dbContext.News.Add(news);
                dbContext.SaveChanges();
            }

            var postContent = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("title", "Changed Title"),
                new KeyValuePair<string, string>("content", "Changed Content")
            });

            var httpResponse = this.httpClient.PutAsync("/api/news/" + news.Id, postContent).Result;
            Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);

            var returnedNews = httpResponse.Content.ReadAsAsync<News>().Result;
            Assert.AreEqual(news.Id, returnedNews.Id);
            Assert.AreEqual("Changed Title", returnedNews.Title);
            Assert.AreEqual("Changed Content", returnedNews.Content);
            Assert.AreEqual(news.PublishDate.ToString(), returnedNews.PublishDate.ToString());

            using (var dbContext = new NewsDbContext())
            {
                var newsFromDb = dbContext.News.FirstOrDefault();
                Assert.IsNotNull(newsFromDb);
                Assert.AreEqual(returnedNews.Id, newsFromDb.Id);
                Assert.AreEqual(returnedNews.Title, newsFromDb.Title);
                Assert.AreEqual(returnedNews.PublishDate.ToString(), newsFromDb.PublishDate.ToString());
                Assert.AreEqual(returnedNews.Content, newsFromDb.Content);
            }
        }

        [TestMethod]
        public void TestModifyInvalidNews()
        {
            ClearNews();
            var news = new News { Title = "Zaglavie", Content = "tralala123" };
            using (var dbContext = new NewsDbContext())
            {
                dbContext.News.Add(news);
                dbContext.SaveChanges();
            }

            var postContent = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("content", "No Title")
            });

            var httpResponse = this.httpClient.PutAsync("/api/news/" + news.Id, postContent).Result;
            Assert.AreEqual(HttpStatusCode.BadRequest, httpResponse.StatusCode);

            using (var dbContext = new NewsDbContext())
            {
                var newsFromDb = dbContext.News.FirstOrDefault();
                Assert.IsNotNull(newsFromDb);
                Assert.AreEqual(news.Title, newsFromDb.Title);
                Assert.AreEqual(news.Content, newsFromDb.Content);
            }
        }

        [TestMethod]
        public void TestDeleteNews()
        {
            ClearNews();
            var news = new News { Title = "Zaglavie", Content = "tralala123" };
            using (var dbContext = new NewsDbContext())
            {
                dbContext.News.Add(news);
                dbContext.SaveChanges();
            }

            var httpResponse = this.httpClient.DeleteAsync("/api/news/" + news.Id).Result;
            Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);

            using (var dbContext = new NewsDbContext())
            {
                var newsFromDb = dbContext.News.FirstOrDefault();
                Assert.IsNull(newsFromDb);
            }
        }

        [TestMethod]
        public void TestDeleteUnexisingNews()
        {
            ClearNews();
            var httpResponse = this.httpClient.DeleteAsync("/api/news/100").Result;
            Assert.AreEqual(HttpStatusCode.BadRequest, httpResponse.StatusCode);
        }

        private static void ClearNews()
        {
            using (var dbContext = new NewsDbContext())
            {
                dbContext.News.Delete();
                dbContext.SaveChanges();
            }
        }

        private static void ClearUsers()
        {
            using (var dbContext = new NewsDbContext())
            {
                dbContext.Users.Delete();
                dbContext.SaveChanges();
            }
        }
    }
}
