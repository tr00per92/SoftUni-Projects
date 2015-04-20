namespace BugTracker.UnitTests
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Web.Http;
    using System.Web.Http.Routing;

    using BugTracker.Data.Models;
    using BugTracker.Data.UnitOfWork;
    using BugTracker.RestServices.Controllers;
    using BugTracker.RestServices.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class EditBugUnitTestsWithMocking
    {
        private static Mock<IBugTrackerData> dataMock;

        [TestInitialize]
        public void TestInit()
        {
            dataMock = new Mock<IBugTrackerData>();
        }

        [TestMethod]
        public void EditUnexistingBug_ShouldReturnNotFound()
        {
            var controller = new BugsController(dataMock.Object);
            SetupController(controller, "Bugs");

            dataMock.Setup(data => data.Bugs.Find(It.IsAny<object>())).Returns(null as Bug);

            var updatedBug = new EditBugInputModel { Title = "New Title" };
            var result = controller.EditBug(2, updatedBug).ExecuteAsync(new CancellationToken()).Result;
            Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode);
        }

        [TestMethod]
        public void EditBugNoInputModel_ShouldReturnBadRequest()
        {
            var controller = new BugsController(dataMock.Object);
            SetupController(controller, "Bugs");

            var bugToEdit = new Bug
            {
                Title = "Bug4e Tuka",
                Description = "ne6to ne e nared",
                Status = BugStatus.InProgress,
                DateCreated = DateTime.Now
            };

            dataMock.Setup(data => data.Bugs.Find(It.IsAny<object>())).Returns(bugToEdit);

            var result = controller.EditBug(2, null).ExecuteAsync(new CancellationToken()).Result;
            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
        }

        [TestMethod]
        public void EditBugEmptyTitle_ShouldReturnBadRequest()
        {
            var controller = new BugsController(dataMock.Object);
            SetupController(controller, "Bugs");

            var bugToEdit = new Bug
            {
                Title = "Bug4e Tuka",
                Description = "ne6to ne e nared",
                Status = BugStatus.InProgress,
                DateCreated = DateTime.Now
            };

            dataMock.Setup(data => data.Bugs.Find(It.IsAny<object>())).Returns(bugToEdit);

            var updatedBug = new EditBugInputModel { Title = "", Description = "Updated." };
            var result = controller.EditBug(2, updatedBug).ExecuteAsync(new CancellationToken()).Result;
            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
        }

        [TestMethod]
        public void EditBugInvalidStatus_ShouldReturnBadRequest()
        {
            var controller = new BugsController(dataMock.Object);
            SetupController(controller, "Bugs");

            var bugToEdit = new Bug
            {
                Title = "Bug4e Tuka",
                Description = "ne6to ne e nared",
                Status = BugStatus.InProgress,
                DateCreated = DateTime.Now
            };

            dataMock.Setup(data => data.Bugs.Find(It.IsAny<object>())).Returns(bugToEdit);

            var updatedBug = new EditBugInputModel { Title = "Changed", Status = "Pesho" };
            var result = controller.EditBug(2, updatedBug).ExecuteAsync(new CancellationToken()).Result;
            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
        }

        [TestMethod]
        public void EditBugWithCorrectData()
        {
            var controller = new BugsController(dataMock.Object);
            SetupController(controller, "Bugs");

            var bugToEdit = new Bug
            {
                Id = 22,
                Title = "Bug4e Tuka",
                Description = "ne6to ne e nared",
                Status = BugStatus.InProgress,
                DateCreated = DateTime.Now
            };

            dataMock.Setup(data => data.Bugs.Find(It.IsAny<object>())).Returns(bugToEdit);

            var updatedBug = new EditBugInputModel { Title = "Changed", Description = "Zatvarqm", Status = "Closed" };
            var result = controller.EditBug(2, updatedBug).ExecuteAsync(new CancellationToken()).Result;
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            var resultContent = result.Content.ReadAsStringAsync().Result;
            Assert.IsTrue(resultContent.Contains("Bug #" + bugToEdit.Id + " patched."));
        }

        [TestMethod]
        public void EditBugDescriptionOnly()
        {
            var controller = new BugsController(dataMock.Object);
            SetupController(controller, "Bugs");

            var bugToEdit = new Bug
            {
                Id = 22,
                Title = "Bug4e Tuka",
                Description = "ne6to ne e nared",
                Status = BugStatus.InProgress,
                DateCreated = DateTime.Now
            };

            dataMock.Setup(data => data.Bugs.Find(It.IsAny<object>())).Returns(bugToEdit);

            var updatedBug = new EditBugInputModel { Description = "Zatvarqm" };
            var result = controller.EditBug(2, updatedBug).ExecuteAsync(new CancellationToken()).Result;
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            var resultContent = result.Content.ReadAsStringAsync().Result;
            Assert.IsTrue(resultContent.Contains("Bug #" + bugToEdit.Id + " patched."));
        }

        [TestMethod]
        public void EditBugTitleOnly()
        {
            var controller = new BugsController(dataMock.Object);
            SetupController(controller, "Bugs");

            var bugToEdit = new Bug
            {
                Id = 22,
                Title = "Bug4e Tuka",
                Description = "ne6to ne e nared",
                Status = BugStatus.InProgress,
                DateCreated = DateTime.Now
            };

            dataMock.Setup(data => data.Bugs.Find(It.IsAny<object>())).Returns(bugToEdit);

            var updatedBug = new EditBugInputModel { Title = "Changed" };
            var result = controller.EditBug(2, updatedBug).ExecuteAsync(new CancellationToken()).Result;
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            var resultContent = result.Content.ReadAsStringAsync().Result;
            Assert.IsTrue(resultContent.Contains("Bug #" + bugToEdit.Id + " patched."));
        }

        [TestMethod]
        public void EditBugStatusOnly()
        {
            var controller = new BugsController(dataMock.Object);
            SetupController(controller, "Bugs");

            var bugToEdit = new Bug
            {
                Id = 22,
                Title = "Bug4e Tuka",
                Description = "ne6to ne e nared",
                Status = BugStatus.InProgress,
                DateCreated = DateTime.Now
            };

            dataMock.Setup(data => data.Bugs.Find(It.IsAny<object>())).Returns(bugToEdit);

            var updatedBug = new EditBugInputModel { Status = "Closed" };
            var result = controller.EditBug(2, updatedBug).ExecuteAsync(new CancellationToken()).Result;
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            var resultContent = result.Content.ReadAsStringAsync().Result;
            Assert.IsTrue(resultContent.Contains("Bug #" + bugToEdit.Id + " patched."));
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
