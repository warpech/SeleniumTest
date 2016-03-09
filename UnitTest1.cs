using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.IE;

namespace SeleniumTests {
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
            DesiredCapabilities capabilities;

            switch (this.browser) {
                case "chrome":
                    capabilities = DesiredCapabilities.Chrome();
                    driver = new RemoteWebDriver(capabilities);
                    break;
                case "internet explorer":
                    InternetExplorerOptions options = new InternetExplorerOptions();
                    options.IgnoreZoomLevel = true;
                    driver = new RemoteWebDriver(options.ToCapabilities());
                    break;
                case "edge":
                    capabilities = DesiredCapabilities.Edge();
                    driver = new RemoteWebDriver(capabilities);
                    break;
                default:
                    capabilities = DesiredCapabilities.Firefox();
                    driver = new RemoteWebDriver(capabilities);
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