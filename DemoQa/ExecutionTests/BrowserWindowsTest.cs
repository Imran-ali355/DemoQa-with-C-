using DemoQASeleniumProject.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DemoQASeleniumProject.Tests
{
    [TestClass]
    public class BrowserWindowsTest
    {
        public static IWebDriver driver;
        public BrowserWindowsPage windowsPage;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }
        [ClassCleanup]
        public static void ClassCleanup()
        {
            if (driver != null) { driver.Quit(); driver.Dispose(); }
        }

        [TestInitialize]
        public void TestInitialize()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/browser-windows");
            windowsPage = new BrowserWindowsPage(driver);
        }

        [TestMethod]
        public void TestPositiveNewTab()
        {
            string originalWindow = driver.CurrentWindowHandle;
            windowsPage.ClickNewTab();

            foreach (string window in driver.WindowHandles)
            {
                if (window != originalWindow)
                {
                    driver.SwitchTo().Window(window);
                    break;
                }
            }

            string heading = windowsPage.GetSampleHeadingText();
            Assert.AreEqual("This is a sample page", heading, "New tab should load the sample page!");

            driver.Close();
            driver.SwitchTo().Window(originalWindow);
        }

        [TestMethod]
        public void TestPositiveNewWindow()
        {
            string originalWindow = driver.CurrentWindowHandle;
            windowsPage.ClickNewWindow();

            foreach (string window in driver.WindowHandles)
            {
                if (window != originalWindow)
                {
                    driver.SwitchTo().Window(window);
                    break;
                }
            }

            string heading = windowsPage.GetSampleHeadingText();
            Assert.AreEqual("This is a sample page", heading, "New window should load the sample page!");

            driver.Close();
            driver.SwitchTo().Window(originalWindow);
        }

       
    }
}