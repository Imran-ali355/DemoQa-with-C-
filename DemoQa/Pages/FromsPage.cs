using DemoQASeleniumProject.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace DemoQASeleniumProject.Pages
{
    public class FormsPage : BasePage
    {
        public FormsPage(IWebDriver driver) : base(driver) { }
        public By firstNameField = By.Id("firstName"); 
        public By lastNameField = By.Id("lastName");
        public By emailField = By.Id("userEmail");
        public By genderMaleRadio = By.XPath("//label[text()='Male']");
        public By mobileField = By.Id("userNumber");
        public By currentAddressField = By.Id("currentAddress");
        public By submitButton = By.Id("submit");
        public By successModalTitle = By.Id("example-modal-sizes-title-lg");


        public void FillStudentForm(string fName, string lName, string email, string mobile, string address)
        {
            driver.FindElement(firstNameField).Clear();
            driver.FindElement(firstNameField).SendKeys(fName);

            driver.FindElement(lastNameField).Clear();
            driver.FindElement(lastNameField).SendKeys(lName);

            driver.FindElement(emailField).Clear();
            driver.FindElement(emailField).SendKeys(email);

            driver.FindElement(genderMaleRadio).Click();

            driver.FindElement(mobileField).Clear();
            driver.FindElement(mobileField).SendKeys(mobile);

            driver.FindElement(currentAddressField).Clear();
            driver.FindElement(currentAddressField).SendKeys(address);
          
        }
        public void ClickSubmit()
        {
            IWebElement submitBtn = driver.FindElement(submitButton);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(false);", submitBtn);
            System.Threading.Thread.Sleep(500);
            try
            {
                submitBtn.Click();
            }
            catch (OpenQA.Selenium.ElementClickInterceptedException)
            {
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", submitBtn);
            }
        }

        public bool IsSubmissionSuccessful()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(d => 
                {
                    try
                    {
                        IWebElement modal = d.FindElement(successModalTitle);
                        return modal.Displayed;
                    }
                    catch
                    {
                        return false;
                    }
                });
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}