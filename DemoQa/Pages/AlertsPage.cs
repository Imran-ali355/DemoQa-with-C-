using DemoQASeleniumProject.Base;
using OpenQA.Selenium;

namespace DemoQASeleniumProject.Pages
{
    public class AlertsPage : BasePage
    {
        public AlertsPage(IWebDriver driver) : base(driver) { }

        public By alertButton = By.Id("alertButton");
        public By timerAlertButton = By.Id("timerAlertButton");
        public By confirmButton = By.Id("confirmButton");
        public By promptButton = By.Id("promtButton");
        public By confirmResult = By.Id("confirmResult");
        public By promptResult = By.Id("promptResult");

        public void ClickAlertButton() => driver.FindElement(alertButton).Click();
        public void ClickTimerAlertButton() => driver.FindElement(timerAlertButton).Click();
        public void ClickConfirmButton() => driver.FindElement(confirmButton).Click();
        public void ClickPromptButton() => driver.FindElement(promptButton).Click();

        public string GetConfirmResultText() => driver.FindElement(confirmResult).Text;
        public string GetPromptResultText() => driver.FindElement(promptResult).Text;
    }
}