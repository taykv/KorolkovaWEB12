using System;
using Microsoft.AspNetCore.Mvc;
using Lab12.Model;

namespace Lab12.Controllers
{
    public class HomeController:Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ModelParsingSingleAction()
        {
            return View();
        }
        public IActionResult ModelParsingSeparateAction()
        {
            return View();
        }
        public IActionResult ModelBindingsParsing()
        {
            return View();
        }
        public IActionResult ModelBindingsSeparateModel()
        {
            return View();
        }

        public IActionResult ModParSingAction()
        {
            if (!Request.Method.Equals("POST", StringComparison.OrdinalIgnoreCase)) return View("Result");
            var value1 = Convert.ToInt32(Request.Form["First"]);
            var value2 = Convert.ToInt32(Request.Form["Second"]);
            var operation = Request.Form["Operation"];

            ViewBag.result = Calculate(value1, value2, operation);
            return View("Result");
        }

        [HttpGet]
        public IActionResult ModParSepAction()
        {
            return View("ModelParsingSeparateAction");
        }

        [HttpPost, ActionName("ModParSepAction")]
        public IActionResult ModParSepActionPost()
        {
            var value1 = Convert.ToInt32(Request.Form["First"]);
            var value2 = Convert.ToInt32(Request.Form["Second"]);
            var operation = Request.Form["Operation"];

            ViewBag.result = Calculate(value1, value2, operation);
            return View("Result");
        }

        [HttpPost]
        public IActionResult ModBindPar(int First, int Second, string Operation)
        {
            ViewBag.result = Calculate(First, Second, Operation);
            return View("Result");
        }

        [HttpPost]
        public IActionResult ModBindSepMod(Calculation calc)
        {   
            ViewBag.result = calc.Calculate();
            return View("Result");
        }

         public string Calculate(int First, int Second, string Operations)
        {
            var result = Operations switch
            {
                "+" => $"{First} + {Second} = {First + Second}",
                "-" => $"{First} - {Second} = {First - Second}",
                "*" => $"{First} * {Second} = {First * Second}",
                "/" => Second != 0 ? $"{First} / {Second} = {First / Second}" : "Division by 0",
                _ => "Invalid Operation."
            };
            return result;
        }

    }
}
