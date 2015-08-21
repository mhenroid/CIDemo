using System;
using System.Diagnostics;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CIDemo.Business.Tests
{
    [TestClass]
    public class FastDoublingFibonacciStrategyTests
    {
        private IFibonacciStrategy target;

        [TestInitialize]
        public void TestInitialize()
        {
            target = new FastDoublingFibonacciStrategy();
        }

        [TestMethod]
        public void GetNthValue_0_Test()
        {
            // Setup

            // Act
            var result = target.GetNthValue(0);

            // Assert
            Assert.AreEqual("0", result);
        }

        [TestMethod]
        public void GetNthValue_1_Test()
        {
            // Setup

            // Act
            var result = target.GetNthValue(1);

            // Assert
            Assert.AreEqual("1", result);
        }

        [TestMethod]
        public void GetNthValue_2_Test()
        {
            // Setup

            // Act
            var result = target.GetNthValue(2);

            // Assert
            Assert.AreEqual("1", result);
        }

        [TestMethod]
        public void GetNthValue_3_Test()
        {
            // Setup

            // Act
            var result = target.GetNthValue(3);

            // Assert
            Assert.AreEqual("2", result);
        }
        
        [TestMethod]
        public void GetNthValue_50_Test()
        {
            // Setup

            // Act
            var result = target.GetNthValue(50);

            // Assert
            Assert.AreEqual("12586269025", result);
        }

        [TestMethod]
        public void GetNthValue_300_Test()
        {
            // Setup

            // Act
            var result = target.GetNthValue(300);

            // Assert
            Assert.AreEqual("222232244629420445529739893461909967206666939096499764990979600", result);
        }

        [TestMethod]
        public void GetNthValue_500_Test()
        {
            // Setup

            // Act
            var result = target.GetNthValue(500);

            // Assert
            Assert.AreEqual("139423224561697880139724382870407283950070256587697307264108962948325571622863290691557658876222521294125", result);
        }

        [TestMethod]
        public void xyzTest()
        {
            // Setup

            // Act
            var target1 = new FastDoublingFibonacciStrategy();
            var target2 = new IterativeFibonacciStrategy();
            for (int i = 0; i < 100000; i++)
            {
                Debug.WriteLine("Working on: " + i.ToString());
                var result1 = target1.GetNthValue(i);
                var result2 = target2.GetNthValue(i);
                Assert.AreEqual(result1, result2);
            }
            // Assert

        }
    }
}
