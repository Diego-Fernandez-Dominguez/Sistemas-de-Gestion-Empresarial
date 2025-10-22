using _01_ViewBag.Models.Entities;

namespace _01_ViewBag.Models.DAL
{
    public class listadoPersonas
    {
        /// <summary>
        /// Devuelve una lista de personas hardcodeada
        /// pre: -
        /// post: none
        /// </summary>
        /// <returns></returns>
        public static List<clsPersona> getPersonas() { 

        return new List<clsPersona>
            {
                new clsPersona(1, "Ana", "Domínguez"),
                new clsPersona(2, "Juan", "Pérez"),
                new clsPersona(3, "Luis", "Martínez"),
                new clsPersona(4, "Marta", "López"),
                new clsPersona(5, "Carlos", "Sánchez"),
                new clsPersona(6, "Laura", "Fernández")

            };
        }
    }
}
