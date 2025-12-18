using Domain.Entities;
using Domain.Interfaces.UseCases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace UI.Controllers
{
    public class DepartamentoController : Controller
    {
        private readonly IDepartamentoUseCase _useCase;

        public DepartamentoController(IDepartamentoUseCase useCase)
        {
            _useCase = useCase;
        }

        /// <summary>
        /// <description>Muestra la lista de todos los departamentos.</description>
        /// <precondition>Ninguna</precondition>
        /// <postcondition>Se devuelve la vista con la lista de departamentos.</postcondition>
        /// </summary>
        /// <returns>Vista con la lista de departamentos.</returns>
        public ActionResult Index()
        {
            ActionResult resultado;
            try
            {
                var departamentos = _useCase.GetDepartamentos();
                resultado = View(departamentos);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error al obtener la lista de departamentos: {ex.Message}";
                resultado = View(new List<clsDepartamento>());
            }
            return resultado;
        }

        /// <summary>
        /// <description>Muestra los detalles de un departamento específico por ID.</description>
        /// <precondition>El ID del departamento debe existir.</precondition>
        /// <postcondition>Se devuelve la vista con los detalles del departamento o redirige a Index si hay error.</postcondition>
        /// </summary>
        /// <param name="id">ID del departamento a mostrar.</param>
        /// <returns>Vista con los detalles del departamento.</returns>
        public ActionResult Details(int id)
        {
            ActionResult resultado;
            try
            {
                var departamento = _useCase.GetDetalleDepartamento(id);
                if (departamento == null)
                {
                    resultado = NotFound();
                }
                else
                {
                    resultado = View(departamento);
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error al obtener los detalles del departamento: {ex.Message}";
                resultado = RedirectToAction(nameof(Index));
            }
            return resultado;
        }

        /// <summary>
        /// <description>Muestra la vista para crear un nuevo departamento.</description>
        /// <precondition>Ninguna</precondition>
        /// <postcondition>Se devuelve la vista de creación de departamento.</postcondition>
        /// </summary>
        /// <returns>Vista de creación de departamento.</returns>
        public ActionResult Create()
        {
            ActionResult resultado;
            try
            {
                resultado = View();
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error al mostrar la vista de creación: {ex.Message}";
                resultado = RedirectToAction(nameof(Index));
            }
            return resultado;
        }

        /// <summary>
        /// <description>Procesa la creación de un nuevo departamento en la base de datos.</description>
        /// <precondition>El modelo debe ser válido.</precondition>
        /// <postcondition>Se crea el departamento o se devuelve la vista con errores si ocurre algún problema.</postcondition>
        /// </summary>
        /// <param name="departamento">Datos del nuevo departamento.</param>
        /// <returns>Redirige a Index si se creó correctamente o vuelve a la vista con errores.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(clsDepartamento departamento)
        {
            ActionResult resultado;
            try
            {
                if (!ModelState.IsValid)
                {
                    resultado = View();
                }
                else
                {
                    _useCase.CrearDepartamento(departamento);
                    resultado = RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error al crear el departamento: {ex.Message}");
                resultado = View();
            }
            return resultado;
        }

        /// <summary>
        /// <description>Muestra la vista para editar un departamento existente.</description>
        /// <precondition>El ID del departamento debe existir.</precondition>
        /// <postcondition>Se devuelve la vista con los datos del departamento para editar o NotFound si no existe.</postcondition>
        /// </summary>
        /// <param name="id">ID del departamento a editar.</param>
        /// <returns>Vista de edición de departamento.</returns>
        public ActionResult Edit(int id)
        {
            ActionResult resultado;
            try
            {
                var departamento = _useCase.GetDepartamentoParaEditar(id);
                resultado = departamento != null ? View(departamento) : NotFound();
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error al obtener el departamento para editar: {ex.Message}";
                resultado = RedirectToAction(nameof(Index));
            }
            return resultado;
        }

        /// <summary>
        /// <description>Procesa la actualización de un departamento existente.</description>
        /// <precondition>El modelo debe ser válido y el ID debe coincidir con el departamento a actualizar.</precondition>
        /// <postcondition>Se actualizan los datos del departamento o se devuelve la vista con errores si ocurre algún problema.</postcondition>
        /// </summary>
        /// <param name="id">ID del departamento a actualizar.</param>
        /// <param name="departamento">Datos actualizados del departamento.</param>
        /// <returns>Redirige a Index si la actualización fue exitosa o vuelve a la vista con errores.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, clsDepartamento departamento)
        {
            ActionResult resultado;
            try
            {
                if (id != departamento.id)
                {
                    resultado = NotFound();
                }
                else if (!ModelState.IsValid)
                {
                    resultado = View(departamento);
                }
                else
                {
                    _useCase.ActualizarDepartamento(departamento);
                    resultado = RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error al editar el departamento: {ex.Message}");
                resultado = View(departamento);
            }
            return resultado;
        }

        /// <summary>
        /// <description>Muestra la vista de confirmación de eliminación de un departamento y la cantidad de personas asociadas.</description>
        /// <precondition>El ID del departamento debe existir.</precondition>
        /// <postcondition>Se devuelve la vista de confirmación con información sobre las personas asociadas.</postcondition>
        /// </summary>
        /// <param name="id">ID del departamento a eliminar.</param>
        /// <returns>Vista de confirmación de eliminación.</returns>
        public ActionResult Delete(int id)
        {
            ActionResult resultado;
            try
            {
                var departamento = _useCase.GetDetalleDepartamento(id);
                if (departamento == null)
                {
                    resultado = NotFound();
                }
                else
                {
                    var personas = _useCase.GetPersonasPorDepartamento(id);
                    ViewBag.CantidadPersonas = personas.Count;
                    ViewBag.TienePersonas = personas.Count > 0;
                    resultado = View(departamento);
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error al obtener el departamento para eliminar: {ex.Message}";
                resultado = RedirectToAction(nameof(Index));
            }
            return resultado;
        }

        /// <summary>
        /// <description>Procesa la eliminación de un departamento por su ID.</description>
        /// <precondition>El departamento no debe tener personas asignadas.</precondition>
        /// <postcondition>El departamento se elimina o se redirige con un mensaje de error si no se puede eliminar.</postcondition>
        /// </summary>
        /// <param name="id">ID del departamento a eliminar.</param>
        /// <param name="collection">Formulario enviado desde la vista (no se utiliza).</param>
        /// <returns>Redirige a Index o vuelve a Delete con mensaje de error si no se puede eliminar.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            ActionResult resultado;
            try
            {
                _useCase.EliminarDepartamento(id);
                resultado = RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException ex)
            {
                TempData["Error"] = ex.Message;
                resultado = RedirectToAction(nameof(Delete), new { id = id });
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Ocurrió un error al intentar eliminar: {ex.Message}";
                resultado = RedirectToAction(nameof(Index));
            }
            return resultado;
        }
    }
}
