using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.UseCasesInterfaces
{
    public interface IListaMisionesUseCases
    {
        public List<clsMision> getListaMisiones();
    }
}
