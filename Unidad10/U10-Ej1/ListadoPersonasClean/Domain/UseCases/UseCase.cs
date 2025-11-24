using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.UseCases;

namespace Domain.UseCases
{
    public class UseCase : IUseCasePersona
    {
        private IRepoPersona _repo;

        // Inyección del repositorio (la implementación viene desde la capa Data)
        public UseCase(IRepoPersona repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Ejecuta la lógica del caso de uso.
        /// </summary>
        /// <returns>Lista de personas.</returns>
        public List<clsPersona> getListaPersonas()
        {
            var personas = _repo.getListaPersonas();
            return personas;
        }
    }
}
