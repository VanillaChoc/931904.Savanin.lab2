using Microsoft.AspNetCore.Mvc;
using Web2._2.Models;
using Web2._2.Services;

namespace Web2._2.Controllers
{
    public class CalcController : Controller
    {
        public IActionResult Manual()
        {
            ViewData["Title"] = "Manual";

            if (Request.Method == "POST")
            {
                _ = int.TryParse(HttpContext.Request.Form["a"], out int a);
                _ = int.TryParse(HttpContext.Request.Form["b"], out int b);
                _ = int.TryParse(HttpContext.Request.Form["operation"], out int op);

                ViewData["Result"] = CalcService.DoCalculation(a, b, (Operation)op);
            }

            return View("MainForm");
        }

        [HttpGet]
        public IActionResult ManualWithSeparateHandlers()
        {
            ViewData["Title"] = "ManualWithSeparateHandlers";
            return View("MainForm");
        }

        [HttpPost]
        public IActionResult ManualWithSeparateHandlers(int? __)
        {
            ViewData["Title"] = "ManualWithSeparateHandlers";

            _ = int.TryParse(HttpContext.Request.Form["a"], out int a);
            _ = int.TryParse(HttpContext.Request.Form["b"], out int b);
            _ = int.TryParse(HttpContext.Request.Form["operation"], out int op);

            ViewData["Result"] = CalcService.DoCalculation(a, b, (Operation)op);

            return View("MainForm");
        }

        public IActionResult ModelBindingInParameters(int a, int b, Operation? operation)
        {
            ViewData["Title"] = "ModelBindingInParameters";
            ViewData["Result"] = CalcService.DoCalculation(a, b, operation);
            return View("MainForm");
        }

        public IActionResult ModelBindingInSeparateModel(CalcModel calcModel)
        {
            ViewData["Title"] = "ModelBindingInSeparateModel";
            ViewData["Result"] = calcModel.GetValue();
            return View("MainForm");
        }
    }
}
