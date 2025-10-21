using _01_ViewBag.Models.Entities;

namespace _01_ViewBag.Models.DAL
{
    public class listadoPersonas
    {
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
