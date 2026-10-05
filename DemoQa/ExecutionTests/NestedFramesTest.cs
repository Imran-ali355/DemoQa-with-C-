using DemoQASeleniumProject.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DemoQASeleniumProject.Tests
{
    [TestClass]
    public class NestedFramesTest
    {
        public static IWebDriver driver;
        public NestedFramesPage nestedFramesPage;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }
        [ClassCleanup]
        public static void ClassCleanup()
        {
            if (driver != null) { driver.Quit(); driver.Dispose(); }
        }

        [TestInitialize]
        public void TestInitialize()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/nestedframes");
            nestedFramesPage = new NestedFramesPage(driver);
        }

        [TestMethod]
        public void TestParentFrameText()
        {
            string text = nestedFramesPage.GetParentFrameText();
            Assert.IsTrue(text.Contains("Parent frame"), "Parent frame should contain correct text!");
        }

        [TestMethod]
        public void TestChildFrameText()
        {
            string text = nestedFramesPage.GetChildFrameText();
            Assert.IsTrue(text.Contains("Child Iframe"), "Child frame should contain correct text!");
        }

       
    }
}