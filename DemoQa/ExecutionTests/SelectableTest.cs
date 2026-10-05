using DemoQASeleniumProject.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DemoQASeleniumProject.Tests
{
    [TestClass]
    public class SelectableTest
    {
        public static IWebDriver driver;
        public SelectablePage selectablePage;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/selectable");
            selectablePage = new SelectablePage(driver);
        }

        [TestMethod]
        public void TestPositiveSelectItem()
        {
            selectablePage.ClickListItem(0);
            bool isActive = selectablePage.IsItemActive(0);
            Assert.IsTrue(isActive, "Selected list item should become active!");
        }

        [TestMethod]
        public void TestNegativeItemNotActiveInitially()
        {
            bool isActive = selectablePage.IsItemActive(1);
            Assert.IsFalse(isActive, "List item should not be active initially before clicking!");
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            if (driver != null) { driver.Quit(); driver.Dispose(); }
        }
    }
}