using Microsoft.AspNetCore.Mvc;

namespace MVCDemo.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
