////using DemoQASeleniumProject.Base;
////using OpenQA.Selenium;

////namespace DemoQASeleniumProject.Pages
////{
////    public class BooksPage : BasePage
////    {
////        public BooksPage(IWebDriver driver) : base(driver) { }

////        public By searchBox = By.Id("searchBox");
////        public By bookTitleLink = By.XPath("//span[@id='see-book-Git Pocket Guide']/a");
////        public By addToCollectionButton = By.XPath("//button[text()='Add To Your Collection']");

////        public void SearchForBook(string bookName)
////        {
////            IWebElement search = driver.FindElement(searchBox);
////            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", search);
////            search.Clear();
////            search.SendKeys(bookName);
////        }

////        public void ClickBookTitle()
////        {
////            IWebElement book = driver.FindElement(bookTitleLink);
////            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", book);
////            book.Click();
////        }

////        public void ClickAddToCollection()
////        {
////            IWebElement btn = driver.FindElement(addToCollectionButton);
////            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", btn);
////            btn.Click();
////        }
////    }
////}


//using DemoQASeleniumProject.Base;
//using OpenQA.Selenium;

//namespace DemoQASeleniumProject.Pages
//{
//    public class BooksPage : BasePage
//    {
//        public BooksPage(IWebDriver driver) : base(driver) { }

//        public By searchBox = By.Id("searchBox");
//        public By bookTitleLink = By.XPath("//span[@id='see-book-Learning JavaScript Design Patterns']/a");
//        public By addToCollectionButton = By.XPath("//button[text()='Add To Your Collection']");

//        public void SearchForBook(string bookName)
//        {
//            IWebElement search = driver.FindElement(searchBox);
//            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", search);
//            search.Clear();
//            search.SendKeys(bookName);
//        }

//        public void ClickBookTitle()
//        {
//            IWebElement book = driver.FindElement(bookTitleLink);
//            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", book);
//            book.Click();
//        }

//        public void ClickAddToCollection()
//        {
//            IWebElement btn = driver.FindElement(addToCollectionButton);
//            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", btn);
//            btn.Click();
//        }
//    }
//}