using Abstracciones.BW;
using Abstracciones.DA;
using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BW
{
    public class UsuariosBW: IUsuariosBW
    {
        private IUsuariosDA _UsuariosDA;

        public UsuariosBW(IUsuariosDA usuariosDA)
        {
            _UsuariosDA = usuariosDA;
        }

        public async Task<IEnumerable<Usuarios>> MostrarUsuarios()
        {
            return await _UsuariosDA.MostrarUsuarios();
        }
        public async Task<Usuarios> MostrarUsuariosPorID(Guid id)
        {
            return await _UsuariosDA.MostrarUsuariosPorID(id);
        }
        public async Task<Guid> AgregarUsuario(string nombre, string primerApellido, string? segundoApellido, string correo, string contraseña)
        {
            return await _UsuariosDA.AgregarUsuario( nombre, primerApellido, segundoApellido, correo, contraseña);
        }

        public async Task<Guid> ActualizarUsuario(Guid id, string nombre, string primerApellido, string? segundoApellido, string correo, string contraseña)
        {
            return await _UsuariosDA.ActualizarUsuario(id, nombre, primerApellido, segundoApellido, correo, contraseña);
        }

        public async Task<Guid> EliminarUsuario(Guid id)
        {
            return await _UsuariosDA.EliminarUsuario(id);
        }
    }
}
