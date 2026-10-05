using System;
using DemoQASeleniumProject.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DemoQASeleniumProject.Pages
{
    public class LinksPage : BasePage
    {
        // Constructor
        public LinksPage(IWebDriver driver) : base(driver) { }
        public By simpleLink = By.Id("simpleLink");
        public By dynamicLink = By.Id("dynamicLink");
        public By createdLink = By.Id("created");
        public By noContentLink = By.Id("no-content");
        public By movedLink = By.Id("moved");
        public By badRequestLink = By.Id("bad-request");
        public By unauthorizedLink = By.Id("unauthorized");
        public By forbiddenLink = By.Id("forbidden");
        public By notFoundLink = By.Id("invalid-url");
        public By linkResponse = By.Id("linkResponse");
        public void ClickSimpleLink()
        {
            IWebElement link = driver.FindElement(simpleLink);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", link);
            link.Click();
        }

        public void ClickDynamicLink()
        {
            IWebElement link = driver.FindElement(dynamicLink);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", link);
            link.Click();
        }
        public void ClickCreatedLink()
        {
            IWebElement link = driver.FindElement(createdLink);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", link);
            link.Click();
        }

        public void ClickNoContentLink()
        {
            IWebElement link = driver.FindElement(noContentLink);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", link);
            link.Click();
        }

        public void ClickMovedLink()
        {
            IWebElement link = driver.FindElement(movedLink);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", link);
            link.Click();
        }

        public void ClickBadRequestLink()
        {
            IWebElement link = driver.FindElement(badRequestLink);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", link);
            link.Click();
        }

        public void ClickUnauthorizedLink()
        {
            IWebElement link = driver.FindElement(unauthorizedLink);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", link);
            link.Click();
        }

        public void ClickForbiddenLink()
        {
            IWebElement link = driver.FindElement(forbiddenLink);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", link);
            link.Click();
        }

        public void ClickNotFoundLink()
        {
            IWebElement link = driver.FindElement(notFoundLink);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", link);
            link.Click();
        }

        // Public Verification Methods
        public string GetResponseText()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(d =>
                {
                    try
                    {
                        IWebElement element = d.FindElement(linkResponse);
                        return element.Displayed && !string.IsNullOrEmpty(element.Text);
                    }
                    catch
                    {
                        return false;
                    }
                });
                return driver.FindElement(linkResponse).Text;
            }
            catch
            {
                return string.Empty;
            }
        }

        public bool IsResponseDisplayed()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(d =>
                {
                    try
                    {
                        IWebElement element = d.FindElement(linkResponse);
                        return element.Displayed;
                    }
                    catch
                    {
                        return false;
                    }
                });
                return driver.FindElement(linkResponse).Displayed;
            }
            catch
            {
                return false;
            }
        }
    }
}