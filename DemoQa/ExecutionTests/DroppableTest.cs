using DemoQASeleniumProject.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DemoQASeleniumProject.Tests
{
    [TestClass]
    public class DroppableTest
    {
        public static IWebDriver driver;
        public DroppablePage droppablePage;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/droppable");
            droppablePage = new DroppablePage(driver);
        }

        [TestMethod]
        public void TestPositiveDragAndDrop()
        {
            droppablePage.PerformDragAndDrop();
            string status = droppablePage.GetDropStatusText();
            Assert.AreEqual("Dropped!", status, "Drop area text should change to 'Dropped!' after successful drop!");
        }

        [TestMethod]
        public void TestNegativeInitialDropState()
        {
            string status = droppablePage.GetDropStatusText();
            Assert.AreEqual("Drop here", status, "Drop area should display 'Drop here' initially before dragging!");
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            if (driver != null) { driver.Quit(); driver.Dispose(); }
        }
    }
}