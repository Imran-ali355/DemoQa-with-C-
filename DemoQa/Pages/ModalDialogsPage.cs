using DemoQASeleniumProject.Base;
using OpenQA.Selenium;

namespace DemoQASeleniumProject.Pages
{
    public class ModalDialogsPage : BasePage
    {
        public ModalDialogsPage(IWebDriver driver) : base(driver) { }

        public By smallModalButton = By.Id("showSmallModal");
        public By largeModalButton = By.Id("showLargeModal");
        public By smallModalCloseButton = By.Id("closeSmallModal");
        public By largeModalCloseButton = By.Id("closeLargeModal");
        public By modalTitle = By.Id("example-modal-sizes-title-sm");

        public void ClickSmallModalButton()
        {
            IWebElement btn = driver.FindElement(smallModalButton);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", btn);
            btn.Click();
        }

        public void ClickLargeModalButton()
        {
            IWebElement btn = driver.FindElement(largeModalButton);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", btn);
            btn.Click();
        }

        public void CloseSmallModal() => driver.FindElement(smallModalCloseButton).Click();
        public void CloseLargeModal() => driver.FindElement(largeModalCloseButton).Click();

        public bool IsSmallModalDisplayed()
        {
            try { return driver.FindElement(modalTitle).Displayed; }
            catch { return false; }
        }
    }
}