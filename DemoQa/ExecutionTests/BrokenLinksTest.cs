using DemoQASeleniumProject.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace DemoQASeleniumProject.Tests
{
    [TestClass]
    public class BrokenLinksTest
    {
        public static IWebDriver driver;
        public BrokenLinksPage brokenLinksPage;
        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }
        [ClassCleanup]
        public static void ClassCleanup()
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }
        }
        [TestInitialize]
        public void TestInitialize()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/broken");
            System.Threading.Thread.Sleep(2000); // Wait for page to load
            brokenLinksPage = new BrokenLinksPage(driver);
        }
        [TestMethod]
        public void TestPositiveValidImageLoaded()
        {
            bool isLoaded = brokenLinksPage.IsImageLoaded(brokenLinksPage.validImage);
            Assert.IsTrue(isLoaded, "Valid image should be loaded successfully!");
        }
        [TestMethod]
        public void TestNegativeBrokenImageNotLoaded()
        {
            bool isLoaded = brokenLinksPage.IsImageLoaded(brokenLinksPage.brokenImage);
            Assert.IsFalse(isLoaded, "Broken image should fail to load (naturalWidth should be 0)!");
        }
        [TestMethod]
        public void TestPositiveValidLinkNavigation()
        {
            brokenLinksPage.ClickValidLink();
            string currentUrl = driver.Url;

            // Verify ke valid link click hone par DemoQA homepage par navigate ho gaya
            Assert.IsTrue(currentUrl.Contains("demoqa.com"), "Valid link should navigate to DemoQA homepage!");
        }
        [TestMethod]
        public void TestFunctionalBrokenLinkDestination()
        {
            string hrefValue = brokenLinksPage.GetBrokenLinkHref();

            // Verify ke broken link ka target herokuapp status codes page hai jo 500 error deta hai
            Assert.IsTrue(hrefValue.Contains("status_codes/500"), "Broken link should point to the 500 status code URL!");
        }

       
    }
}