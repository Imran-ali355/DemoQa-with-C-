using DemoQASeleniumProject.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Threading;

namespace DemoQASeleniumProject.Pages
{
    public class BrokenLinksPage : BasePage
    {
        public BrokenLinksPage(IWebDriver driver) : base(driver) { }
        public By validImage = By.XPath("//img[contains(@src, 'Toolsqa')]");
        public By brokenImage = By.CssSelector("img[src*='Toolsqa_1st.jpg']");
        public By validLink = By.LinkText("Click Here for Valid Link");
        public By brokenLink = By.LinkText("Click Here for Broken Link");
        public bool IsImageLoaded(By locator)
        {
            try
            {
                IWebElement img = driver.FindElement(locator);
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", img);

                // Wait for image to load - check both naturalWidth and complete properties
                int maxAttempts = 20;
                int currentAttempt = 0;

                while (currentAttempt < maxAttempts)
                {
                    // Get naturalWidth via JavaScript
                    long naturalWidth = (long)((IJavaScriptExecutor)driver).ExecuteScript(
                        "return arguments[0].naturalWidth;", img);

                    // Also check if image is complete (has finished loading)
                    bool isComplete = (bool)((IJavaScriptExecutor)driver).ExecuteScript(
                        "return arguments[0].complete;", img);

                    if (naturalWidth > 0 && isComplete)
                    {
                        return true;
                    }

                    // Wait a bit and retry
                    Thread.Sleep(500);
                    currentAttempt++;
                }

                return false;
            }
            catch (Exception ex)
            {
                // Log the exception for debugging
                System.Diagnostics.Debug.WriteLine($"Exception in IsImageLoaded: {ex.Message}");
                return false;
            }
        }

        public void ClickValidLink()
        {
            IWebElement link = driver.FindElement(validLink);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", link);
            link.Click();
        }

        public void ClickBrokenLink()
        {
            IWebElement link = driver.FindElement(brokenLink);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", link);
            link.Click();
        }

        public string GetBrokenLinkHref()
        {
            try
            {
                IWebElement link = driver.FindElement(brokenLink);
                return link.GetAttribute("href");
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}