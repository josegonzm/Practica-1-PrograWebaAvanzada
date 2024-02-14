using Abstracciones.BW;
using Abstracciones.Modelos;
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

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Tareas tareas)
        {
            try
            {
                _logger.LogInformation("Agregando tarea");
                var id = await _tareasBW.AgregarTareas(tareas.Nombre, tareas.Descripcion, tareas.Fecha_Inicio, tareas.Fecha_Fin, tareas.Asignado, tareas.Estado);
                return CreatedAtAction(nameof(GetByIdAsync), new { id = id }, tareas);
            }
            catch (Exception ex)
            {
                return GenerarError(ex, @"Error al agregar una tarea");
            }
        }

        [HttpGet("{id}")]
        [ActionName(nameof(GetByIdAsync))]

        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            try
            {
                _logger.LogInformation("Consultando personas");
                return Ok(await _tareasBW.MostrarTareasPorID(id));
            }
            catch (Exception ex)
            {
                return GenerarError(ex, @"Error al consultar las tareas");
            }

        }

        [HttpGet]
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

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id,  string nombre, string descripcion, DateTime fecha_inico, DateTime fecha_final, Usuarios asignado, string estado)
        {
            try
            {
                _logger.LogInformation("Editando tarea");
                return Ok(await _tareasBW.ActualizarTareas(id, nombre, descripcion, fecha_inico, fecha_final, asignado, estado));
            }
            catch (Exception ex)
            {
                return GenerarError(ex, "Error al editar una tarea");
            }
        }



        private IActionResult GenerarError(Exception ex, string mensaje)
        {
            _logger.LogError(ex.Message);
            return StatusCode(500, new { Idcorrelacion = Guid.NewGuid(), Detalle = "Error consultando las tareas" });
        }



    }
}
