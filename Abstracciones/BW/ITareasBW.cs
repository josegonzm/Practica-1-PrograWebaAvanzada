using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.BW
{
    public interface ITareasBW
    {
        Task<IEnumerable<Tareas>> MostrarTareas();
        Task<Abstracciones.Modelos.Tareas> MostrarTareasPorID(Guid id);
        Task<Guid> AgregarTareas(Guid id, string nombre, string descripcion, DateTime fecha_inicio, DateTime fecha_fin, Usuarios asignados, String estado);
        Task<Guid> ActualizarTareas(Guid id, string nombre, string descripcion, DateTime fecha_inicio, DateTime fecha_fin, Usuarios asignados, String estado);
        Task<Guid> EliminarTareas(Guid id);







    }
}
