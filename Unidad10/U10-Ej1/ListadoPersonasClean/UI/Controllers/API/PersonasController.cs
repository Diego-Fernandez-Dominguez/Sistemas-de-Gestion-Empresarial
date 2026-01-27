using Domain.Entities;
using Domain.Interfaces.UseCases;
using Domain.UseCases;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UI.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {

        private readonly IPersonaUseCase _casoUso;
        public PersonasController(IPersonaUseCase useCase)
        {
            _casoUso = useCase;
        }

        // GET: api/<PersonasController>
        [HttpGet]
        public IActionResult Get()
        {
            IActionResult salida;
            List<clsPersona> listadoCompleto = new List<clsPersona>();

            try
            {

                listadoCompleto = _casoUso.GetListaPersonas();
                if (listadoCompleto.Count() == 0)
                {
                    salida = NoContent();
                }
                else
                {
                    salida = Ok(listadoCompleto);
                }
            }
            catch
            {
                salida = BadRequest();
            }
            return salida;

        }

        // GET api/<PersonasController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IActionResult salida;

            try
            {
                clsPersona persona = _casoUso.GetPersonaById(id);

                if (persona == null)
                {
                    salida = NotFound($"No se encontró la persona con ID {id}");
                }
                else
                {
                    salida = Ok(persona);
                }
            }
            catch (Exception ex)
            {
                salida = BadRequest($"Error al obtener la persona: {ex.Message}");
            }

            return salida;
        }

        // POST api/<PersonasController>
        [HttpPost]
        public IActionResult Post([FromBody] clsPersona persona)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _casoUso.CrearPersona(persona);
                return Ok("La persona se creó correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al crear la persona: {ex.Message}");
            }
        }



        // PUT api/Personas/5
        // Actualiza una persona existente
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] clsPersona persona)
        {
            if (id != persona.id)
                return BadRequest("El ID de la persona no coincide.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _casoUso.ActualizarPersona(id, persona);
                return Ok("La persona se actualizó correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al actualizar la persona: {ex.Message}");
            }
        }



        // DELETE api/<PersonasController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _casoUso.EliminarPersona(id);
                return Ok("La persona se eliminó correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al eliminar la persona: {ex.Message}");
            }
        }
    }
}