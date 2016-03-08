using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
//using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests {
    [TestFixture("firefox")]
    //[TestFixture("chrome")]
    [TestFixture("internet explorer")]
    public class MarcinNunit {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private bool acceptNextAlert = true;
        private string browser;

        public MarcinNunit(string browser) {
            this.browser = browser;
        }

        [SetUp]
        public void SetupTest() {
            switch (browser) {
                /*case "chrome":
                    driver = new ChromeDriver();
                    break;*/
                case "internet explorer":
                    InternetExplorerOptions options = new InternetExplorerOptions();
                    options.IgnoreZoomLevel = true;
                    //options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                    //options.EnsureCleanSession = true;
                    driver = new InternetExplorerDriver(options);
                    break;
                default:
                    driver = new FirefoxDriver();
                    break;
            }
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