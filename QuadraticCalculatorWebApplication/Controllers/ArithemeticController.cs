using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;

namespace QuadraticCalculatorWebApplication.Controllers
{
    public class ArithemeticController : Controller
    {
        [HttpGet]
        public ActionResult Quadratic()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Quadratic(string firstVariables, string secondVariables, string thirdVariables)
        {
            QuadraticFormula(firstVariables, secondVariables, thirdVariables);
            return View();
        }
        string QuadraticFormula(string firstVariable, string secondVariable, string thirdVariable)
        {
            double a = double.Parse(firstVariable);
            double b = double.Parse(secondVariable);
            double c = double.Parse(thirdVariable);
            double rootOne;
            double rootTwo;
            double cmplxRootOne;
            double cmplxRootTwo;

            double d = Math.Pow(b, 2) - 4 * a * c;
            if (d < 0)
            {
                cmplxRootOne = (-b / 2 * a) + Math.Sqrt(-d) / (2 * a);
                cmplxRootTwo = (-b / 2 * a) - Math.Sqrt(-d) / (2 * a);
                float cmplxOne = (float)cmplxRootOne;
                float cmplxTwo = (float)cmplxRootTwo;
                return ViewBag.Result = $"First complex root= {cmplxOne}, Second complex root= i{cmplxTwo}";
            }
            else
            {
                rootOne = -b + Math.Sqrt(d) / (2 * a);
                rootTwo = -b - Math.Sqrt(d) / (2 * a);
                float realOne = (float)rootOne;
                float realTwo = (float)rootTwo;
               return ViewBag.Result = $"First real root= {realOne}, Second real root= {realTwo}";
            }
        }
    }
}
