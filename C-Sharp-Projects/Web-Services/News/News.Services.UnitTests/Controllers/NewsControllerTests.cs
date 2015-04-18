namespace News.Services.UnitTests.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Web.Http;
    using System.Web.Http.Routing;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using News.Data;
    using News.Services.Controllers;
    using News.Services.Models;

    [TestClass]
    public class NewsControllerTests
    {
        private static Mock<IRepository<News>> repoMock;

        [TestInitialize]
        public void TestInit()
        {
            repoMock = new Mock<IRepository<News>>();
        }

        [TestMethod]
        public void TestListAll()
        {
            var controller = new NewsController(repoMock.Object);
            SetupController(controller, "News");

            var news = new[]
            {
                new News { Title = "Zaglavie", Content = "dadadada" },
                new News { Title = "Asdjoqwe", Content = "asodojk" }
            };

            repoMock.Setup(repo => repo.All()).Returns(news.AsQueryable());

            var result = controller.GetAll().ExecuteAsync(new CancellationToken()).Result;
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);

            var returnedNews = result.Content.ReadAsAsync<List<News>>().Result;
            Assert.AreEqual(2, returnedNews.Count);
            CollectionAssert.AreEquivalent(news, returnedNews);
        }

        [TestMethod]
        public void TestAddValidNews()
        {
            var controller = new NewsController(repoMock.Object);
            SetupController(controller, "News");

            var news = new List<News>
            {
                new News { Title = "Zaglavie", Content = "dadadada" },
                new News { Title = "Asdjoqwe", Content = "asodojk" }
            };

            repoMock.Setup(repo => repo.Add(It.IsAny<News>())).Callback((News n) => news.Add(n));

            var newNews = new NewsBindingModel { Title = "Teadsad", Content = "koko6ki" };
            var result = controller.AddNews(newNews).ExecuteAsync(new CancellationToken()).Result;

            Assert.AreEqual(HttpStatusCode.Created, result.StatusCode);
            Assert.AreEqual(newNews.Title, news.Last().Title);
            Assert.AreEqual(newNews.Content, news.Last().Content);
            Assert.IsNotNull(news.Last().PublishDate);
        }

        [TestMethod]
        public void TestAddInvalidNews()
        {
            var controller = new NewsController(repoMock.Object);
            SetupController(controller, "News");

            var invalidNews = new NewsBindingModel { Title = "No content" };

            // it's not the controller's job to validate - there is a validator
            controller.ModelState.AddModelError("Content", "Required");
            var result = controller.AddNews(invalidNews).ExecuteAsync(new CancellationToken()).Result;
            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
        }

        [TestMethod]
        public void TestModifyValidNews()
        {
            var controller = new NewsController(repoMock.Object);
            SetupController(controller, "News");

            var news = new News { Id = 18, Title = "Zaglavie", Content = "dadadada" };
            repoMock.Setup(repo => repo.Find(It.IsAny<object>())).Returns(news);

            var updatedNews = new NewsBindingModel { Title = "Zaglavie", Content = "Changed content" };
            var result = controller.UpdateNews(18, updatedNews).ExecuteAsync(new CancellationToken()).Result;
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            var returnedNews = result.Content.ReadAsAsync<News>().Result;
            Assert.AreEqual(updatedNews.Title, returnedNews.Title);
            Assert.AreEqual(updatedNews.Content, returnedNews.Content);
            Assert.AreEqual(news.Title, returnedNews.Title);
        }

        [TestMethod]
        public void TestModifyInvalidNews()
        {
            var controller = new NewsController(repoMock.Object);
            SetupController(controller, "News");

            var news = new News { Id = 18, Title = "Zaglavie", Content = "dadadada" };
            repoMock.Setup(repo => repo.Find(It.IsAny<object>())).Returns(news);

            var invalidNews = new NewsBindingModel { Content = "No title" };

            // it's not the controller's job to validate - there is a validator
            controller.ModelState.AddModelError("Title", "Required");
            var result = controller.UpdateNews(18, invalidNews).ExecuteAsync(new CancellationToken()).Result;
            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
        }

        [TestMethod]
        public void TestModifyUnexistingNews()
        {
            var controller = new NewsController(repoMock.Object);
            SetupController(controller, "News");

            repoMock.Setup(repo => repo.Find(It.IsAny<object>())).Returns(null as News);

            var updatedNews = new NewsBindingModel { Title = "Zaglavie", Content = "Changed content" };
            var result = controller.UpdateNews(18, updatedNews).ExecuteAsync(new CancellationToken()).Result;
            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
        }

        [TestMethod]
        public void TestDeleteValidNews()
        {
            var controller = new NewsController(repoMock.Object);
            SetupController(controller, "News");

            var news = new News { Title = "Zaglavie", Content = "dadadada" };
            repoMock.Setup(repo => repo.Find(It.IsAny<object>())).Returns(news);

            var result = controller.DeleteNews(22).ExecuteAsync(new CancellationToken()).Result;
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }

        [TestMethod]
        public void TestDeleteUnexistingNews()
        {
            var controller = new NewsController(repoMock.Object);
            SetupController(controller, "News");

            repoMock.Setup(repo => repo.Find(It.IsAny<object>())).Returns(null as News);

            var result = controller.DeleteNews(22).ExecuteAsync(new CancellationToken()).Result;
            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
        }

        private static void SetupController(ApiController controller, string controllerName)
        {
            controller.Request = new HttpRequestMessage { RequestUri = new Uri("http://sample-url.com") };

            controller.Configuration = new HttpConfiguration();
            controller.Configuration.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional });

            controller.RequestContext.RouteData = 
                new HttpRouteData(new HttpRoute(), new HttpRouteValueDictionary { { "controller", controllerName } });
        }
    }
}
