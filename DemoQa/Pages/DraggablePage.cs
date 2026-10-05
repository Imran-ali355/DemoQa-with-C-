using DemoQASeleniumProject.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Drawing;

namespace DemoQASeleniumProject.Pages
{
    public class DraggablePage : BasePage
    {
        public DraggablePage(IWebDriver driver) : base(driver) { }

        public By dragBox = By.Id("draggable");

        public void DragBoxByOffset(int x, int y)
        {
            IWebElement element = driver.FindElement(dragBox);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            Actions action = new Actions(driver);
            action.DragAndDropToOffset(element, x, y).Perform();
        }

        public Point GetDragBoxLocation()
        {
            try
            {
                IWebElement element = driver.FindElement(dragBox);
                return element.Location;
            }
            catch
            {
                return new Point(0, 0);
            }
        }
    }
}