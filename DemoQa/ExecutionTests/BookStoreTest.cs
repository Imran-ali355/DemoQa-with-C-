//using DemoQASeleniumProject.Pages;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using System.Threading;

//namespace DemoQASeleniumProject.Tests
//{
//    [TestClass]
//    public class BookStoreE2ETest
//    {
//        public static IWebDriver driver;
//        public LoginPage loginPage;
//        public BooksPage booksPage;
//        public ProfilePage profilePage;

//        // Note: DemoQA par apna aik static test account manually ek baar register kar ke 
//        // uske credentials yahan update kar dein (e.g. Username: "ImranTestUser", Password: "Test@12345")
//        public string testUsername = "ImranTestUser";
//        public string testPassword = "Test@12345";

//        [ClassInitialize]
//        public static void ClassInitialize(TestContext context)
//        {
//            driver = new ChromeDriver();
//            driver.Manage().Window.Maximize();
//        }

//        [TestInitialize]
//        public void TestInitialize()
//        {
//            loginPage = new LoginPage(driver);
//            booksPage = new BooksPage(driver);
//            profilePage = new ProfilePage(driver);
//        }

//        // Full End-to-End Integration Test Flow
//        [TestMethod]
//        public void TestCompleteBookStoreEndToEndFlow()
//        {
//            // 1. Navigate to Login and Login with Test User
//            driver.Navigate().GoToUrl("https://demoqa.com/login");
//            loginPage.Login(testUsername, testPassword);
//            Thread.Sleep(3000);

//            // 2. Navigate to Profile and Verify Successful Login
//            driver.Navigate().GoToUrl("https://demoqa.com/profile");
//            string loggedUser = profilePage.GetLoggedInUserName();
//            Assert.AreEqual(testUsername, loggedUser, "Logged-in username should match the test user!");

//            // 3. Navigate to Book Store, Search Book, and Add to Collection
//            driver.Navigate().GoToUrl("https://demoqa.com/books");
//            booksPage.SearchForBook("Git Pocket Guide");
//            Thread.Sleep(2000);

//            booksPage.ClickBookTitle();
//            Thread.Sleep(2000);

//            booksPage.ClickAddToCollection();
//            Thread.Sleep(2000);

//            // Handle browser confirmation alert ("Book added to your collection.")
//            try
//            {
//                IAlert alert = driver.SwitchTo().Alert();
//                string alertText = alert.Text;
//                alert.Accept();
//                Assert.IsTrue(alertText.Contains("added"), "Alert should confirm book addition!");
//            }
//            catch
//            {
//                // Alert might already be accepted or handled
//            }

//            // 4. Navigate back to Profile and Verify Book Exists in Collection
//            driver.Navigate().GoToUrl("https://demoqa.com/profile");
//            Thread.Sleep(3000);

//            bool isBookAdded = profilePage.IsBookPresentInCollection();
//            Assert.IsTrue(isBookAdded, "The added book 'Git Pocket Guide' should be visible in the user profile collection!");
//        }

//        [ClassCleanup]
//        public static void ClassCleanup()
//        {
//            if (driver != null)
//            {
//                driver.Quit();
//                driver.Dispose();
//            }
//        }
//    }
//}


using DemoQASeleniumProject.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace DemoQASeleniumProject.Tests
{
    [TestClass]
    public class BookStoreActionsTest
    {
        public static IWebDriver driver;
        public LoginPage loginPage;
        public BooksPage booksPage;
        public ProfilePage profilePage;

        public string testUsername = "ImranTestUser";
        public string testPassword = "Test@12345"; // Apna password yahan enter karein

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
                driver.Dispose();
            }
        }

        [TestInitialize]
        public void TestInitialize()
        {
            loginPage = new LoginPage(driver);
            booksPage = new BooksPage(driver);
            profilePage = new ProfilePage(driver);
        }

        // 1. Test Case: Search and Add Book to Collection
        [TestMethod]
        public void Test1_AddBookToCollection()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/login");
            loginPage.LoginToApplication(testUsername, testPassword);
            Thread.Sleep(3000);

            driver.Navigate().GoToUrl("https://demoqa.com/books");
            booksPage.SearchForBook("Learning JavaScript Design Patterns");
            Thread.Sleep(2000);

            booksPage.ClickBookTitle();
            Thread.Sleep(2000);
            booksPage.ClickAddToCollection();
            Thread.Sleep(2500);

            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                alert.Accept();
            }
            catch { }

            driver.Navigate().GoToUrl("https://demoqa.com/profile");
            Thread.Sleep(2500);

            bool isPresent = profilePage.IsBookPresentInCollection();
            Assert.IsTrue(isPresent, "Book should be successfully added to the user profile collection!");
        }

        // 2. Test Case: Delete Specific Book from Profile Collection
        [TestMethod]
        public void Test2_DeleteSpecificBookFromProfile()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/login");
            loginPage.LoginToApplication(testUsername, testPassword);
            Thread.Sleep(3000);

            driver.Navigate().GoToUrl("https://demoqa.com/profile");
            Thread.Sleep(2000);

            // Specific book delete karna
            profilePage.DeleteSpecificBook();
            Thread.Sleep(3000);

            bool isPresent = profilePage.IsBookPresentInCollection();
            Assert.IsFalse(isPresent, "Book should be removed from profile after deletion!");
        }

        // 3. Test Case: Delete All Books from Profile (Profile clean karne ke liye)
        [TestMethod]
        public void Test3_DeleteAllBooksFromProfile()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/login");
            loginPage.LoginToApplication(testUsername, testPassword);
            Thread.Sleep(3000);

            // Pehle ek book add karte hain taake delete all test run ho sake
            driver.Navigate().GoToUrl("https://demoqa.com/books");
            booksPage.SearchForBook("Learning JavaScript Design Patterns");
            Thread.Sleep(2000);
            booksPage.ClickBookTitle();
            Thread.Sleep(2000);
            booksPage.ClickAddToCollection();
            Thread.Sleep(2500);
            try { driver.SwitchTo().Alert().Accept(); } catch { }

            // Profile par ja kar Delete All Books click karna
            driver.Navigate().GoToUrl("https://demoqa.com/profile");
            Thread.Sleep(2000);

            profilePage.ClickDeleteAllBooks();
            Thread.Sleep(1500);
            profilePage.ConfirmDeleteAllBooks();
            Thread.Sleep(3000);

            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                alert.Accept();
            }
            catch { }

            bool isPresent = profilePage.IsBookPresentInCollection();
            Assert.IsFalse(isPresent, "All books should be cleared from profile collection!");
        }


    }
}