using DemoQASeleniumProject.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DemoQASeleniumProject.Tests
{
    [TestClass]
    public class RadioButtonTest
    {
        public static IWebDriver driver;
        public RadioButtonPage radioButtonPage;

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
               // driver.Dispose();
            }
        }
        [TestInitialize]
        public void TestInitialize()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/radio-button");
            radioButtonPage = new RadioButtonPage(driver);
        }
        [TestMethod]
        public void TestPositiveYesRadioButton()
        {
            radioButtonPage.ClickYesRadio();

            bool isDisplayed = radioButtonPage.IsSuccessTextDisplayed();
            Assert.IsTrue(isDisplayed, "Success text should be displayed!");
            Assert.AreEqual("Yes", radioButtonPage.GetSuccessText(), "Selected text should be 'Yes'!");
        }
        [TestMethod]
        public void TestPositiveImpressiveRadioButton()
        {
            radioButtonPage.ClickImpressiveRadio();

            bool isDisplayed = radioButtonPage.IsSuccessTextDisplayed();
            Assert.IsTrue(isDisplayed, "Success text should be displayed!");
            Assert.AreEqual("Impressive", radioButtonPage.GetSuccessText(), "Selected text should be 'Impressive'!");
        }
        [TestMethod]
        public void TestNegativeNoRadioIsDisabled()
        {
            bool isEnabled = radioButtonPage.IsNoRadioEnabled();
            Assert.IsFalse(isEnabled, "'No' radio button should be disabled!");
        }

       
        
    }
}