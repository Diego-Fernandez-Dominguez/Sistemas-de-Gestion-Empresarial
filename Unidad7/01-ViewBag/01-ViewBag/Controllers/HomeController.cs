using _01_ViewBag.Models;
using _01_ViewBag.Models.DAL;
using _01_ViewBag.Models.Entities;
using _01_ViewBag.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;


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

            //Creacion de persona
            clsPersona oPersona = new clsPersona();
            oPersona.id = 1;
            oPersona.nombre = "Diego Fernandez Dominguez";


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

            return View(oPersona);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Ejercicio2()
        {
            List<clsPersona> personas = listadoPersonas.getPersonas();

            return View(personas);
        }

        public IActionResult Ejercicio3()
        {
            List<clsPersona> personas = listadoPersonas.getPersonas();
            clsPersona persona = personas[2];

            return View(persona);
        }

        public IActionResult Ejercicio4()
        {

            List<clsPersona> personas = listadoPersonas.getPersonas();

            var rand = new Random();

            int posicion = rand.Next(personas.Count);

            clsPersona personaAleatoria;

            personaAleatoria = personas[posicion];

            return View(personaAleatoria);
            
        }

        public IActionResult Ejercicio4Departamentos()
        {

            List<clsDepartamento> departamentos = listadoDepartamentos.getDepartamentos();

            return View(departamentos);

        }

        public IActionResult Ejercicio4EditarPersona()
        {

            Ejercicio4EditarPersonaVM vm = new Ejercicio4EditarPersonaVM();


            return View(vm);

        }

        [HttpPost]
        public IActionResult EditarPersona(clsPersona personaEditada)
        {
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}