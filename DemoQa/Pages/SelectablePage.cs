using DemoQASeleniumProject.Base;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace DemoQASeleniumProject.Pages
{
    public class SelectablePage : BasePage
    {
        public SelectablePage(IWebDriver driver) : base(driver) { }

        public By listItems = By.XPath("//ul[@id='verticalListContainer']/li");

        public void ClickListItem(int index)
        {
            IList<IWebElement> items = driver.FindElements(listItems);
            if (items.Count > index)
            {
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", items[index]);
                items[index].Click();
            }
        }

        public bool IsItemActive(int index)
        {
            try
            {
                IList<IWebElement> items = driver.FindElements(listItems);
                string className = items[index].GetAttribute("class");
                return className.Contains("active");
            }
            catch
            {
                return false;
            }
        }
    }
}