using DemoQASeleniumProject.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DemoQASeleniumProject.Tests
{
    [TestClass]
    public class ModalDialogsTest
    {
        public static IWebDriver driver;
        public ModalDialogsPage modalPage;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            if (driver != null) { driver.Quit(); driver.Dispose(); }
        }

        [TestInitialize]
        public void TestInitialize()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/modal-dialogs");
            modalPage = new ModalDialogsPage(driver);
        }

        [TestMethod]
        public void TestSmallModalOpenAndClose()
        {
            modalPage.ClickSmallModalButton();
            bool isDisplayed = modalPage.IsSmallModalDisplayed();
            Assert.IsTrue(isDisplayed, "Small modal should be displayed!");
            modalPage.CloseSmallModal();
        }

        [TestMethod]
        public void TestLargeModalOpenAndClose()
        {
            modalPage.ClickLargeModalButton();
            bool isDisplayed = true;
            try
            {
                isDisplayed = driver.FindElement(By.Id("example-modal-sizes-title-lg")).Displayed;
            }
            catch
            {
                isDisplayed = false;
            }
            Assert.IsTrue(isDisplayed, "Large modal should be displayed!");
            modalPage.CloseLargeModal();
        }

    }
}