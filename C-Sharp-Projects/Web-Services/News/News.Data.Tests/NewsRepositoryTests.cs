namespace News.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Transactions;
    using EntityFramework.Extensions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class NewsRepositoryTests
    {
        private static TransactionScope transaction;
        private static NewsRepository newsRepo;

        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            using (var newsDbContext = new NewsDbContext())
            {
                newsDbContext.Database.CreateIfNotExists();
            }
        }

        [TestInitialize]
        public void TestInit()
        {
            transaction = new TransactionScope();
            newsRepo = new NewsRepository();
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            newsRepo.Dispose();
            transaction.Dispose();
        }

        [TestMethod]
        public void TestListAll()
        {
            newsRepo.All().Delete();
            newsRepo.SaveChanges();
            CollectionAssert.AreEquivalent(new List<News>(), newsRepo.All().ToList());
            Assert.AreEqual(0, newsRepo.All().Count());

            var news1 = new News { Title = "Zaglavie", Content = "dadadada" };
            var news2 = new News { Title = "Teadsad", Content = "koko6ki" };
            var news3 = new News { Title = "Asdjoqwe", Content = "asodojk" };
            newsRepo.Add(news1);
            newsRepo.Add(news2);
            newsRepo.Add(news3);
            newsRepo.SaveChanges();

            CollectionAssert.AreEquivalent(new[] { news1, news2, news3 }, newsRepo.All().ToList());
            Assert.AreEqual(3, newsRepo.All().Count());
        }

        [TestMethod]
        public void TestAddValidNewsToDb()
        {
            var news = new News
            {
                Title = "Test News",
                Content = "This is very important"
            };

            newsRepo.Add(news);
            newsRepo.SaveChanges();

            var newsFromDb = newsRepo.Find(news.Id);

            Assert.IsNotNull(newsFromDb);
            Assert.AreEqual(news.Title, newsFromDb.Title);
            Assert.AreEqual(news.Content, newsFromDb.Content);
            Assert.AreEqual(news.PublishDate, newsFromDb.PublishDate);
            Assert.IsTrue(newsFromDb.Id != 0);
        }

        [TestMethod]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void TestAddInvalidNewsToDb()
        {
            newsRepo.Add(new News { Content = "No Title" });
            newsRepo.SaveChanges();
        }

        [TestMethod]
        public void TestModifyValidNews()
        {
            var news = new News
            {
                Title = "Test News",
                Content = "This is very important"
            };

            newsRepo.Add(news);
            newsRepo.SaveChanges();

            var newsFromDb = newsRepo.Find(news.Id);
            Assert.AreEqual("Test News", newsFromDb.Title);
            newsFromDb.Title = "Changed.";
            newsRepo.Update(newsFromDb);
            newsRepo.SaveChanges();
            Assert.AreEqual("Changed.", newsFromDb.Title);
        }

        [TestMethod]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void TestModifyInvalidNews()
        {
            var news = new News
            {
                Title = "Test News",
                Content = "This is very important"
            };

            newsRepo.Add(news);
            newsRepo.SaveChanges();

            var newsFromDb = newsRepo.Find(news.Id);
            Assert.AreEqual("Test News", newsFromDb.Title);
            newsFromDb.Title = null;
            newsRepo.Update(newsFromDb);
            newsRepo.SaveChanges();
        }

        [TestMethod]
        [ExpectedException(typeof(DbUpdateConcurrencyException))]
        public void TestModifyUnexistingNews()
        {
            var news = new News
            {
                Title = "Test News",
                Content = "This is very important"
            };

            newsRepo.Update(news);
            newsRepo.SaveChanges();
        }

        [TestMethod]
        public void TestDeleteValidNews()
        {
            var news = new News
            {
                Title = "Test News",
                Content = "This is very important"
            };

            newsRepo.Add(news);
            newsRepo.SaveChanges();

            Assert.IsNotNull(newsRepo.Find(news.Id));
            newsRepo.Delete(news.Id);
            newsRepo.SaveChanges();
            Assert.IsNull(newsRepo.Find(news.Id));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestDeleteUnexistingNews()
        {
            newsRepo.All().Delete();
            newsRepo.SaveChanges();

            newsRepo.Delete(2);
            newsRepo.SaveChanges();
        }
    }
}
