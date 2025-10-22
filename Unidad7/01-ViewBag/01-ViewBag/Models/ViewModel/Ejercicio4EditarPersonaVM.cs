using _01_ViewBag.Models.DAL;
using _01_ViewBag.Models.Entities;
using System.Security.Cryptography;

namespace _01_ViewBag.Models.ViewModel
{
    public class Ejercicio4EditarPersonaVM
    {

        private clsPersona _persona;
        private List<clsDepartamento> _listadoDepartamentos;

        public Ejercicio4EditarPersonaVM(int posicion)
        {
            _persona = listadoPersonas.getPersonas()[posicion];
            _listadoDepartamentos = listadoDepartamentos.getDepartamentos();
        }
    }
}
