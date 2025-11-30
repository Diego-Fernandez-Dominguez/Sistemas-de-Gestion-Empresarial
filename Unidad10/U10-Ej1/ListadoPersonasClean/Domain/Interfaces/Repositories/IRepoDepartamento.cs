using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IRepoDepartamento
    {
        public List<clsDepartamento> getListaDepartamentos();

        public clsDepartamento getDepartamentoPorID(int departamentoID);

        public int añadirDepartamento(clsDepartamento departamento);

        public int actualizarDepartamento(int idDepartamento, clsDepartamento departamento);

        public int eliminarDepartamento(int departamentoID);

    }
}
