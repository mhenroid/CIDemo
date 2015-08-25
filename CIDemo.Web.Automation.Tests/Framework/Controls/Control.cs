using System;
using OpenQA.Selenium;

namespace CIDemo.Web.Automation.Tests.Framework.Controls
{
    public class Control
    {
        private readonly By selector;
        private readonly Control parentControl;

        public Control(By selector)
        {
            this.selector = selector;
        }

        public Control(By selector, Control parentControl)
        {
            this.selector = selector;
            this.parentControl = parentControl;
        }

        public void Click()
        {
            this.GetWebElement().Click();
        }

        public void Clear()
        {
            this.GetWebElement().Clear();
        }

        public bool Displayed
        {
            get
            {
                return this.GetWebElement().Displayed;
            }
        }

        public bool Enabled
        {
            get { return this.GetWebElement().Enabled; }
        }

        public string GetAttribute(string attributeName)
        {
            return this.GetWebElement().GetAttribute(attributeName);
        }

        public string GetCssValue(string propertyName)
        {
            return this.GetWebElement().GetCssValue(propertyName);
        }

        public System.Drawing.Point Location
        {
            get { return this.GetWebElement().Location; }
        }

        public bool Selected
        {
            get { return this.GetWebElement().Selected; }
        }

        public void SetTextValue(string text)
        {
            string script = string.Format("arguments[0].value = '{0}'", text);
            var javaScriptExecutor = Driver.WebDriver as IJavaScriptExecutor;
            if (javaScriptExecutor == null)
            {
                throw new InvalidCastException("Cannot cast webdriver to IJavaScriptExecutor");
            }
            javaScriptExecutor.ExecuteScript(script, this.GetWebElement());
        }

        public void SetInnerHtml(string value)
        {
            string script = string.Format("arguments[0].innerHTML = '{0}'", value);
            var javaScriptExecutor = Driver.WebDriver as IJavaScriptExecutor;
            if (javaScriptExecutor == null)
            {
                throw new InvalidCastException("Cannot cast webdriver to IJavaScriptExecutor");
            }
            javaScriptExecutor.ExecuteScript(script, this.GetWebElement());
        }

        public void SendKeys(string text)
        {
            this.GetWebElement().SendKeys(text);
        }

        public System.Drawing.Size Size
        {
            get { return this.GetWebElement().Size; }
        }

        public void Submit()
        {
            this.GetWebElement().Submit();
        }

        public string TagName
        {
            get { return this.GetWebElement().TagName; }
        }

        public string Text
        {
            get { return this.GetWebElement().Text; }
        }

        public string Value
        {
            get { return this.GetWebElement().GetAttribute("value"); }
        }

        public bool Exists
        {
            get
            {
                try
                {
                    this.GetWebElement();
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
                return true;
            }
        }

        protected IWebElement GetWebElement()
        {
            if (this.parentControl != null)
            {
                return this.parentControl.GetWebElement().FindElement(this.selector);
            }
            return Driver.WebDriver.FindElement(this.selector);
        }
    }
}