using Domain.Entities;
using Domain.Interfaces.UseCases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class PersonaController : Controller
    {
        private readonly IPersonaUseCase _casoUsoPersona;
        private readonly IDepartamentoUseCase _casoUsoDepartamento;

        public PersonaController(IPersonaUseCase useCasePersona, IDepartamentoUseCase useCaseDepartamento)
        {
            _casoUsoPersona = useCasePersona;
            _casoUsoDepartamento = useCaseDepartamento;
        }

        /// <summary>
        /// <description>Muestra la lista de personas con su departamento.</description>
        /// <precondition>Ninguna</precondition>
        /// <postcondition>Se devuelve la vista con la lista de personas y sus departamentos.</postcondition>
        /// </summary>
        /// <returns>Vista con la lista de personas.</returns>
        public ActionResult Index()
        {
            ActionResult salida;
            try
            {
                var listado = _casoUsoPersona.GetListaPersonasConDepartamento();
                salida = View(listado);
            }
            catch
            {
                salida = BadRequest("Error al obtener la lista de personas.");
            }
            return salida;
        }

        /// <summary>
        /// <description>Muestra los detalles de una persona por su ID.</description>
        /// <precondition>El ID de la persona debe existir.</precondition>
        /// <postcondition>Se devuelve la vista con los detalles de la persona o NotFound si no existe.</postcondition>
        /// </summary>
        /// <param name="id">ID de la persona a mostrar.</param>
        /// <returns>Vista con los detalles de la persona.</returns>
        public ActionResult Details(int id)
        {
            ActionResult salida;
            try
            {
                var persona = _casoUsoPersona.GetDetallePersona(id);
                salida = persona != null ? View(persona) : NotFound();
            }
            catch
            {
                salida = BadRequest("Error al obtener los detalles de la persona.");
            }
            return salida;
        }

        /// <summary>
        /// <description>Obtiene los datos necesarios para crear una nueva persona.</description>
        /// <precondition>Ninguna</precondition>
        /// <postcondition>Se devuelve la vista para ingresar los datos de la nueva persona.</postcondition>
        /// </summary>
        /// <returns>Vista para crear una persona.</returns>
        public ActionResult Create()
        {
            ActionResult salida;
            try
            {
                var listaDept = _casoUsoDepartamento.GetDepartamentos();
                salida = View(listaDept);
            }
            catch
            {
                salida = BadRequest("Error al preparar la creación de la persona.");
            }
            return salida;
        }

        /// <summary>
        /// <description>Procesa la creación de una nueva persona en la base de datos.</description>
        /// <precondition>El modelo debe ser válido.</precondition>
        /// <postcondition>Se crea la persona o se devuelve la vista con errores si ocurre algún problema.</postcondition>
        /// </summary>
        /// <param name="persona">Objeto con los datos de la persona a crear.</param>
        /// <returns>Redirige al Index si la creación fue exitosa o vuelve a la vista con errores.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(clsPersona persona)
        {
            ActionResult salida;

            if (!ModelState.IsValid)
            {
                var dto = _casoUsoPersona.GetPersonaParaCrear();
                dto.Persona = persona;
                salida = View(dto);
            }
            else
            {
                try
                {
                    int filasAfectadas = _casoUsoPersona.CrearPersona(persona);

                    if (filasAfectadas > 0)
                    {
                        salida = RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        throw new Exception("No se pudo crear la persona en la base de datos.");
                    }
                }
                catch (Exception ex)
                {
                    var dto = _casoUsoPersona.GetPersonaParaCrear();
                    dto.Persona = persona;
                    ModelState.AddModelError("", $"Error al crear la persona: {ex.Message}");
                    salida = View(dto);
                }
            }

            return salida;
        }

        /// <summary>
        /// <description>Obtiene la persona y la lista de departamentos para editar.</description>
        /// <precondition>El ID de la persona debe existir.</precondition>
        /// <postcondition>Se devuelve la vista con los datos de la persona para editar.</postcondition>
        /// </summary>
        /// <param name="id">ID de la persona a editar.</param>
        /// <returns>Vista de edición de la persona.</returns>
        public ActionResult Edit(int id)
        {
            ActionResult salida;
            try
            {
                var dto = _casoUsoPersona.GetPersonaConListaDepartamentos(id);
                salida = (dto != null && dto.Persona != null) ? View(dto) : NotFound();
            }
            catch
            {
                salida = BadRequest("Error al obtener la persona para editar.");
            }
            return salida;
        }

        /// <summary>
        /// <description>Actualiza los datos de una persona existente en la base de datos.</description>
        /// <precondition>El modelo debe ser válido y el ID de la ruta debe coincidir con el ID de la persona.</precondition>
        /// <postcondition>Se actualizan los datos de la persona o se devuelve la vista con errores si ocurre algún problema.</postcondition>
        /// </summary>
        /// <param name="id">ID de la persona a actualizar.</param>
        /// <param name="persona">Objeto con los datos actualizados.</param>
        /// <returns>Redirige al Index si la actualización fue exitosa o vuelve a la vista con errores.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, clsPersona persona)
        {
            ActionResult salida;

            if (id != persona.id)
            {
                salida = NotFound();
            }
            else if (!ModelState.IsValid)
            {
                var dto = _casoUsoPersona.GetPersonaConListaDepartamentos(id);
                dto.Persona = persona;
                salida = View(dto);
            }
            else
            {
                try
                {
                    int filasAfectadas = _casoUsoPersona.ActualizarPersona(id, persona);

                    if (filasAfectadas > 0)
                    {
                        salida = RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        throw new Exception("No se pudo actualizar la persona. Verifique el ID.");
                    }
                }
                catch (Exception ex)
                {
                    var dto = _casoUsoPersona.GetPersonaConListaDepartamentos(id);
                    dto.Persona = persona;
                    ModelState.AddModelError("", $"Error al editar la persona: {ex.Message}");
                    salida = View(dto);
                }
            }

            return salida;
        }

        /// <summary>
        /// <description>Muestra la persona a eliminar.</description>
        /// <precondition>El ID de la persona debe existir.</precondition>
        /// <postcondition>Se devuelve la vista con los datos de la persona para confirmar la eliminación.</postcondition>
        /// </summary>
        /// <param name="id">ID de la persona a eliminar.</param>
        /// <returns>Vista de confirmación de eliminación.</returns>
        public ActionResult Delete(int id)
        {
            ActionResult salida;
            try
            {
                var persona = _casoUsoPersona.GetDetallePersona(id);
                salida = persona != null ? View(persona) : NotFound();
            }
            catch
            {
                salida = BadRequest("Error al obtener la persona para eliminar.");
            }
            return salida;
        }

        /// <summary>
        /// <description>Elimina una persona de la base de datos por su ID.</description>
        /// <precondition>El ID de la persona debe existir.</precondition>
        /// <postcondition>La persona se elimina o se devuelve la vista con un mensaje de error.</postcondition>
        /// </summary>
        /// <param name="id">ID de la persona a eliminar.</param>
        /// <param name="collection">Formulario enviado desde la vista (no se utiliza).</param>
        /// <returns>Redirige al Index si la eliminación fue exitosa o vuelve a la vista con errores.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            ActionResult salida;
            try
            {
                _casoUsoPersona.EliminarPersona(id);
                salida = RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Error al eliminar la persona.");
                salida = View();
            }
            return salida;
        }
    }
}
