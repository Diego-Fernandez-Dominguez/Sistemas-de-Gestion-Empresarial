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
                new clsPersona(1, "Ana", "Domínguez",19, 1),
                new clsPersona(2, "Juan", "Pérez",18, 2),
                new clsPersona(3, "Luis", "Martínez",29, 3),
                new clsPersona(4, "Marta", "López",140, 4),
                new clsPersona(5, "Carlos", "Sánchez",11, 5),
                new clsPersona(6, "Laura", "Fernández",65, 6)

            };
        }
    }
}
