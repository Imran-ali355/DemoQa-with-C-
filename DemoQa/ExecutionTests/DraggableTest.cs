using DemoQASeleniumProject.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Drawing;

namespace DemoQASeleniumProject.Tests
{
    [TestClass]
    public class DraggableTest
    {
        public static IWebDriver driver;
        public DraggablePage draggablePage;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/draggable");
            draggablePage = new DraggablePage(driver);
        }

        [TestMethod]
        public void TestFunctionalDragBox()
        {
            Point initialLocation = draggablePage.GetDragBoxLocation();
            draggablePage.DragBoxByOffset(100, 50);
            Point updatedLocation = draggablePage.GetDragBoxLocation();

            Assert.AreNotEqual(initialLocation, updatedLocation, "Draggable box coordinates should change after dragging!");
        }

        [TestMethod]
        public void TestPositiveDraggableBoxDisplayed()
        {
            Point location = draggablePage.GetDragBoxLocation();
            Assert.IsNotNull(location, "Draggable box location should be retrievable!");
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            if (driver != null) { driver.Quit(); driver.Dispose(); }
        }
    }
}