using DemoQASeleniumProject.Base;
using OpenQA.Selenium;

namespace DemoQASeleniumProject.Pages
{
    public class UploadDownloadPage : BasePage
    {
        public UploadDownloadPage(IWebDriver driver) : base(driver) { }
        public By downloadButton = By.Id("downloadButton");
        public By uploadFileField = By.Id("uploadFile");
        public By uploadedFilePath = By.Id("uploadedFilePath");

        // Public Actions
        public void ClickDownloadButton()
        {
            IWebElement downloadBtn = driver.FindElement(downloadButton);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", downloadBtn);
            downloadBtn.Click();
        }

        public void UploadFile(string filePath)
        {
            IWebElement uploadInput = driver.FindElement(uploadFileField);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", uploadInput);
            uploadInput.SendKeys(filePath);
        }

        // Public Verification Methods
        public bool IsUploadedPathDisplayed()
        {
            try
            {
                return driver.FindElement(uploadedFilePath).Displayed;
            }
            catch
            {
                return false;
            }
        }

        public string GetUploadedPathText()
        {
            try
            {
                return driver.FindElement(uploadedFilePath).Text;
            }
            catch
            {
                return string.Empty;
            }
        }

        public bool IsDownloadButtonEnabled()
        {
            try
            {
                return driver.FindElement(downloadButton).Enabled;
            }
            catch
            {
                return false;
            }
        }

        public bool IsUploadFieldDisplayed()
        {
            try
            {
                return driver.FindElement(uploadFileField).Displayed;
            }
            catch
            {
                return false;
            }
        }
    }
}