using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.UseCases;

namespace Domain.UseCases
{
    public class PersonaUseCase : IPersonaUseCase
    {
        private IRepoPersona _repoPersonas;
        private IRepoDepartamento _repoDepartamentos;

        public PersonaUseCase(IRepoPersona personaRepository, IRepoDepartamento departamentoRepository)
        {
            _repoPersonas = personaRepository;
            _repoDepartamentos = departamentoRepository;
        }
        public List<clsPersona> getListaPersonas()
        {
            int edad = 0;

            List<clsPersona> personasFiltradas = new List<clsPersona>();

            foreach (clsPersona persona in _repoPersonas.getListaPersonas())
            {
                 edad = DateTime.Now.Year - persona.fechaNac.Year;

                if (persona.fechaNac.Date > DateTime.Now.AddYears(-edad))
                {
                    edad--;
                }

                if (edad <= 18)
                {
                    personasFiltradas.Add(persona);
                }

            }

            //retorna la lista de las personas filtrada
            return personasFiltradas;

        }

        public List<PersonaConNombreDeDepartamentoDTO> getListaPersonasConDepartamento()
        {
            List<PersonaConNombreDeDepartamentoDTO> listaPersonasConNombreDepartamento = new List<PersonaConNombreDeDepartamentoDTO>();
            List<clsDepartamento> listaDepartamentos = _repoDepartamentos.getListaDepartamentos();

            foreach (clsPersona persona in _repoPersonas.getListaPersonas())
            {
                var departamento = listaDepartamentos
                    .FirstOrDefault(d => d.id == persona.idDepartamento);

                string nombreDepartamento = departamento?.nombre ?? "Sin departamento";

                listaPersonasConNombreDepartamento.Add(
                    new PersonaConNombreDeDepartamentoDTO(
                        persona.id,
                        persona.nombre,
                        persona.apellido,
                        persona.direccion,
                        persona.telefono,
                        persona.fechaNac,
                        persona.imagen,
                        nombreDepartamento
                    )
                );
            }

            return listaPersonasConNombreDepartamento;
        }


        public PersonaConNombreDeDepartamentoDTO GetDetallePersona(int id)
        {
            clsPersona persona = _repoPersonas.getPersonaPorID(id);

            if (persona == null)
                return null;

            clsDepartamento departamento = _repoDepartamentos.getDepartamentoPorID(persona.idDepartamento);

            return new PersonaConNombreDeDepartamentoDTO(
                persona.id,
                persona.nombre,
                persona.apellido,
                persona.direccion,
                persona.telefono,
                persona.fechaNac,
                persona.imagen,
                departamento.nombre
            );
        }

        public PersonaConListaDeDepartamentosDTO GetPersonaConListaDepartamentos(int id)
        {
            clsPersona persona = _repoPersonas.getPersonaPorID(id);
            List<clsDepartamento> departamentos = _repoDepartamentos.getListaDepartamentos().ToList();

            return new PersonaConListaDeDepartamentosDTO(persona, departamentos);
        }

        public PersonaConListaDeDepartamentosDTO GetPersonaParaCrear()
        {
            clsPersona personaVacia = new clsPersona();
            List<clsDepartamento> departamentos = _repoDepartamentos.getListaDepartamentos().ToList();

            return new PersonaConListaDeDepartamentosDTO(personaVacia, departamentos);
        }

        public int CrearPersona(clsPersona persona)
        {
            return _repoPersonas.añadirPersona(persona);
        }

        public int ActualizarPersona(int id, clsPersona persona)
        {
            return _repoPersonas.actualizarPersona(id, persona);
        }

        public int EliminarPersona(int id)
        {
            return _repoPersonas.eliminarPersona(id);
        }

    }
}