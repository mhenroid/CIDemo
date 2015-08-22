using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CIDemo.Web.Models;

namespace CIDemo.Web.Controllers
{
    public class CalculatorController : Controller
    {
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
            viewModel.Result = "Test 123";
            return View(viewModel);
        }
    }
}