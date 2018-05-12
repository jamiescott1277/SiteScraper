using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SiteScraper;
using SiteScraper.Controllers;
using SiteScraper.Http;
using SiteScraper.Models;
using SiteScraper.Repositories;
using Telerik.JustMock;

namespace SiteScraper.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [DeploymentItem(@"TestHtml.txt")]
        public HomeController GetHomeController()
        {
            var client = Mock.Create<IClient>();
            Mock.Arrange(() => client.GetContent(Arg.IsAny<Uri>())).Returns(testhtml);
            var repo = new SiteScraperRepository(client);
            var homeController = new HomeController(repo);
            return homeController;
        }

        [TestMethod]        
        public void Index_Post()
        {
            // Arrange
            var controller = GetHomeController();

            // Act
            var result = controller.Index(new ScrapedModel() { Url = "http://www.test.com" }) as ViewResult;
            var model = result.Model as ScrapedModel;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, model.ImageUrls.Count);
            Assert.AreEqual(54, model.WordCount);
            Assert.AreEqual("test (4)", model.Top10Words.FirstOrDefault());
        }

        private readonly string testhtml = "<html><head></head><body><script language=\"javascript\">var i = 0;</script><h1>Testing</h1><div>This is a test.  Test is the most used word.  Test is now being used 3 times, so let's actually run the test now!</div><img src=\"http://www.test.com/image1.jpg\" /><img src=\"//www.test.com/image2.jpg\" /><img src=\"/image3.jpg\" /></body></html>";
    }
}
