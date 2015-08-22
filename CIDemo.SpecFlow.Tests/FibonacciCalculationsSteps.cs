using System;
using System.Collections.Generic;
using System.Linq;
using CIDemo.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace CIDemo.SpecFlow.Tests
{
    [Binding]
    public class FibonacciCalculationsSteps
    {
        private IFibonacciCalculator calculator = new FibonacciCalculator();
        private int n;
        private string actualResult;
        private IEnumerable<FibonacciSequence> dataSequence;

        public class FibonacciSequence
        {
            public int N { get; set; }
            public string ExpectedResult { get; set; }
        }

        [Given(@"I enter (.*) into the Fibonacci calculator")]
        public void GivenIEnterIntoTheFibonacciCalculator(int n)
        {
            this.n = n;
        }

        [When(@"I submit")]
        public void WhenISubmit()
        {
            actualResult = calculator.GetNthValue(n);
        }

        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(string expectedResult)
        {
            Assert.AreEqual(expectedResult, actualResult);
        }
        
        [Given(@"the following set of data")]
        public void GivenTheFollowingSetOfData(Table table)
        {
            this.dataSequence = table.CreateSet<FibonacciSequence>();
        }
        
        [Given(@"I enter n into the Fibonacci calculator")]
        public void GivenIEnterNIntoTheFibonacciCalculator()
        {
            
        }
        
        [Then(@"the result should match Result")]
        public void ThenTheResultShouldMatchResult()
        {
            Assert.AreNotEqual(0, this.dataSequence.Count());
            foreach (var row in this.dataSequence)
            {
                var actualResult = calculator.GetNthValue(row.N);
                Assert.AreEqual(row.ExpectedResult, actualResult);
            }
        }
    }
}
