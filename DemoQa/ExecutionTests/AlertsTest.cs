using DemoQASeleniumProject.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace DemoQASeleniumProject.Tests
{
    [TestClass]
    public class AlertsTest
    {
        public static IWebDriver driver;
        public AlertsPage alertsPage;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }
        [ClassCleanup]
        public static void ClassCleanup()
        {
            if (driver != null) { 
                driver.Quit();
                //driver.Dispose();
                //
                }
        }

        [TestInitialize]
        public void TestInitialize()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/alerts");
            alertsPage = new AlertsPage(driver);
        }

        [TestMethod]
        public void TestSimpleAlert()
        {
            alertsPage.ClickAlertButton();
            IAlert alert = driver.SwitchTo().Alert();
            string alertText = alert.Text;
            alert.Accept();
            Assert.IsFalse(string.IsNullOrEmpty(alertText), "Alert should have text!");
        }

        [TestMethod]
        public void TestTimerAlert()
        {
            alertsPage.ClickTimerAlertButton();
            Thread.Sleep(6000); // 5 seconds wait for timer alert
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
            Assert.IsTrue(true, "Timer alert handled successfully!");
        }

        [TestMethod]
        public void TestConfirmAlertDismiss()
        {
            alertsPage.ClickConfirmButton();
            IAlert alert = driver.SwitchTo().Alert();
            alert.Dismiss();
            string result = alertsPage.GetConfirmResultText();
            Assert.IsTrue(result.Contains("Cancel"), "Result should show Cancel action!");
        }

        [TestMethod]
        public void TestPromptAlertInput()
        {
            alertsPage.ClickPromptButton();
            IAlert alert = driver.SwitchTo().Alert();
            alert.SendKeys("Imran Ali");
            alert.Accept();
            string result = alertsPage.GetPromptResultText();
            Assert.IsTrue(result.Contains("Imran Ali"), "Result should display entered name!");
        }

        
    }
}