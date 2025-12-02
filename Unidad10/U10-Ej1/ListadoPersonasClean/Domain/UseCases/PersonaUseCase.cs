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

        /// <summary>
        /// <description>Obtiene la lista de personas cuya edad es menor o igual a 18 años.</description>
        /// <precondition>Ninguna</precondition>
        /// <postcondition>Devuelve una lista de personas filtradas por edad (≤ 18). La lista puede estar vacía si no hay personas que cumplan el criterio.</postcondition>
        /// </summary>
        /// <returns>Lista de personas con edad menor o igual a 18 años.</returns>
        public List<clsPersona> GetListaPersonas()
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

            return personasFiltradas;
        }

        /// <summary>
        /// <description>Obtiene la lista de personas junto con el nombre de su departamento.</description>
        /// <precondition>Ninguna</precondition>
        /// <postcondition>Devuelve una lista de personas con su información y el nombre del departamento (o "Sin departamento" si no tiene).</postcondition>
        /// </summary>
        /// <returns>Lista de personas con su departamento correspondiente.</returns>
        public List<PersonaConNombreDeDepartamentoDTO> GetListaPersonasConDepartamento()
        {
            List<PersonaConNombreDeDepartamentoDTO> listaPersonasConNombreDepartamento = new List<PersonaConNombreDeDepartamentoDTO>();
            List<clsDepartamento> listaDepartamentos = _repoDepartamentos.getListaDepartamentos();

            foreach (clsPersona persona in _repoPersonas.getListaPersonas())
            {
                var departamento = listaDepartamentos.FirstOrDefault(d => d.id == persona.idDepartamento);
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

        /// <summary>
        /// <description>Obtiene los detalles de una persona por su ID, incluyendo el nombre del departamento.</description>
        /// <precondition>El ID de la persona debe ser válido (> 0).</precondition>
        /// <postcondition>Devuelve la persona con su información y el nombre del departamento si existe; en caso contrario, devuelve null.</postcondition>
        /// </summary>
        /// <returns>Objeto que contiene la información de la persona y el nombre de su departamento, o null si no se encuentra.</returns>
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

        /// <summary>
        /// <description>Obtiene una persona por su ID junto con la lista completa de departamentos.</description>
        /// <precondition>El ID de la persona debe ser válido (> 0).</precondition>
        /// <postcondition>Devuelve la persona y todos los departamentos disponibles.</postcondition>
        /// </summary>
        /// <returns>Objeto que contiene la persona y la lista completa de departamentos.</returns>
        public PersonaConListaDeDepartamentosDTO GetPersonaConListaDepartamentos(int id)
        {
            clsPersona persona = _repoPersonas.getPersonaPorID(id);
            List<clsDepartamento> departamentos = _repoDepartamentos.getListaDepartamentos().ToList();

            return new PersonaConListaDeDepartamentosDTO(persona, departamentos);
        }

        /// <summary>
        /// <description>Prepara un objeto persona vacío junto con la lista completa de departamentos para la creación.</description>
        /// <precondition>Ninguna</precondition>
        /// <postcondition>Devuelve un objeto con una persona vacía y la lista de departamentos.</postcondition>
        /// </summary>
        /// <returns>Objeto con una nueva persona vacía y todos los departamentos.</returns>
        public PersonaConListaDeDepartamentosDTO GetPersonaParaCrear()
        {
            clsPersona persona = new clsPersona();
            List<clsDepartamento> departamentos = _repoDepartamentos.getListaDepartamentos().ToList();

            return new PersonaConListaDeDepartamentosDTO(persona, departamentos);
        }

        /// <summary>
        /// <description>Crea una nueva persona en el repositorio.</description>
        /// <precondition>El objeto persona debe tener propiedades válidas.</precondition>
        /// <postcondition>La persona se agrega al repositorio y se devuelve su nuevo ID.</postcondition>
        /// </summary>
        /// <returns>ID de la persona recién creada.</returns>
        public int CrearPersona(clsPersona persona)
        {
            return _repoPersonas.añadirPersona(persona);
        }

        /// <summary>
        /// <description>Actualiza los datos de una persona existente en el repositorio.</description>
        /// <precondition>El ID de la persona debe existir y el objeto persona debe tener propiedades válidas.</precondition>
        /// <postcondition>Los datos de la persona se actualizan y se devuelve un código indicando el resultado.</postcondition>
        /// </summary>
        /// <returns>Entero que indica el resultado de la actualización.</returns>
        public int ActualizarPersona(int id, clsPersona persona)
        {
            return _repoPersonas.actualizarPersona(id, persona);
        }

        /// <summary>
        /// <description>Elimina una persona del repositorio por su ID.</description>
        /// <precondition>El ID de la persona debe existir.</precondition>
        /// <postcondition>La persona se elimina del repositorio y se devuelve un código indicando el resultado.</postcondition>
        /// </summary>
        /// <returns>Entero que indica el resultado de la eliminación.</returns>
        public int EliminarPersona(int id)
        {
            return _repoPersonas.eliminarPersona(id);
        }
    }
}
