using Domain.Entities;
using Domain.Interfaces;
using Domain.Repositories;

namespace Domain.UseCases
{
    public class GetListaPersonasUseCase : IGetListaPersonasUseCases
    {
        private IGetListaPersonas _repo;

        // Inyección del repositorio (la implementación viene desde la capa Data)
        public GetListaPersonasUseCase(IGetListaPersonas repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Ejecuta la lógica del caso de uso.
        /// </summary>
        /// <returns>Lista de personas.</returns>
        public List<clsPersona> getListaPersonas()
        {
            // Aquí podrías agregar lógica de negocio adicional:
            // Ej: filtrar, ordenar, validar, etc.
            var personas = _repo.GetListaPersonas();
            return personas;
        }
    }
}
