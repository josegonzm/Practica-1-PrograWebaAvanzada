using Abstracciones.BW;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("API/[controller]")]
    public class UsuariosController : Controller, IUsuariosController
    {
        private IUsuariosBW _usuariosBW;
        private readonly ILogger<UsuariosController> _logger;

        public UsuariosController(IUsuariosBW usuariosBW, ILogger<UsuariosController> logger)
        {
            _usuariosBW = usuariosBW;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Usuarios usuarios)
        {
            try
            {
                _logger.LogInformation("Agregando persona");
                var id = await _usuariosBW.AgregarUsuario(usuarios.Nombre, usuarios.Primer_Apellido, usuarios.Segundo_Apellido, usuarios.Correo, usuarios.Contraseña);
                return CreatedAtAction(nameof(GetByIdAsync), new { id = id }, usuarios);
            } catch (Exception ex)
            {
                return GenerarError(ex, @"Error al agregar una persona");
            }
        }

        [HttpGet("{id}")]
        [ActionName(nameof(GetByIdAsync))]

        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            try
            {
                _logger.LogInformation("Consultando personas");
                return Ok(await _usuariosBW.MostrarUsuariosPorID(id));
            }
            catch (Exception ex)
            {
                return GenerarError(ex, @"Error al consultar los usuarios");
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                return Ok(await _usuariosBW.MostrarUsuarios());

            } catch (Exception ex)
            {
                return GenerarError(ex, @"Error al consultar los usuarios");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] string nombre, string primerApellido, string? segundoApellido, string correo, string contraseña)
        {
            try
            {
                _logger.LogInformation("Editando usuario");
                return Ok(await _usuariosBW.ActualizarUsuario(id, nombre, primerApellido, segundoApellido, correo, contraseña));
            } catch (Exception ex)
            {
                return GenerarError(ex, "Error al editar un usuario");
            }
        }



        private IActionResult GenerarError(Exception ex, string mensaje)
        {
            _logger.LogError(ex.Message);
            return StatusCode(500, new { Idcorrelacion = Guid.NewGuid(), Detalle = "Error consultando los usuarios" });
        }

    }
}
