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
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PersonasController>
        [HttpPost]
        public IActionResult Post([FromBody] clsPersona persona)
        {
            IActionResult salida;

            if (!ModelState.IsValid)
            {
                salida = BadRequest(ModelState);
            }
            else
            {
                try
                {
                    int filasAfectadas = _casoUso.CrearPersona(persona);

                    if (filasAfectadas > 0)
                    {
                        salida = Ok("La persona se creó correctamente");
                    }
                    else
                    {
                        salida = BadRequest("No se pudo crear la persona.");
                    }
                }
                catch (Exception ex)
                {
                    salida = BadRequest($"Error al crear la persona: {ex.Message}");
                }
            }

            return salida;
        }


        // PUT api/Personas/5
        // Actualiza una persona existente
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] clsPersona persona)
        {
            IActionResult salida;

            // Valida que el ID coincida
            if (id != persona.id)
            {
                salida = BadRequest("El ID de la persona no coincide.");
            }
            // Valida el modelo recibido
            else if (!ModelState.IsValid)
            {
                salida = BadRequest(ModelState);
            }
            else
            {
                try
                {
                    // Intenta actualizar la persona en la base de datos
                    int filasAfectadas = _casoUso.ActualizarPersona(id, persona);

                    if (filasAfectadas > 0)
                    {
                        salida = Ok("La persona se actualizó correctamente");
                    }
                    else
                    {
                        salida = NotFound("No se pudo actualizar la persona. Verifique el ID.");
                    }
                }
                catch (Exception ex)
                {
                    // Captura errores y devuelve BadRequest
                    salida = BadRequest($"Error al actualizar la persona: {ex.Message}");
                }
            }

            return salida;
        }


        // DELETE api/<PersonasController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            IActionResult salida;
            int numFilasAfectadas = 0;

            try
            {

                numFilasAfectadas = _casoUso.EliminarPersona(id);
                if (numFilasAfectadas == 0)
                {
                    salida = NotFound();
                }
                else
                {
                    salida = Ok();
                }
            }
            catch (Exception e)
            {
                salida = BadRequest();
            }

            return salida;

        }
    }
}
