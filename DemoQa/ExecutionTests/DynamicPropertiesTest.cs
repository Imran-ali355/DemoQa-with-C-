using DemoQASeleniumProject.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace DemoQASeleniumProject.Tests
{
    [TestClass]
    public class DynamicPropertiesTest
    {
        public static IWebDriver driver;
        public DynamicPropertiesPage dynamicPropertiesPage;
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
            driver.Navigate().GoToUrl("https://demoqa.com/dynamic-properties");
            dynamicPropertiesPage = new DynamicPropertiesPage(driver);
        }
        [TestMethod]
        public void TestFunctionalEnableAfterButton()
        {
            // 5 seconds wait kyun ke button 5 seconds baad enable hota hai (No WebDriverWait used)
            Thread.Sleep(5000);

            bool isEnabled = dynamicPropertiesPage.IsEnableAfterButtonEnabled();
            Assert.IsTrue(isEnabled, "Button should be enabled after 5 seconds!");
        }

        // 2. Functional Test: Visible After 5 Seconds
        [TestMethod]
        public void TestFunctionalVisibleAfterButton()
        {
            // 5 seconds wait for the element to appear
            Thread.Sleep(5000);

            bool isDisplayed = dynamicPropertiesPage.IsVisibleAfterButtonDisplayed();
            Assert.IsTrue(isDisplayed, "Button should be visible after 5 seconds!");
        }
        [TestMethod]
        public void TestPositiveColorChangeButton()
        {
            string cssClass = dynamicPropertiesPage.GetColorChangeButtonClass();
            Assert.IsFalse(string.IsNullOrEmpty(cssClass), "Color change button should have CSS classes!");
        }

        // 4. Negative Test: Verify Visible After Button is not visible immediately on page load
        [TestMethod]
        public void TestNegativeVisibleAfterNotVisibleInitially()
        {
            bool isDisplayed = false;
            try
            {
                isDisplayed = driver.FindElement(dynamicPropertiesPage.visibleAfterButton).Displayed;
            }
            catch
            {
                isDisplayed = false;
            }
            Assert.IsFalse(isDisplayed, "Visible after button should not be displayed immediately before 5 seconds!");
        }

       
    }
}