using DemoQASeleniumProject.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace DemoQASeleniumProject.Pages
{
    public class WebTablesPage : BasePage
    {
        public WebTablesPage(IWebDriver driver) : base(driver) { }

        public By addNewRecordButton = By.Id("addNewRecordButton");
        public By firstNameField = By.Id("firstName");
        public By lastNameField = By.Id("lastName");
        public By emailField = By.Id("userEmail");
        public By ageField = By.Id("age");
        public By salaryField = By.Id("salary");
        public By departmentField = By.Id("department");
        public By submitButton = By.Id("submit");
        public By searchBox = By.Id("searchBox");
        public By editButtonFirstRow = By.Id("edit-record-1");
        public By deleteButtonFirstRow = By.Id("delete-record-1");
        public By noDataMessage = By.ClassName("rt-noData");

     
        public void ClickAddButton()
        {
            IWebElement addBtn = driver.FindElement(addNewRecordButton);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", addBtn);
            addBtn.Click();
        }

        public void FillRecordForm(string fName, string lName, string email, string age, string salary, string dept)
        {
            driver.FindElement(firstNameField).Clear();
            driver.FindElement(firstNameField).SendKeys(fName);

            driver.FindElement(lastNameField).Clear();
            driver.FindElement(lastNameField).SendKeys(lName);

            driver.FindElement(emailField).Clear();
            driver.FindElement(emailField).SendKeys(email);

            driver.FindElement(ageField).Clear();
            driver.FindElement(ageField).SendKeys(age);

            driver.FindElement(salaryField).Clear();
            driver.FindElement(salaryField).SendKeys(salary);

            driver.FindElement(departmentField).Clear();
            driver.FindElement(departmentField).SendKeys(dept);
        }

        public void ClickSubmit()
        {
            IWebElement submitBtn = driver.FindElement(submitButton);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", submitBtn);
            submitBtn.Click();
            // Wait for the modal to close and data to be added to table
            System.Threading.Thread.Sleep(500);
        }

        public void SearchRecord(string searchText)
        {
            IWebElement search = driver.FindElement(searchBox);
            search.Clear();
            search.SendKeys(searchText);
        }

        public bool IsRecordFound(string searchText)
        {
            try
            {
                System.Threading.Thread.Sleep(300);
                // Try multiple XPath strategies to find the record
                // First try: Look for the exact text in any element
                IWebElement element = driver.FindElement(By.XPath($"//*[contains(text(), '{searchText}')]"));
                return element.Displayed;
            }
            catch
            {
                return false;
            }
        }

        public void ClickEditFirstRecord()
        {
            IWebElement editBtn = driver.FindElement(editButtonFirstRow);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", editBtn);
            editBtn.Click();
        }

        public void ClickDeleteFirstRecord()
        {
            IWebElement deleteBtn = driver.FindElement(deleteButtonFirstRow);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", deleteBtn);
            deleteBtn.Click();
        }

        public bool IsNoDataDisplayed()
        {
            try
            {
                return driver.FindElement(noDataMessage).Displayed;
            }
            catch
            {
                return false;
            }
        }
    }
}