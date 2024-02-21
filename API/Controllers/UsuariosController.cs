using Abstracciones.BW;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : Controller, IUsuariosController
    {
        private IUsuariosBW _usuarioBW;
        private readonly ILogger<UsuariosController> _logger;

        public UsuariosController(IUsuariosBW usuariosBW, ILogger<UsuariosController> logger)
        {
            _usuarioBW = usuariosBW;
            _logger = logger;
        }

        [HttpGet()]
        [Route("MostrarUsuarios")]
        public async Task<IActionResult> GetAsync() 
        {
            try
            {
                return Ok(await _usuarioBW.MostrarUsuarios());
            }
            catch (Exception ex)
            {
                return GenerarError(ex, @"Error al consultar los usuarios");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromQuery] Guid id)
        {
            try
            {
                _logger.LogInformation("Eliminando usuario");
                return Ok(await _usuarioBW.EliminarUsuario(id));
            }
            catch (Exception ex)
            {
                return GenerarError(ex, @"Error al eliminar un usuario");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync([FromQuery] Guid id, [FromBody] string nombre, string primer_apellido, string? segundo_apellido, string correo, string contraseña)
        {
            try
            {
                _logger.LogInformation("Editando usuario");
                return Ok(await _usuarioBW.ActualizarUsuario(id, nombre, primer_apellido, segundo_apellido, correo, contraseña));
            }
            catch (Exception ex)
            {
                return GenerarError(ex, @"Error al editar el usuario");
            }
        }

        [HttpPost()]
        public async Task<IActionResult> PostAsync([FromBody] Usuarios usuarios)
        {
            try
            {
                _logger.LogInformation("Agregando usuario");
                return Ok(await _usuarioBW.AgregarUsuario(usuarios.Nombre, usuarios.Primer_Apellido, usuarios.Segundo_Apellido, usuarios.Correo, usuarios.Contraseña));
            }
            catch (Exception ex)
            {
                return GenerarError(ex, @"Error al agregar usuario");
            }
        }

        private IActionResult GenerarError(Exception ex, string mensaje)
        {
            _logger.LogError(ex.Message);
            return StatusCode(500, new { Idcorrelacion = Guid.NewGuid(), Detalle = "Error consultando los usuarios" });
        }

    }
}
