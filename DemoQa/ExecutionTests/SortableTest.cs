using DemoQASeleniumProject.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DemoQASeleniumProject.Tests
{
    [TestClass]
    public class SortableTest
    {
        public static IWebDriver driver;
        public SortablePage sortablePage;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/sortable");
            sortablePage = new SortablePage(driver);
        }

        [TestMethod]
        public void TestFunctionalReorderListItems()
        {
            string initialFirst = sortablePage.GetFirstItemText();
            sortablePage.ReorderFirstItemToThird();
            string updatedFirst = sortablePage.GetFirstItemText();

            Assert.AreNotEqual(initialFirst, updatedFirst, "First item order should change after dragging!");
        }

        [TestMethod]
        public void TestPositiveSortablePageLoaded()
        {
            string firstItem = sortablePage.GetFirstItemText();
            Assert.IsFalse(string.IsNullOrEmpty(firstItem), "Sortable items should be displayed on the page!");
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            if (driver != null) { driver.Quit(); driver.Dispose(); }
        }
    }
}