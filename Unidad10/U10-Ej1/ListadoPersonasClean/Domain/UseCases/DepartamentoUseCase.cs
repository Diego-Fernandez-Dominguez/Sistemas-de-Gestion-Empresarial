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

        /// <summary>
        /// <description>Obtiene la lista completa de departamentos.</description>
        /// <precondition>Ninguna</precondition>
        /// <postcondition>Devuelve todos los departamentos existentes.</postcondition>
        /// </summary>
        /// <returns>Lista de departamentos.</returns>
        public List<clsDepartamento> GetDepartamentos()
        {
            return _repositoryDepartamentos.getListaDepartamentos().ToList();
        }

        /// <summary>
        /// <description>Obtiene los detalles de un departamento específico por su ID.</description>
        /// <precondition>El ID del departamento debe ser válido (> 0).</precondition>
        /// <postcondition>Devuelve el departamento correspondiente o null si no se encuentra.</postcondition>
        /// </summary>
        /// <returns>Departamento correspondiente al ID proporcionado.</returns>
        public clsDepartamento GetDetalleDepartamento(int id)
        {
            return _repositoryDepartamentos.getDepartamentoPorID(id);
        }

        /// <summary>
        /// <description>Obtiene un departamento específico para edición.</description>
        /// <precondition>El ID del departamento debe ser válido (> 0).</precondition>
        /// <postcondition>Devuelve el departamento correspondiente para poder editar sus datos.</postcondition>
        /// </summary>
        /// <returns>Departamento listo para ser editado.</returns>
        public clsDepartamento GetDepartamentoParaEditar(int id)
        {
            return _repositoryDepartamentos.getDepartamentoPorID(id);
        }

        /// <summary>
        /// <description>Obtiene la lista de personas asignadas a un departamento específico.</description>
        /// <precondition>El ID del departamento debe ser válido (> 0).</precondition>
        /// <postcondition>Devuelve todas las personas que pertenecen al departamento indicado. La lista puede estar vacía si no hay personas asignadas.</postcondition>
        /// </summary>
        /// <returns>Lista de personas pertenecientes al departamento.</returns>
        public List<clsPersona> GetPersonasPorDepartamento(int id)
        {
            return _repositoryPersonas.getListaPersonas()
                .Where(p => p.idDepartamento == id)
                .ToList();
        }

        /// <summary>
        /// <description>Crea un nuevo departamento en el sistema.</description>
        /// <precondition>El objeto departamento debe tener propiedades válidas.</precondition>
        /// <postcondition>El departamento se agrega al repositorio de departamentos.</postcondition>
        /// </summary>
        public void CrearDepartamento(clsDepartamento departamento)
        {
            _repositoryDepartamentos.añadirDepartamento(departamento);
        }

        /// <summary>
        /// <description>Actualiza los datos de un departamento existente.</description>
        /// <precondition>El departamento debe existir y sus propiedades deben ser válidas.</precondition>
        /// <postcondition>Los datos del departamento se actualizan en el repositorio.</postcondition>
        /// </summary>
        public void ActualizarDepartamento(clsDepartamento departamento)
        {
            _repositoryDepartamentos.actualizarDepartamento(departamento.id, departamento);
        }

        /// <summary>
        /// <description>Elimina un departamento del sistema.</description>
        /// <precondition>El ID del departamento debe ser válido y no debe tener personas asignadas.</precondition>
        /// <postcondition>El departamento se elimina del repositorio si no tiene personas asignadas; de lo contrario, lanza una excepción.</postcondition>
        /// </summary>
        /// <exception cref="InvalidOperationException">Se lanza si el departamento tiene personas asignadas.</exception>
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
