using Domain.Entities;
using Domain.Interfaces.UseCasesInterfaces;
using Domain.Interfaces.RepositoriesInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases
{
    public class ListaMisionesUseCases: IListaMisionesUseCases 
    {
        private readonly IRepositoryMision _repositoryMision;

        public ListaMisionesUseCases(IRepositoryMision repositoryMision)
        {
            _repositoryMision = repositoryMision;
        }

        /// <summary>
        /// Funcion que devuelve un listado completo de misiones
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<clsMision> getListaMisiones()
        {
            return _repositoryMision.getListaMisiones();
        }
    }
}
