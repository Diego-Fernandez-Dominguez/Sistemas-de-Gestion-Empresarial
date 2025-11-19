using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UI.Models;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Repositories;
using Domain.UseCases;


namespace UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IGetListaPersonasUseCases _listaPersonasUseCase;

        public HomeController(ILogger<HomeController> logger, IGetListaPersonasUseCases useCases)
        {
            _logger = logger;
            _listaPersonasUseCase = useCases;
        }

        public IActionResult Index()
        {
            var personas = _listaPersonasUseCase.getListaPersonas();
            return View(personas);
        }

        public IActionResult Details(int id)
        {
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
