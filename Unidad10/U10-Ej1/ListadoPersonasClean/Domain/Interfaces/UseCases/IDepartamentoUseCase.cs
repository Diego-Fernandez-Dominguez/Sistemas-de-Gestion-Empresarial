using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.UseCases
{
    public interface IDepartamentoUseCase
    {
        List<clsDepartamento> GetDepartamentos();
        clsDepartamento GetDetalleDepartamento(int id);
        clsDepartamento GetDepartamentoParaEditar(int id);
        List<clsPersona> GetPersonasPorDepartamento(int id);
        void CrearDepartamento(clsDepartamento departamento);
        void ActualizarDepartamento(clsDepartamento departamento);
        void EliminarDepartamento(int id);
    }
}
