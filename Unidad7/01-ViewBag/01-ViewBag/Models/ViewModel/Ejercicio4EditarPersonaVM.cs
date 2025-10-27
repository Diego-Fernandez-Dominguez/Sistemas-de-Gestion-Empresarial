using _01_ViewBag.Models.DAL;
using _01_ViewBag.Models.Entities;

namespace _01_ViewBag.Models.ViewModel
{
    public class Ejercicio4EditarPersonaVM
    {

        private clsPersona _persona;
        private List<clsDepartamento> _listadoDepartamentos;

        public clsPersona persona
        {
            get { return _persona; }
        }

        public List<clsDepartamento> departamentos
        {
            get { return _listadoDepartamentos; }
        }

        public Ejercicio4EditarPersonaVM(int posicion)
        {
            _persona = listadoPersonas.getPersonas()[posicion];
            _listadoDepartamentos = listadoDepartamentos.getDepartamentos();
        }

        public Ejercicio4EditarPersonaVM()
        {
            Random rand = new Random();
            int posicionPersona = rand.Next(listadoPersonas.getPersonas().Count);
            _persona = listadoPersonas.getPersonas()[posicionPersona];
            _listadoDepartamentos = listadoDepartamentos.getDepartamentos();
        }
    }
}
