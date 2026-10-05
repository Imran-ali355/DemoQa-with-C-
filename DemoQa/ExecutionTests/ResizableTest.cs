using DemoQASeleniumProject.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DemoQASeleniumProject.Tests
{
    [TestClass]
    public class ResizableTest
    {
        public static IWebDriver driver;
        public ResizablePage resizablePage;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/resizable");
            resizablePage = new ResizablePage(driver);
        }

        [TestMethod]
        public void TestFunctionalResizeBox()
        {
            string initialStyle = resizablePage.GetBoxSize();
            resizablePage.ResizeBoxByOffset(50, 50);
            string updatedStyle = resizablePage.GetBoxSize();

            Assert.AreNotEqual(initialStyle, updatedStyle, "Box dimensions should change after resizing!");
        }

        [TestMethod]
        public void TestPositiveResizableBoxDisplayed()
        {
            string style = resizablePage.GetBoxSize();
            Assert.IsFalse(string.IsNullOrEmpty(style), "Resizable box style attributes should be present!");
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            if (driver != null) { driver.Quit(); driver.Dispose(); }
        }
    }
}