using Abstracciones.BW;
using Abstracciones.DA;
using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BW
{
    public class TareasBW: ITareasBW
    {

        private ITareasDA _TareasDA;

        public TareasBW(ITareasDA tareasDA)
        {
            _TareasDA = tareasDA;
        }

        public async Task<IEnumerable<Tareas>> MostrarTareas()
        {
            return await _TareasDA.MostrarTareas();
        }
        public async Task<Tareas> MostrarTareasPorID(Guid id)
        {
            return await _TareasDA.MostrarTareasPorID(id);
        }
        public async Task<Guid> AgregarTareas(string nombre, string descripcion, DateTime fecha_inicio, DateTime fecha_fin, Usuarios asignado, string estado)
        {
            return await _TareasDA.AgregarTareas(nombre, descripcion, fecha_inicio, fecha_fin, asignado, estado);
        }

        public async Task<Guid> ActualizarTareas(Guid id, string nombre, string descripcion, DateTime fecha_inicio, DateTime fecha_fin, Usuarios asignado, string estado)
        {
            return await _TareasDA.ActualizarTareas(id, nombre, descripcion, fecha_inicio, fecha_fin, asignado, estado);
        }

        public async Task<Guid> EliminarTareas(Guid id)
        {
            return await _TareasDA.EliminarTareas(id);
        }




    }
}
