using DemoQASeleniumProject.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace DemoQASeleniumProject.Pages
{
    public class CheckBoxPage : BasePage
    {
        public CheckBoxPage(IWebDriver driver) : base(driver) { }
        // Updated selectors for current demoqa.com/checkbox implementation using rc-tree widget
        public By closedSwitchers = By.CssSelector("span.rc-tree-switcher_close");
        public By homeCheckboxLabel = By.CssSelector("label[for='tree-node-home']");
        public By resultText = By.Id("result");

        public void ClickExpandAll()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Keep clicking closed switchers until all are expanded
            for (var guard = 0; guard < 35; guard++) // Max attempts to avoid infinite loop
            {
                try
                {
                    List<IWebElement> closedElements = new List<IWebElement>(
                        wait.Until(d => d.FindElements(closedSwitchers))
                    );

                    if (closedElements.Count == 0)
                        break;

                    IWebElement closedSwitcher = closedElements[0];
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", closedSwitcher);
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", closedSwitcher);
                    Thread.Sleep(200);
                }
                catch
                {
                    break;
                }
            }
        }

        public void SelectHomeCheckbox()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            // Use aria-label to find the Home checkbox in the rc-tree widget
            IWebElement checkbox = wait.Until(d => d.FindElement(By.CssSelector("span.rc-tree-checkbox[aria-label='Select Home']")));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", checkbox);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", checkbox);
        }
        public bool IsResultDisplayed()
        {
            try
            {
                return driver.FindElement(resultText).Displayed;
            }
            catch
            {
                return false;
            }
        }
    }
}