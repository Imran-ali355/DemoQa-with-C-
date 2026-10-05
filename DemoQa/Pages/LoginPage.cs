//using DemoQASeleniumProject.Base;
//using OpenQA.Selenium;

//namespace DemoQASeleniumProject.Pages
//{
//    public class LoginPage : BasePage
//    {
//        public LoginPage(IWebDriver driver) : base(driver) { }

//        public By userNameField = By.Id("userName");
//        public By passwordField = By.Id("password");
//        public By loginButton = By.Id("login");

//        public void Login(string userName, string password)
//        {
//            IWebElement userEl = driver.FindElement(userNameField);
//            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", userEl);
//            userEl.Clear();
//            userEl.SendKeys(userName);

//            IWebElement passEl = driver.FindElement(passwordField);
//            passEl.Clear();
//            passEl.SendKeys(password);

//            IWebElement loginBtn = driver.FindElement(loginButton);
//            loginBtn.Click();
//        }
//    }
//}

using DemoQASeleniumProject.Base;
using OpenQA.Selenium;

namespace DemoQASeleniumProject.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver) { }

        public By userNameField = By.Id("userName");
        public By passwordField = By.Id("password");
        public By loginButton = By.Id("login");

        public void LoginToApplication(string userName, string password)
        {
            IWebElement userEl = driver.FindElement(userNameField);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", userEl);
            userEl.Clear();
            userEl.SendKeys(userName);

            IWebElement passEl = driver.FindElement(passwordField);
            passEl.Clear();
            passEl.SendKeys(password);

            IWebElement loginBtn = driver.FindElement(loginButton);
            loginBtn.Click();
        }
    }
}