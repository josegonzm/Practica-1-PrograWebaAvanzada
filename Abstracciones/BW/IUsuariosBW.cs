﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.BW
{
    public interface IUsuariosBW
    {
        Task<Guid> AgregarUsuario(string nombre, string primerApellido, string? segundoApellido, string correo, string contraseña);
        Task<Guid> ActualizarUsuario(Guid id, string nombre, string primerApellido, string? segundoApellido, string correo, string contraseña);
        Task<Guid> EliminarUsuario(Guid id);
    }
}
