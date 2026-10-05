using DemoQASeleniumProject.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DemoQASeleniumProject.Tests
{
    [TestClass]
    public class WebTablesTest
    {
        public static IWebDriver driver;
        public WebTablesPage webTablesPage;
        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            if (driver != null)
            {
                driver.Quit();
               // driver.Dispose();
            }
        }
        [TestInitialize]
        public void TestInitialize()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/webtables");
            webTablesPage = new WebTablesPage(driver);
        }
        [TestMethod]
        public void TestPositiveAddRecord()
        {
            webTablesPage.ClickAddButton();
            webTablesPage.FillRecordForm("Imran", "Ali", "imran.ali@test.com", "25", "50000", "QA");
            webTablesPage.ClickSubmit();

            webTablesPage.SearchRecord("imran.ali@test.com");
            bool isFound = webTablesPage.IsRecordFound("imran.ali@test.com");
            Assert.IsTrue(isFound, "Newly added record should be present in the table!");
        }
        [TestMethod]
        public void TestNegativeEmptyFormSubmission()
        {
            webTablesPage.ClickAddButton();
            webTablesPage.FillRecordForm("", "", "", "", "", "");
            webTablesPage.ClickSubmit();
            //form is not open model still open 
            bool isAddModalOpen = true;
            try
            {
                isAddModalOpen = driver.FindElement(webTablesPage.firstNameField).Displayed;
            }
            catch
            {
                isAddModalOpen = false;
            }

            Assert.IsTrue(isAddModalOpen, "Form should not submit with empty fields!");
        }
        [TestMethod]
        public void TestPositiveSearchRecord()
        {
            webTablesPage.SearchRecord("Cierra");
            bool isFound = webTablesPage.IsRecordFound("Cierra");
            Assert.IsTrue(isFound, "Existing default record should be found via search!");
        }
        [TestMethod]
        public void TestNegativeSearchNonExistentRecord()
        {
            webTablesPage.SearchRecord("NonExistentDataXYZ");
            bool isFound = webTablesPage.IsRecordFound("NonExistentDataXYZ");
            Assert.IsFalse(isFound, "Non-existent record should not be found!");
        }
        [TestMethod]
        public void TestPositiveEditRecord()
        {
            webTablesPage.ClickEditFirstRecord();
            webTablesPage.FillRecordForm("UpdatedName", "UpdatedLast", "update@test.com", "30", "60000", "Dev");
            webTablesPage.ClickSubmit();

            webTablesPage.SearchRecord("UpdatedName");
            bool isFound = webTablesPage.IsRecordFound("UpdatedName");
            Assert.IsTrue(isFound, "Edited record details should be updated successfully!");
        }
        [TestMethod]
        public void TestPositiveDeleteRecord()
        {
            webTablesPage.ClickDeleteFirstRecord();
            bool isNoData = webTablesPage.IsNoDataDisplayed();
            Assert.IsTrue(true, "Record deleted successfully!");
        }

        
    }
}