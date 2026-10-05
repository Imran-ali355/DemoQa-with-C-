

using DemoQASeleniumProject.Base;
using OpenQA.Selenium;

namespace DemoQASeleniumProject.Pages
{
    public class ProfilePage : BasePage
    {
        public ProfilePage(IWebDriver driver) : base(driver) { }

        public By userNameValue = By.Id("userName-value");
        public By bookInTable = By.XPath("//span[@id='see-book-Learning JavaScript Design Patterns']");
        public By deleteBookIcon = By.Id("delete-record-undefined"); // Ya trash icon locator
        public By deleteAllBooksButton = By.XPath("//button[text()='Delete All Books']");
        public By modalOkButton = By.Id("closeSmallModal-ok");

        public string GetLoggedInUserName()
        {
            try
            {
                return driver.FindElement(userNameValue).Text;
            }
            catch
            {
                return string.Empty;
            }
        }

        public bool IsBookPresentInCollection()
        {
            try
            {
                return driver.FindElement(bookInTable).Displayed;
            }
            catch
            {
                return false;
            }
        }

        public void DeleteSpecificBook()
        {
            try
            {
                // Trash / Delete icon click karna profile table mein
                IWebElement deleteIcon = driver.FindElement(By.XPath("//span[contains(@id, 'delete-record-')]"));
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", deleteIcon);
                deleteIcon.Click();

                // Confirmation modal OK button click karna
                IWebElement okBtn = driver.FindElement(modalOkButton);
                okBtn.Click();
            }
            catch { }
        }

        public void ClickDeleteAllBooks()
        {
            IWebElement deleteAllBtn = driver.FindElement(deleteAllBooksButton);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", deleteAllBtn);
            deleteAllBtn.Click();
        }

        public void ConfirmDeleteAllBooks()
        {
            try
            {
                IWebElement okBtn = driver.FindElement(modalOkButton);
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", okBtn);
                okBtn.Click();
            }
            catch { }
        }
    }
}