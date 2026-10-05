using DemoQASeleniumProject.Base;
using OpenQA.Selenium;

namespace DemoQASeleniumProject.Pages
{
    public class RadioButtonPage : BasePage
    {
        // Constructor
        public RadioButtonPage(IWebDriver driver) : base(driver) { }

        // Public Locators
        public By yesRadioButton = By.XPath("//label[@for='yesRadio']");
        public By impressiveRadioButton = By.XPath("//label[@for='impressiveRadio']");
        public By noRadioButton = By.Id("noRadio");
        public By successText = By.ClassName("text-success");

        // Public Actions
        public void ClickYesRadio()
        {
            IWebElement yesBtn = driver.FindElement(yesRadioButton);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", yesBtn);
            yesBtn.Click();
        }

        public void ClickImpressiveRadio()
        {
            IWebElement impressiveBtn = driver.FindElement(impressiveRadioButton);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", impressiveBtn);
            impressiveBtn.Click();
        }

        public bool IsSuccessTextDisplayed()
        {
            try
            {
                return driver.FindElement(successText).Displayed;
            }
            catch
            {
                return false;
            }
        }

        public string GetSuccessText()
        {
            try
            {
                return driver.FindElement(successText).Text;
            }
            catch
            {
                return string.Empty;
            }
        }

        public bool IsNoRadioEnabled()
        {
            try
            {
                return driver.FindElement(noRadioButton).Enabled;
            }
            catch
            {
                return false;
            }
        }
    }
}