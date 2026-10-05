using DemoQASeleniumProject.Base;
using OpenQA.Selenium;

namespace DemoQASeleniumProject.Pages
{
    public class BrowserWindowsPage : BasePage
    {
        public BrowserWindowsPage(IWebDriver driver) : base(driver) { }

        public By newTabButton = By.Id("tabButton");
        public By newWindowButton = By.Id("windowButton");
        public By sampleHeading = By.Id("sampleHeading");

        public void ClickNewTab()
        {
            IWebElement btn = driver.FindElement(newTabButton);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", btn);
            btn.Click();
        }

        public void ClickNewWindow()
        {
            IWebElement btn = driver.FindElement(newWindowButton);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", btn);
            btn.Click();
        }

        public string GetSampleHeadingText()
        {
            try
            {
                return driver.FindElement(sampleHeading).Text;
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}