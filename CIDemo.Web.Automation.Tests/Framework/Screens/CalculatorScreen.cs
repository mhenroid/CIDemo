using CIDemo.Web.Automation.Tests.Framework.Controls;
using OpenQA.Selenium;

namespace CIDemo.Web.Automation.Tests.Framework.Screens
{
    public class CalculatorScreen
    {
        private Control nTextBox;
        private Control submitButton;
        private Control resultTextBox;

        public CalculatorScreen()
        {
            nTextBox = new Control(By.Name("N"));
            submitButton = new Control(By.Id("submitButton"));
            resultTextBox = new Control(By.Id("result"));
        }

        public void Goto()
        {
            Driver.Goto("http://localhost:16552/Calculator");
        }

        public string NValue
        {
            get { return nTextBox.Text; }
            set { nTextBox.SetTextValue(value);}
        }

        public void Submit()
        {
            submitButton.Submit();
            submitButton.Submit();
        }

        public string Result
        {
            get { return resultTextBox.Text; }
            set { resultTextBox.SetTextValue(value);}
        }
    }
}