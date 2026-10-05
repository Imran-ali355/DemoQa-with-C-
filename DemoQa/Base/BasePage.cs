using OpenQA.Selenium;

namespace DemoQASeleniumProject.Base
{
    public class BasePage
    {
        public IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}