using DemoQASeleniumProject.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DemoQASeleniumProject.Tests
{
    [TestClass]
    public class CheckBoxTest
    {
        public static IWebDriver driver;
        public CheckBoxPage checkBoxPage;
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
                //driver.Dispose();
            }
        }
        [TestInitialize]
        public void TestInitialize()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/checkbox");
            checkBoxPage = new CheckBoxPage(driver);
        }
        [TestMethod]
        public void TestPositiveSelectCheckBox()
        {
            checkBoxPage.ClickExpandAll();
            checkBoxPage.SelectHomeCheckbox();

            bool isDisplayed = checkBoxPage.IsResultDisplayed();
            Assert.IsTrue(isDisplayed, "Result should be displayed after selecting the checkbox!");
        }
        [TestMethod]
        public void TestNegativeCheckBoxNotSelectedInitially()
        {
            bool isDisplayed = checkBoxPage.IsResultDisplayed();
            Assert.IsFalse(isDisplayed, "Result should not be displayed before selecting any checkbox!");
        }
        
    }
}