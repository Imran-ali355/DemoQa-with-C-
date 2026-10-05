using DemoQASeleniumProject.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;

namespace DemoQASeleniumProject.Pages
{
    public class SortablePage : BasePage
    {
        public SortablePage(IWebDriver driver) : base(driver) { }

        public By listItems = By.XPath("//div[@id='demo-tabpane-list']//div[contains(@class, 'list-group-item')]");

        public void ReorderFirstItemToThird()
        {
            IList<IWebElement> items = driver.FindElements(listItems);
            if (items.Count >= 3)
            {
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", items[0]);
                Actions action = new Actions(driver);
                action.DragAndDrop(items[0], items[2]).Perform();
            }
        }

        public string GetFirstItemText()
        {
            try
            {
                IList<IWebElement> items = driver.FindElements(listItems);
                return items[0].Text;
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}