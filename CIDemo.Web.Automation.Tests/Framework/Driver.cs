using System;
using System.IO;
using System.Reflection;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;

namespace CIDemo.Web.Automation.Tests.Framework
{
    public static class Driver
    {
        private static readonly IWebDriver webDriver = CreateWebDriver();

        public static IWebDriver WebDriver
        {
            get { return webDriver; }
        }

        public static IJavaScriptExecutor JavaScriptExecutor
        {
            get
            {
                var javaScriptExecutor = WebDriver as IJavaScriptExecutor;
                if (javaScriptExecutor == null)
                {
                    throw new InvalidCastException("Cannot cast webdriver to IJavaScriptExecutor");
                }
                return javaScriptExecutor;
            }
        }

        public static void Goto(string url)
        {
            webDriver.Navigate().GoToUrl(url);
        }

        public static void Goto(Uri url)
        {
            Goto(url.ToString());
        }

        public static void Quit()
        {
            webDriver.Quit();
        }

        public static void Sleep(int milliseconds)
        {
            Thread.Sleep(milliseconds);
        }

        private static IWebDriver CreateWebDriver()
        {
            var options = new InternetExplorerOptions
            {
                // This setting is used to ignore the requirement that protected mode must
                // be set the same for all modes
                // See: https://code.google.com/p/selenium/wiki/InternetExplorerDriver#Required_Configuration
                IntroduceInstabilityByIgnoringProtectedModeSettings = true
            };
            var driverPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var driver = new InternetExplorerDriver(driverPath, options);

            // Configure the driver to wait up to 3 seconds for elements to appear
            driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 0, 3));

            return driver;
        }
    }
}