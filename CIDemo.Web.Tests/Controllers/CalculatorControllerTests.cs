using System;
using System.Runtime.Remoting;
using System.Web.Mvc;
using CIDemo.Business;
using CIDemo.Web.Controllers;
using CIDemo.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CIDemo.Web.Tests.Controllers
{
    [TestClass]
    public class CalculatorControllerTests
    {
        private Mock<IFibonacciCalculator> mockFibonacciCalculator;
        private CalculatorController target;

        [TestInitialize]
        public void TestInitialize()
        {
            mockFibonacciCalculator = new Mock<IFibonacciCalculator>();
            target = new CalculatorController(mockFibonacciCalculator.Object);
        }

        [TestMethod]
        public void Get_ReturnsViewModel_Test()
        {
            // Setup

            // Act
            var result = target.Index() as ViewResult;
            var model = result.Model as CalculatorViewModel;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(model);
            Assert.AreEqual(0, model.N);
            Assert.IsNull(model.Result);
        }

        [TestMethod]
        public void Post_WithValidN_Test()
        {
            // Setup
            var viewModel = new CalculatorViewModel
                            {
                                N = 1
                            };
            mockFibonacciCalculator.Setup(o => o.GetNthValue(1)).Returns("1").Verifiable();

            // Act
            var result = target.Index(viewModel) as ViewResult;
            viewModel = result.Model as CalculatorViewModel;

            // Assert
            mockFibonacciCalculator.Verify();
            Assert.IsNotNull(result);
            Assert.IsNotNull(viewModel);
            Assert.AreEqual(1, viewModel.N);
            Assert.AreEqual("1", viewModel.Result);
        }

        [TestMethod]
        public void Post_WithModelError_ClearsResult_Test()
        {
            // Setup
            var viewModel = new CalculatorViewModel
            {
                N = 100001,
                Result = "test"
            };
            target.ModelState.AddModelError("Test", "Some error message");

            // Act
            var result = target.Index(viewModel) as ViewResult;
            viewModel = result.Model as CalculatorViewModel;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(viewModel);
            Assert.AreEqual(100001, viewModel.N);
            Assert.AreEqual(string.Empty, viewModel.Result);
            mockFibonacciCalculator.Verify(o => o.GetNthValue(It.IsAny<int>()), Times.Never);
        }

        [TestMethod]
        public void Post_WithException_DisplaysError_Test()
        {
            // Setup
            var viewModel = new CalculatorViewModel
            {
                N = 1,
                Result = "1"
            };
            mockFibonacciCalculator.Setup(o => o.GetNthValue(It.IsAny<int>())).Throws(new Exception());

            // Act
            var result = target.Index(viewModel) as ViewResult;
            viewModel = result.Model as CalculatorViewModel;

            // Assert
            Assert.IsFalse(target.ModelState.IsValid);
            Assert.IsNotNull(result);
            Assert.IsNotNull(viewModel);
            Assert.AreEqual(1, viewModel.N);
            Assert.AreEqual("1", viewModel.Result);
        }
    }
}
