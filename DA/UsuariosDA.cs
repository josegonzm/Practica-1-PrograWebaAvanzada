using Abstracciones.DA;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA
{
    public class UsuariosDA: IUsuariosDA
    {
        private IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;

        public UsuariosDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = repositorioDapper.ObtenerRepositorioDapper();
        }

        public async Task<Guid> AgregarUsuario(string nombre, string primerApellido, string? segundoApellido, string correo, string contraseña)
        {
            string sql = "@[AgregarUsuario]";
            var Consulta = await _sqlConnection.ExecuteScalarAsync(sql, new { Nombre = nombre, Primer_Apellido = primerApellido, Segundo_Apellido = segundoApellido, Correo = correo, Contraseña = contraseña });
            return (Guid)Consulta;

        }

        public async Task<Guid> ActualizarUsuario(Guid id, string nombre, string primerApellido, string? segundoApellido, string correo, string contraseña)
        {
            string sql = "@[ActualizarUsuario]";
            var Consulta = await _sqlConnection.ExecuteAsync(sql, new { Id = id, Nombre = nombre, Primer_Apellido = primerApellido, Segundo_Apellido = segundoApellido, Correo = correo, Contraseña = contraseña });
            return id;
        }

        public async Task<Guid> EliminarUsuario(Guid id)
        {
            string sql = "@[EliminarUsuario]";
            var Consulta = _sqlConnection.ExecuteAsync(sql, new { Id = id });
            return id;
        }
    }
}
