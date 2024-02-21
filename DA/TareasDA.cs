using Abstracciones.DA;
using Abstracciones.Modelos;
using DA.Helpers;
using Dapper;
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

        public async Task<Guid> ActualizarTareas(Guid id, string nombre, string descripcion, DateTime fecha_inicio, DateTime fecha_fin, Usuarios asignados, string estado)
        {
            string sql = @"[ActualizarTarea]";
            var Consulta = await _sqlConnection.ExecuteAsync(sql, new { Id = id, Nombre = nombre, Descripcion = descripcion, Fecha_Inicio = fecha_inicio, Fecha_Fin = fecha_fin, Asignados = asignados, Estado = estado });
            return id;
            
                
        }

        public async Task<Guid> AgregarTareas(string nombre, string descripcion, DateTime fecha_inicio, DateTime fecha_fin, Usuarios asignados, string estado)
        {
            string sql = @"[AgregarTarea]";
            var Consulta = await _sqlConnection.ExecuteScalarAsync(sql, new { Nombre = nombre, Descripcion = descripcion, Fecha_Inicio = fecha_inicio, Fecha_Fin = fecha_fin, Asignados = asignados, Esatado = estado });
            return (Guid)Consulta;
        }

        public async Task<Guid> EliminarTareas(Guid id)
        {
            string sql = @"[EliminarTarea]";
            var Consulta = _sqlConnection.ExecuteAsync(sql, new { Id = id });
            return id;
        }

        public async Task<IEnumerable<Tareas>> MostrarTareas()
        {
            string sql = @"[MostrarTodasTareas]";
            var Consulta = await _sqlConnection.QueryAsync<DA.Entities.Tareas>(sql);
            return ConvertirListaTareaDBAModelo(Consulta.ToList());
        }

        public async Task<Tareas> MostrarTareasPorID(Guid id)
        {
            string sql = @"[ObtenerTareasPorId]";
            var Consulta = await _sqlConnection.QueryAsync<DA.Entities.Tareas>(sql, new { Id = id });
            return ConvertirTareaDBAModelo(Consulta.First());
        }
        private IEnumerable<Abstracciones.Modelos.Tareas> ConvertirListaTareaDBAModelo(IEnumerable<DA.Entities.Tareas> Tareas)
        {
            var resultadoConversion = Convertidor.ConvertirLista<DA.Entities.Tareas, Abstracciones.Modelos.Tareas>(Tareas);
            return resultadoConversion;
        }
        private Abstracciones.Modelos.Tareas ConvertirTareaDBAModelo(DA.Entities.Tareas Tareas)
        {
            var resultadoConversion = Convertidor.Convertir<DA.Entities.Tareas, Abstracciones.Modelos.Tareas>(Tareas);
            return resultadoConversion;
        }
    }
}
