using DemoQASeleniumProject.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DemoQASeleniumProject.Tests
{
    [TestClass]
    public class FramesTest
    {
        public static IWebDriver driver;
        public FramesPage framesPage;

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
            driver.Navigate().GoToUrl("https://demoqa.com/frames");
            framesPage = new FramesPage(driver);
        }

        [TestMethod]
        public void TestFrame1Content()
        {
            string heading = framesPage.GetHeadingInsideFrame(framesPage.frame1);
            Assert.AreEqual("This is a sample page", heading, "Frame 1 heading should match!");
        }

        [TestMethod]
        public void TestFrame2Content()
        {
            string heading = framesPage.GetHeadingInsideFrame(framesPage.frame2);
            Assert.AreEqual("This is a sample page", heading, "Frame 2 heading should match!");
        }

       
    }
}