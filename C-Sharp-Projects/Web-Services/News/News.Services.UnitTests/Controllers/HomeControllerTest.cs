namespace News.Services.UnitTests.Controllers
{
    using System.Web.Mvc;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using News.Services.Controllers;

    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            var controller = new HomeController();
            var result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}
