using DemoQASeleniumProject.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace DemoQASeleniumProject.Pages
{
    public class DroppablePage : BasePage
    {
        public DroppablePage(IWebDriver driver) : base(driver) { }

        public By draggableBox = By.Id("draggable");
        public By droppableBox = By.Id("droppable");
        public By dropText = By.XPath("//div[@id='droppable']/p");

        public void PerformDragAndDrop()
        {
            IWebElement source = driver.FindElement(draggableBox);
            IWebElement target = driver.FindElement(droppableBox);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", source);

            Actions action = new Actions(driver);
            action.DragAndDrop(source, target).Perform();
        }

        public string GetDropStatusText()
        {
            try
            {
                return driver.FindElement(dropText).Text;
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}