using Abstracciones.DA;
using Abstracciones.Modelos;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA
{
public class TareasDA : ITareasDA
    {

        private IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;

        public  TareasDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = repositorioDapper.ObtenerRepositorioDapper();
        }

        public Task<Guid> ActualizarTareas(Guid id, string nombre, string descripcion, DateTime fecha_inicio, DateTime fecha_fin, Usuarios asignados, string estado)
        {
            string sql = "@[ActualizarTarea]"; 
            
                
        }

        public Task<Guid> AgregarTareas(Guid id, string nombre, string descripcion, DateTime fecha_inicio, DateTime fecha_fin, Usuarios asignados, string estado)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> EliminarTareas(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Tareas>> MostrarTareas()
        {
            throw new NotImplementedException();
        }

        public Task<Tareas> MostrarTareasPorID(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
