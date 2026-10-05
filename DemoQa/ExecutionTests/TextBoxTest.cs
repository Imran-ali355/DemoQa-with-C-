using DemoQASeleniumProject.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DemoQASeleniumProject.Tests
{
    [TestClass]
    public class TextBoxTest
    {
        public static IWebDriver driver;
        public TextBoxPage textBoxPage;
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
            driver.Navigate().GoToUrl("https://demoqa.com/text-box");
            textBoxPage = new TextBoxPage(driver);
        }
        [TestMethod]
        public void TestPositiveTextBoxSubmission()
        {
            textBoxPage.FillTextBoxForm("Imran Ali", "imran.ali@test.com", "Lahore, Pakistan", "Punjab, Pakistan");
            textBoxPage.ClickSubmit();

            bool isDisplayed = textBoxPage.IsOutputDisplayed();
            Assert.IsTrue(isDisplayed, "Output box should be displayed for valid data!");
        }
        [TestMethod]
        public void TestNegativeInvalidEmailTextBox()
        {
            textBoxPage.FillTextBoxForm("Imran Ali", "invalid-email-format", "Lahore, Pakistan", "Punjab, Pakistan");
            textBoxPage.ClickSubmit();

            bool isDisplayed = textBoxPage.IsOutputDisplayed();
            Assert.IsFalse(isDisplayed, "Output box should not appear for invalid email format!");
        }
        
    }
}