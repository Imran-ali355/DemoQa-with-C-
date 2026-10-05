using DemoQASeleniumProject.Base;
using OpenQA.Selenium;

namespace DemoQASeleniumProject.Pages
{
    public class FramesPage : BasePage
    {
        public FramesPage(IWebDriver driver) : base(driver) { }

        public By frame1 = By.Id("frame1");
        public By frame2 = By.Id("frame2");
        public By sampleHeading = By.Id("sampleHeading");

        public string GetHeadingInsideFrame(By frameLocator)
        {
            IWebElement frameElement = driver.FindElement(frameLocator);
            driver.SwitchTo().Frame(frameElement);
            string heading = driver.FindElement(sampleHeading).Text;
            driver.SwitchTo().DefaultContent();
            return heading;
        }
    }
}