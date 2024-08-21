using Microsoft.AspNetCore.Mvc;
using MVCDemo.Models;
using System.Diagnostics;

namespace MVCDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["greet"] = "Hello MVC Application";
            ViewBag.vbMSG = "Passing Message through the ViewBag";
            ViewData["vdMSG"] = "Passing Message through the ViewData";
            TempData["tdMSG"] = "Passing Message through the TempData";
            return View();
        }

        public IActionResult TDDemo()
        {
            ViewBag.vbTitle = "Trying to send VB to an action.";
            ViewData["vdTitle"] = "Trying to send VD to an action.";
            TempData["tdTitle"] = "Passing msg to View via action.";
            return RedirectToAction("TDDemo_One");
        }
        public IActionResult TDDemo_One()
        {
            string vb = ViewBag.vbTitle;

            string vd = (string)ViewData["vdTitle"];
            //string vd_1 = ViewData["vdTitle"].ToString();

            string td = (string)TempData["tdTitle"];
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
