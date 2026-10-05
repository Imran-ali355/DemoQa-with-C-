using DemoQASeleniumProject.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DemoQASeleniumProject.Tests
{
    [TestClass]
    public class ButtonsTest
    {
        public static IWebDriver driver;
        public ButtonsPage buttonsPage;
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
            driver.Navigate().GoToUrl("https://demoqa.com/buttons");
            buttonsPage = new ButtonsPage(driver);
        }
        [TestMethod]
        public void TestFunctionalDoubleClick()
        {
            buttonsPage.PerformDoubleClick();

            bool isDisplayed = buttonsPage.IsDoubleClickMessageDisplayed();
            Assert.IsTrue(isDisplayed, "Double click message should be displayed!");
        }
        [TestMethod]
        public void TestFunctionalRightClick()
        {
            buttonsPage.PerformRightClick();

            bool isDisplayed = buttonsPage.IsRightClickMessageDisplayed();
            Assert.IsTrue(isDisplayed, "Right click message should be displayed!");
        }
        [TestMethod]
        public void TestPositiveDynamicClick()
        {
            buttonsPage.PerformDynamicClick();

            bool isDisplayed = buttonsPage.IsDynamicClickMessageDisplayed();
            Assert.IsTrue(isDisplayed, "Dynamic click message should be displayed!");
        }
        [TestMethod]
        public void TestNegativeMessagesNotDisplayedInitially()
        {
            bool isDoubleClicked = buttonsPage.IsDoubleClickMessageDisplayed();
            bool isRightClicked = buttonsPage.IsRightClickMessageDisplayed();
            bool isDynamicClicked = buttonsPage.IsDynamicClickMessageDisplayed();

            Assert.IsFalse(isDoubleClicked, "Double click message should not be visible initially!");
            Assert.IsFalse(isRightClicked, "Right click message should not be visible initially!");
            Assert.IsFalse(isDynamicClicked, "Dynamic click message should not be visible initially!");
        }

       
    }
}