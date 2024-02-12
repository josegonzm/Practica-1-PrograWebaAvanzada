using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;


namespace Abstracciones.API
{
    public interface IUsuariosController
    {
        [HttpGet]
        Task<IActionResult> GetAsync();

        [HttpGet]
        Task<IActionResult> GetAsync(Guid id);

        [HttpPut]
        Task<IActionResult> PutAsync([FromQuery] Guid id, [FromBody] string nombre, [FromBody] string primerApellido, [FromBody] string? segundoApellido, [FromBody] string Correo, [FromBody] string Contraseña);

        [HttpDelete]
        Task<IActionResult> DeleteAsync([FromQuery] Guid id);

        [HttpPost]
        Task<IActionResult> PostAsync([FromBody] Usuarios usuarios);
    }
}
