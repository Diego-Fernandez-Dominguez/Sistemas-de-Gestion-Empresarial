using Domain.DTOs;
using Domain.Entities;

namespace Domain.Interfaces.UseCases
{
    public interface IPersonaUseCase
    {
        public List<clsPersona> getListaPersonas();
        List<PersonaConNombreDeDepartamentoDTO> getListaPersonasConDepartamento();
        PersonaConNombreDeDepartamentoDTO GetDetallePersona(int id);
        PersonaConListaDeDepartamentosDTO GetPersonaConListaDepartamentos(int id);
        PersonaConListaDeDepartamentosDTO GetPersonaParaCrear();

        int CrearPersona(clsPersona persona);
        int ActualizarPersona(int id, clsPersona persona);
        int EliminarPersona(int id);

    }
}
