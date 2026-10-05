using DemoQASeleniumProject.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DemoQASeleniumProject.Tests
{
    [TestClass]
    public class FormsTest
    {
        public static IWebDriver driver;
        public FormsPage formsPage;

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
                //driver.Dispose();
            }
        }


        [TestInitialize]
        public void TestInitialize()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");
            formsPage = new FormsPage(driver);
        }


        [TestMethod]
        public void TestPositiveStudentRegistrationForm()
        {
            formsPage.FillStudentForm("Imran", "Ali", "imran.ali@test.com", "3001234567", "Lahore, Pakistan");
            formsPage.ClickSubmit();
            bool isSuccess = formsPage.IsSubmissionSuccessful();
            Assert.IsTrue(isSuccess, "Form submission failed for valid data!");
        }


        [TestMethod]
        public void TestNegativeEmptyMandatoryFields()
        {

            formsPage.ClickSubmit();
            bool isSuccess = formsPage.IsSubmissionSuccessful();
            Assert.IsFalse(isSuccess, "Form should not submit with empty fields!");
        }


        [TestMethod]
        public void TestNegativeInvalidMobileNumber()
        {

            formsPage.FillStudentForm("Ali", "Khan", "ali@test.com", "123", "Karachi, Pakistan");
            formsPage.ClickSubmit();
            bool isSuccess = formsPage.IsSubmissionSuccessful();
            Assert.IsFalse(isSuccess, "Form should not submit with invalid mobile number!");
        }


        
    }
}