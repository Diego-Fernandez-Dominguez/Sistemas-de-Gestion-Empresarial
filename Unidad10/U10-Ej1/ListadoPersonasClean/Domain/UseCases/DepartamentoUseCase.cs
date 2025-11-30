using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases
{
    public class DepartamentoUseCase : IDepartamentoUseCase
    {
        private readonly IRepoDepartamento _repositoryDepartamentos;
        private readonly IRepoPersona _repositoryPersonas;

        public DepartamentoUseCase(IRepoDepartamento repositoryDepartamentos, IRepoPersona repositoryPersonas)
        {
            _repositoryDepartamentos = repositoryDepartamentos;
            _repositoryPersonas = repositoryPersonas;
        }

        public List<clsDepartamento> GetDepartamentos()
        {
            return _repositoryDepartamentos.getListaDepartamentos().ToList();
        }

        public clsDepartamento GetDetalleDepartamento(int id)
        {
            return _repositoryDepartamentos.getDepartamentoPorID(id);
        }

        public clsDepartamento GetDepartamentoParaEditar(int id)
        {
            return _repositoryDepartamentos.getDepartamentoPorID(id);
        }

        public List<clsPersona> GetPersonasPorDepartamento(int id)
        {
            return _repositoryPersonas.getListaPersonas()
                .Where(p => p.idDepartamento == id)
                .ToList();
        }

        public void CrearDepartamento(clsDepartamento departamento)
        {
            _repositoryDepartamentos.añadirDepartamento(departamento);
        }

        public void ActualizarDepartamento(clsDepartamento departamento)
        {
            _repositoryDepartamentos.actualizarDepartamento(departamento.id, departamento);
        }

        public void EliminarDepartamento(int id)
        {
           
            int cantidadPersonas = _repositoryPersonas.contarPersonasDepartamentos(id);

            if (cantidadPersonas > 0)
            {
                throw new InvalidOperationException(
                    $"No se puede eliminar el departamento porque tiene {cantidadPersonas} persona(s) asignada(s)."
                );
            }

            _repositoryDepartamentos.eliminarDepartamento(id);
        }
    }
}
