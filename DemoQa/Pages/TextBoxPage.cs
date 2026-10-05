using DemoQASeleniumProject.Base;
using OpenQA.Selenium;

namespace DemoQASeleniumProject.Pages
{
    public class TextBoxPage : BasePage
    {
        public TextBoxPage(IWebDriver driver) : base(driver) { }

        public By fullNameField = By.Id("userName");
        public By emailField = By.Id("userEmail");
        public By currentAddressField = By.Id("currentAddress");
        public By permanentAddressField = By.Id("permanentAddress");
        public By submitButton = By.Id("submit");
        public By outputBox = By.Id("output");
        public void FillTextBoxForm(string fullName, string email, string currentAddress, string permanentAddress)
        {
            driver.FindElement(fullNameField).Clear();
            driver.FindElement(fullNameField).SendKeys(fullName);

            driver.FindElement(emailField).Clear();
            driver.FindElement(emailField).SendKeys(email);

            driver.FindElement(currentAddressField).Clear();
            driver.FindElement(currentAddressField).SendKeys(currentAddress);

            driver.FindElement(permanentAddressField).Clear();
            driver.FindElement(permanentAddressField).SendKeys(permanentAddress);
        }
        public void ClickSubmit()
        {
            IWebElement submitBtn = driver.FindElement(submitButton);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", submitBtn);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", submitBtn);
        }
        public bool IsOutputDisplayed()
        {
            try
            {
                return driver.FindElement(outputBox).Displayed;
            }
            catch
            {
                return false;
            }
        }
    }
}