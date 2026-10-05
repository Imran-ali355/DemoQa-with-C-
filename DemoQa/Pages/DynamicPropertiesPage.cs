using DemoQASeleniumProject.Base;
using OpenQA.Selenium;

namespace DemoQASeleniumProject.Pages
{
    public class DynamicPropertiesPage : BasePage
    {
        // Constructor
        public DynamicPropertiesPage(IWebDriver driver) : base(driver) { }

        // Public Locators
        public By enableAfterButton = By.Id("enableAfter");
        public By colorChangeButton = By.Id("colorChange");
        public By visibleAfterButton = By.Id("visibleAfter");

        // Public Actions & Methods
        public bool IsEnableAfterButtonEnabled()
        {
            try
            {
                return driver.FindElement(enableAfterButton).Enabled;
            }
            catch
            {
                return false;
            }
        }

        public string GetColorChangeButtonClass()
        {
            try
            {
                IWebElement btn = driver.FindElement(colorChangeButton);
                return btn.GetAttribute("class");
            }
            catch
            {
                return string.Empty;
            }
        }

        public bool IsVisibleAfterButtonDisplayed()
        {
            try
            {
                return driver.FindElement(visibleAfterButton).Displayed;
            }
            catch
            {
                return false;
            }
        }

        public void ClickEnableAfterButton()
        {
            IWebElement btn = driver.FindElement(enableAfterButton);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", btn);
            btn.Click();
        }

        public void ClickVisibleAfterButton()
        {
            IWebElement btn = driver.FindElement(visibleAfterButton);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", btn);
            btn.Click();
        }
    }
}