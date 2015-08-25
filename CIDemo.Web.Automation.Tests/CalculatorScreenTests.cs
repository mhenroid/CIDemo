using System;
using CIDemo.Web.Automation.Tests.Framework;
using CIDemo.Web.Automation.Tests.Framework.Controls;
using CIDemo.Web.Automation.Tests.Framework.Screens;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace CIDemo.Web.Automation.Tests
{
    [TestClass]
    public class CalculatorScreenTests
    {
        [TestCleanup]
        public void TestCleanup()
        {
            Driver.Quit();
        }

        [TestMethod]
        public void GetFibonacci_ForN500_Test()
        {
            // Setup
            var expectedResult =
                "139423224561697880139724382870407283950070256587697307264108962948325571622863290691557658876222521294125";
            var screen = new CalculatorScreen();

            // Act
            screen.Goto();
            screen.NValue = "500";
            screen.Submit();
            var actualResult = screen.Result;

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
