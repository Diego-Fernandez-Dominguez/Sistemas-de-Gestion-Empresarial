using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IRepoPersona
    {
        public List<clsPersona> getListaPersonas();

        public clsPersona getPersonaPorID(int personaID);

        public int añadirPersona(clsPersona persona);

        public int actualizarPersona(clsPersona persona);

        public int eliminarPersona(int personaID);

        public int contarPersonasDepartamentos(int idDepartamento);

    }
}
