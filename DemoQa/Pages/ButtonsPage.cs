using DemoQASeleniumProject.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace DemoQASeleniumProject.Pages
{
    public class ButtonsPage : BasePage
    {
        public ButtonsPage(IWebDriver driver) : base(driver) { }
        public By doubleClickButton = By.Id("doubleClickBtn");
        public By rightClickButton = By.Id("rightClickBtn");
        public By dynamicClickButton = By.XPath("//button[text()='Click Me']");
        public By doubleClickMessage = By.Id("doubleClickMessage");
        public By rightClickMessage = By.Id("rightClickMessage");
        public By dynamicClickMessage = By.Id("dynamicClickMessage");
        public void PerformDoubleClick()
        {
            IWebElement btn = driver.FindElement(doubleClickButton);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", btn);

            // Simulate double-click using JavaScript to trigger the dblclick event
            string script = @"
                var event = new MouseEvent('dblclick', {
                    view: window,
                    bubbles: true,
                    cancelable: true,
                    clientX: 0,
                    clientY: 0
                });
                arguments[0].dispatchEvent(event);
            ";
            ((IJavaScriptExecutor)driver).ExecuteScript(script, btn);
            System.Threading.Thread.Sleep(500); // Wait for the action to be processed
        }

        public void PerformRightClick()
        {
            IWebElement btn = driver.FindElement(rightClickButton);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", btn);

            // Simulate right-click using JavaScript to trigger the contextmenu event
            string script = @"
                var event = new MouseEvent('contextmenu', {
                    view: window,
                    bubbles: true,
                    cancelable: true,
                    clientX: 0,
                    clientY: 0
                });
                arguments[0].dispatchEvent(event);
            ";
            ((IJavaScriptExecutor)driver).ExecuteScript(script, btn);
            System.Threading.Thread.Sleep(500); // Wait for the action to be processed
        }

        public void PerformDynamicClick()
        {
            IWebElement btn = driver.FindElement(dynamicClickButton);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", btn);
            btn.Click();
        }

        // Public Verification Methods
        public bool IsDoubleClickMessageDisplayed()
        {
            try
            {
                return driver.FindElement(doubleClickMessage).Displayed;
            }
            catch
            {
                return false;
            }
        }

        public bool IsRightClickMessageDisplayed()
        {
            try
            {
                return driver.FindElement(rightClickMessage).Displayed;
            }
            catch
            {
                return false;
            }
        }

        public bool IsDynamicClickMessageDisplayed()
        {
            try
            {
                return driver.FindElement(dynamicClickMessage).Displayed;
            }
            catch
            {
                return false;
            }
        }
    }
}