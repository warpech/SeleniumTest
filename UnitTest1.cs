using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTest {
    [TestFixture("firefox")]
    [TestFixture("chrome")]
    [TestFixture("internet explorer")]
    [TestFixture("edge")]
    public class MarcinNunit {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string browser;
        
        public MarcinNunit(string browser) {
            this.browser = browser;
        }

        [SetUp]
        public void SetupTest() {
            driver = WebDriverFactory.Create(this.browser);
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest() {
            try {
                driver.Quit();
            }
            catch (Exception) {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void PageLoads() {
            driver.Navigate().GoToUrl("http://warpech.github.io/SeleniumTest/wwwroot/regular.html");
            var html = driver.PageSource;
            StringAssert.Contains("<body", html);
        }

        [Test]
        public void BodyElementExists() {
            driver.Navigate().GoToUrl("http://warpech.github.io/SeleniumTest/wwwroot/regular.html");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until(driver => driver.FindElement(By.XPath("(//h1)[1]")));
            Assert.IsTrue(IsElementPresent(By.XPath("(//h1)[1]")));
        }

        [Test]
        public void Polyfill_PageLoads() {
            driver.Navigate().GoToUrl("http://warpech.github.io/SeleniumTest/wwwroot/webcomponents.html");
            var html = driver.PageSource;
            StringAssert.Contains("<body", html);
        }

        [Test]
        public void Polyfill_BodyElementExists() {
            driver.Navigate().GoToUrl("http://warpech.github.io/SeleniumTest/wwwroot/webcomponents.html");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until(driver => driver.FindElement(By.XPath("(//h1)[1]")));
            Assert.IsTrue(IsElementPresent(By.XPath("(//h1)[1]")));
        }

        private bool IsElementPresent(By by) {
            try {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException) {
                return false;
            }
        }
    }
}