using DemoQASeleniumProject.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace DemoQASeleniumProject.Pages
{
    public class ResizablePage : BasePage
    {
        public ResizablePage(IWebDriver driver) : base(driver) { }

        public By resizableBox = By.Id("resizableBoxWithWrapper");
        public By resizeHandle = By.XPath("//div[@id='resizableBoxWithWrapper']//span[contains(@class, 'react-resizable-handle')]");

        public void ResizeBoxByOffset(int xOffset, int yOffset)
        {
            IWebElement handle = driver.FindElement(resizeHandle);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", handle);
            Actions action = new Actions(driver);
            action.DragAndDropToOffset(handle, xOffset, yOffset).Perform();
        }

        public string GetBoxSize()
        {
            try
            {
                IWebElement box = driver.FindElement(resizableBox);
                return box.GetAttribute("style");
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}