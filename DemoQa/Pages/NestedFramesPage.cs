using DemoQASeleniumProject.Base;
using OpenQA.Selenium;

namespace DemoQASeleniumProject.Pages
{
    public class NestedFramesPage : BasePage
    {
        public NestedFramesPage(IWebDriver driver) : base(driver) { }

        public By parentFrameLocator = By.Id("frame1");
        public By childFrameLocator = By.TagName("iframe");
        public By bodyText = By.TagName("body");

        public string GetParentFrameText()
        {
            IWebElement parent = driver.FindElement(parentFrameLocator);
            driver.SwitchTo().Frame(parent);
            string text = driver.FindElement(bodyText).Text;
            driver.SwitchTo().DefaultContent();
            return text;
        }

        public string GetChildFrameText()
        {
            IWebElement parent = driver.FindElement(parentFrameLocator);
            driver.SwitchTo().Frame(parent);
            IWebElement child = driver.FindElement(childFrameLocator);
            driver.SwitchTo().Frame(child);
            string text = driver.FindElement(bodyText).Text;
            driver.SwitchTo().DefaultContent();
            return text;
        }
    }
}