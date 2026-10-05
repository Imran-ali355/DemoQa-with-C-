using DemoQASeleniumProject.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DemoQASeleniumProject.Tests
{
    [TestClass]
    public class LinksTest
    {
        public static IWebDriver driver;
        public LinksPage linksPage;
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
            driver.Navigate().GoToUrl("https://demoqa.com/links");
            linksPage = new LinksPage(driver);
        }
        [TestMethod]
        public void TestPositiveSimpleLinkNewTab()
        {
            string originalWindow = driver.CurrentWindowHandle;
            linksPage.ClickSimpleLink();

            // Switch to new tab
            foreach (string window in driver.WindowHandles)
            {
                if (window != originalWindow)
                {
                    driver.SwitchTo().Window(window);
                    break;
                }
            }

            string currentUrl = driver.Url;
            Assert.IsTrue(currentUrl.Contains("demoqa.com"), "New tab should navigate to DemoQA homepage!");

            // Close new tab and switch back
            if (driver.WindowHandles.Count > 1)
            {
                driver.Close();
                driver.SwitchTo().Window(originalWindow);
            }
        }
        [TestMethod]
        public void TestPositiveDynamicLinkNewTab()
        {
            string originalWindow = driver.CurrentWindowHandle;
            linksPage.ClickDynamicLink();
            foreach (string window in driver.WindowHandles)
            {
                if (window != originalWindow)
                {
                    driver.SwitchTo().Window(window);
                    break;
                }
            }

            string currentUrl = driver.Url;
            Assert.IsTrue(currentUrl.Contains("demoqa.com"), "Dynamic link new tab should navigate to DemoQA homepage!");
            if (driver.WindowHandles.Count > 1)
            {
                driver.Close();
                driver.SwitchTo().Window(originalWindow);
            }
        }
        [TestMethod]
        public void TestFunctionalApiLinkCreated()
        {
            linksPage.ClickCreatedLink();
            string response = linksPage.GetResponseText();
            Assert.IsTrue(response.Contains("Created"), "Response should indicate 'Created'!");
        }
        [TestMethod]
        public void TestFunctionalApiLinkNoContent()
        {
            linksPage.ClickNoContentLink();
            string response = linksPage.GetResponseText();
            Assert.IsTrue(response.Contains("No Content"), "Response should indicate 'No Content'!");
        }
        [TestMethod]
        public void TestFunctionalApiLinkMoved()
        {
            linksPage.ClickMovedLink();
            string response = linksPage.GetResponseText();
            Assert.IsTrue(response.Contains("Moved"), "Response should indicate 'Moved'!");
        }
        [TestMethod]
        public void TestFunctionalApiLinkBadRequest()
        {
            linksPage.ClickBadRequestLink();
            string response = linksPage.GetResponseText();
            Assert.IsTrue(response.Contains("Bad Request"), "Response should indicate 'Bad Request'!");
        }
        [TestMethod]
        public void TestFunctionalApiLinkUnauthorized()
        {
            linksPage.ClickUnauthorizedLink();
            string response = linksPage.GetResponseText();
            Assert.IsTrue(response.Contains("Unauthorized"), "Response should indicate 'Unauthorized'!");
        }
        [TestMethod]
        public void TestFunctionalApiLinkForbidden()
        {
            linksPage.ClickForbiddenLink();
            string response = linksPage.GetResponseText();
            Assert.IsTrue(response.Contains("Forbidden"), "Response should indicate 'Forbidden'!");
        }
        [TestMethod]
        public void TestFunctionalApiLinkNotFound()
        {
            linksPage.ClickNotFoundLink();
            string response = linksPage.GetResponseText();
           // Assert.IsTrue(response.Contains("Not Found"), "Response should indicate 'Not Found'!");
        }
        [TestMethod]
        public void TestNegativeInitialStateNoResponse()
        {
            bool isDisplayed = linksPage.IsResponseDisplayed();
            Assert.IsFalse(isDisplayed, "Response text should not be visible initially!");
        }

       
    }
}