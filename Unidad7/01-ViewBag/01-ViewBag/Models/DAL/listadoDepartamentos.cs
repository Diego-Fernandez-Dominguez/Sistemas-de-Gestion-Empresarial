using _01_ViewBag.Models.Entities;

namespace _01_ViewBag.Models.DAL
{
    public class listadoDepartamentos
    {
        public static List<clsDepartamento> getDepartamentos()
        {
            return new List<clsDepartamento>
            {
                new clsDepartamento(1, "Recursos Humanos"),
                new clsDepartamento(2, "Informática"),
                new clsDepartamento(3, "Contabilidad"),
                new clsDepartamento(4, "Marketing"),
                new clsDepartamento(5, "Logística"),
                new clsDepartamento(6, "Atención al Cliente")
            };
        }
    }
}
