using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.API
{
  public interface ITareasController
    {


        [HttpGet]
        Task<IActionResult> GetAsync();

        [HttpGet]
        Task<IActionResult> GetAsync(Guid id);

        [HttpPut]
        Task<IActionResult> PutAsync([FromQuery] Guid id, [FromBody]

        string nombre, [FromBody] string descripcion, [FromBody] DateTime fecha_inicio, [FromBody] DateTime fecha_fin , [FromBody] Usuarios asignado ,  
       
         [FromBody] string estado     );

        [HttpDelete]
        Task<IActionResult> DeleteAsync([FromQuery] Guid id);

        [HttpPost]
        Task<IActionResult> PostAsync([FromBody] Tareas tareas);




    }
}
