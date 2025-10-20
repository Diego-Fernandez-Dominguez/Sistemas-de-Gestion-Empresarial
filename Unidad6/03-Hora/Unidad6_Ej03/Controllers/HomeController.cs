using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Unidad6_Ej03.Models;

namespace Unidad6_Ej03.Controllers
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
            var horaActual = DateTime.Now;
            ViewBag.Hora = horaActual.ToString("HH:mm");
            if (horaActual.Hour < 12)
                ViewBag.Mediodia = "Es mediodia";
            else
                ViewBag.Mediodia = "No es mediodia";

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
