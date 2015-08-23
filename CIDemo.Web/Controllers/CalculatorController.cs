using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CIDemo.Business;
using CIDemo.Web.Models;

namespace CIDemo.Web.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly IFibonacciCalculator calculator;

        public CalculatorController(IFibonacciCalculator calculator)
        {
            this.calculator = calculator;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var viewModel = new CalculatorViewModel();
            viewModel.N = 0;
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(CalculatorViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Result = string.Empty;
            }
            else
            {
                try
                {
                    viewModel.Result = this.calculator.GetNthValue(viewModel.N);
                }
                catch
                {
                    ModelState.AddModelError("Global", "An unexpected error occurred");
                }
            }

            return View(viewModel);
        }
    }
}