using Microsoft.AspNetCore.Mvc;

namespace _01_HelloWorld.Controllers
{
    public class Filete : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Empanado()
        { 
            return View(); 
        }
    }
}
