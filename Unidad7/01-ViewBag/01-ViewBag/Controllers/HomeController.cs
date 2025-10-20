using System.Diagnostics;
using _01_ViewBag.Models;
using _01_ViewBag.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace _01_ViewBag.Controllers
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
            var hora = DateTime.Now.Hour;
            string saludo;

            if (hora < 12)
            {
                saludo = "Buenos dias";
            }
            else if (hora < 20)
            {
                saludo = "Buenas tardes";
            }
            else
            {
                saludo = "Buenas noches";
            }

            ViewData["Saludo"] = saludo;

            ViewBag.Hora = DateTime.Now;

            clsPersona oPersona = new clsPersona();

            oPersona.id = 1;
            oPersona.nombre = "Diego Fernandez Dominguez";

            return View(oPersona);
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
