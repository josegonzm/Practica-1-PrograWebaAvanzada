using Abstracciones.BW;
using Abstracciones.Modelos;
using BW;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("API/[controller]")]
    public class TareasController: Controller, ITareasController
    {

        private ITareasBW _tareasBW;
        private readonly ILogger<TareasController> _logger;

        public TareasController(ITareasBW TareasBW, ILogger<TareasController> logger)
        {
            _tareasBW = TareasBW;
            _logger = logger;
        }

        [HttpGet()]
        [Route("MostrarTareas")]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                return Ok(await _tareasBW.MostrarTareas());
            }
            catch (Exception ex)
            {
                return GenerarError(ex, @"Error al consultar las tareas");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromQuery] Guid id)
        {
            try
            {
                _logger.LogInformation("Eliminando tarea");
                return Ok(await _tareasBW.EliminarTareas(id));
            }
            catch (Exception ex)
            {
                return GenerarError(ex, @"Error al eliminar una tarea");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync([FromQuery] Guid id,  string nombre, string descripcion, DateTime fecha_inicio, DateTime fecha_fin, Usuarios asignado, string estado)
        {
            try
            {
                _logger.LogInformation("Editando tarea");
                return Ok(await _tareasBW.ActualizarTareas(id, nombre, descripcion, fecha_inicio, fecha_fin, asignado, estado));
            }
            catch (Exception ex)
            {
                return GenerarError(ex, @"Error al editar el usuario");
            }
        }

        [HttpPost()]
        public async Task<IActionResult> PostAsync([FromBody] Tareas tareas)
        {
            try
            {
                _logger.LogInformation("Agregando tarea");
                return Ok(await _tareasBW.AgregarTareas(tareas.Nombre, tareas.Descripcion, tareas.Fecha_Inicio, tareas.Fecha_Fin, tareas.Asignado, tareas.Estado));
            }
            catch (Exception ex)
            {
                return GenerarError(ex, @"Error al agregar tarea");
            }
        }


        private IActionResult GenerarError(Exception ex, string mensaje)
        {
            _logger.LogError(ex.Message);
            return StatusCode(500, new { Idcorrelacion = Guid.NewGuid(), Detalle = "Error consultando las tareas" });
        }



    }
}
