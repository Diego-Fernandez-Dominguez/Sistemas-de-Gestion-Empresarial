using System.Diagnostics;
using _01_Formulario.Models;
using Microsoft.AspNetCore.Mvc;

namespace _01_Formulario.Controllers
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
            return View();
        }
        [HttpPost]
        public IActionResult Index(clsPersona persona)
        {
            ViewBag.Nombre = persona.nombre;
            return View();
        }

        public IActionResult Saludo(String nombre)
        {
            ViewBag.Nombre = nombre;
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
