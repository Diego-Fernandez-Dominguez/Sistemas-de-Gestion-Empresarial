using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UI.Models;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Repositories;


namespace UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Domain.UseCases.GetListaPersonasUseCase _useCaseListaPersonas;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(_useCaseListaPersonas.getListaPersonas());
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
