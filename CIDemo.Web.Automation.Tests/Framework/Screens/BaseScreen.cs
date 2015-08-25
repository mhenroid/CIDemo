using OpenQA.Selenium;

namespace CIDemo.Web.Automation.Tests.Framework.Screens
{
    public class BaseScreen
    {
        public IWebDriver WebDriver
        {
            get { return Driver.WebDriver; }
        }
    }
}