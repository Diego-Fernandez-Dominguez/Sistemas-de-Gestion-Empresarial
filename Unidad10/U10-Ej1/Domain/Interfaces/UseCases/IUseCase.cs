using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IUseCase
    {
        List<clsPersona> getListaPersonas();
    }
}