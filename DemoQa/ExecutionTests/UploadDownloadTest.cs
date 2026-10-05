using DemoQASeleniumProject.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DemoQASeleniumProject.Tests
{
    [TestClass]
    public class UploadDownloadTest
    {
        public static IWebDriver driver;
        public UploadDownloadPage uploadDownloadPage;
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
            driver.Navigate().GoToUrl("https://demoqa.com/upload-download");
            uploadDownloadPage = new UploadDownloadPage(driver);
        }
        [TestMethod]
        public void TestPositiveFileUpload()
        {
            string systemFilePath = @"C:\Users\aliiaimr\Downloads\sampleFile (2).jpeg";
            uploadDownloadPage.UploadFile(systemFilePath);

            bool isDisplayed = uploadDownloadPage.IsUploadedPathDisplayed();
            Assert.IsTrue(isDisplayed, "Uploaded file path should be displayed after uploading!");

            string pathText = uploadDownloadPage.GetUploadedPathText();
            Assert.IsTrue(pathText.Contains("sampleFile"), "Uploaded path text should contain the uploaded file name!");
        }
        [TestMethod]
        public void TestFunctionalDownloadButton()
        {
            uploadDownloadPage.ClickDownloadButton();
            // Verify ke download button clickable aur enabled hai
            bool isEnabled = uploadDownloadPage.IsDownloadButtonEnabled();
            Assert.IsTrue(isEnabled, "Download button should be enabled and clickable!");
        }

        // Positive Test: Verify Upload Element is Displayed
        [TestMethod]
        public void TestPositiveUploadElementDisplayed()
        {
            bool isDisplayed = uploadDownloadPage.IsUploadFieldDisplayed();
            Assert.IsTrue(isDisplayed, "Upload file input field should be visible on the page!");
        }

        // Negative Test: Verify upload path is not displayed initially before uploading
        [TestMethod]
        public void TestNegativeInitialStateNoUploadPath()
        {
            bool isDisplayed = uploadDownloadPage.IsUploadedPathDisplayed();
            Assert.IsFalse(isDisplayed, "Uploaded file path should not be visible initially before uploading any file!");
        }

      
    }
}